using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace DnD.Content
{
    public enum eAttribute
    {
        strength,
        dexterity,
        constitution,
        intelligence,
        wisdom,
        charisma
    }

    [Serializable]
    public class Attributes
    {
        [SerializeField]
        public int strength;
        [SerializeField]
        public int dexterity;
        [SerializeField]
        public int constitution;
        [SerializeField]
        public int intelligence;
        [SerializeField]
        public int wisdom;
        [SerializeField]
        public int charisma;

        public int GetModifier(int value, eAttribute attribute)
        {
            switch (attribute)
            {
                case eAttribute.strength:
                    return 0;
                case eAttribute.dexterity:
                    return 0;
                case eAttribute.constitution:
                    return 0;
                case eAttribute.intelligence:
                    return 0;
                case eAttribute.wisdom:
                    return 0;
                case eAttribute.charisma:
                    return 0;
            }
            return 0;
        }
    }

    [Serializable]
    public class SavingThrows
    {
        [SerializeField]
        public int strength;
        [SerializeField]
        public int dexterity;
        [SerializeField]
        public int constitution;
        [SerializeField]
        public int intelligence;
        [SerializeField]
        public int wisdom;
        [SerializeField]
        public int charisma;
    }

    [Serializable]
    public class Skills
    {
        [SerializeField]
        public int athletics;
        [SerializeField]
        public int acrobatics;
        [SerializeField]
        public int sleight_of_hand;
        [SerializeField]
        public int stealth;
        [SerializeField]
        public int arcana;
        [SerializeField]
        public int history;
        [SerializeField]
        public int investigation;
        [SerializeField]
        public int nature;
        [SerializeField]
        public int religion;
        [SerializeField]
        public int animal_handling;
        [SerializeField]
        public int insight;
        [SerializeField]
        public int medicine;
        [SerializeField]
        public int perception;
        [SerializeField]
        public int survival;
        [SerializeField]
        public int deception;
        [SerializeField]
        public int intimidation;
        [SerializeField]
        public int performance;
        [SerializeField]
        public int persuasion;
    }

    [Serializable]
    public class Proficiencies
    {
        [SerializeField]
        public string[] armor;
        [SerializeField]
        public string[] weapons;
    }

    [Serializable]
    public class HitPoints
    {
        [SerializeField]
        public string dice;
        [SerializeField]
        public int first;
        [SerializeField]
        public string high;
    }

    public class Tables
    {
        public static readonly int[] PROFICIENCY_BONUS = new int[20] 
        {       
            2, 
            2,
            2,
            2,
            3,
            3,
            3,
            3,
            4,
            4,
            4,
            4,
            5,
            5,
            5,
            5,
            6,
            6,
            6,
            6
        };
    }

    public class ContentDatabase : ScriptableObject {

        public const string SAVE_PATH = "Assets/Resources/";
        public const string SAVE_FILENAME = "ContentDatabase";

        [Header("Item Databases")]
        [SerializeField]
        private TextAsset WeaponDatabase;
        [SerializeField]
        private TextAsset ArmorDatabase;
        [SerializeField]
        private TextAsset GearDatabase;
        [SerializeField]
        private TextAsset ToolDatabase;
        [Header("Creature Databases")]
        [SerializeField]
        private TextAsset MonsterDatabase;
        [SerializeField]
        private TextAsset NPCDatabase;

        [SerializeField]
        private List<DnDCreatureDefinition> MonsterDefinitions = new List<DnDCreatureDefinition>();
        [SerializeField]
        private List<DnDItemDefinition> ItemDefinitions = new List<DnDItemDefinition>();
        [SerializeField]
        private List<DnDWeaponDefinition> WeaponDefinitions = new List<DnDWeaponDefinition>();
        [SerializeField]
        private List<DnDArmorDefinition> ArmorDefinitions = new List<DnDArmorDefinition>();
        [SerializeField]
        private List<DnDNPCDefinition> NPCDefinitions = new List<DnDNPCDefinition>();
        [SerializeField]
        private List<DnDLocationDefinition> LocationDefinitions = new List<DnDLocationDefinition>();
        [SerializeField]
        private List<DnDPlayerDefinition> PlayerDefinitions = new List<DnDPlayerDefinition>();

        static ContentDatabase instance;
        public static ContentDatabase Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = (ContentDatabase)Resources.Load(SAVE_FILENAME, typeof(ContentDatabase));
#if UNITY_EDITOR
                    if (instance == null)
                    {
                        ContentDatabase contentDatabase = ScriptableObject.CreateInstance<ContentDatabase>();
                        AssetDatabase.CreateAsset(contentDatabase, SAVE_PATH + SAVE_FILENAME + ".asset");
                        instance = contentDatabase;
                    }
#endif         
                }
                return instance;
            }
        }

        public void LoadDefinitionsFromDatabase()
        {
            //Load monster definitions
            Creature[] monsterList = JsonHelper.FromJson<Creature>(MonsterDatabase.text);
            
            if(MonsterDefinitions != null)
            {
                if(MonsterDefinitions.Count > 0) MonsterDefinitions.Clear();
            }

            foreach(Creature monster in monsterList)
            {
                MonsterDefinitions.Add(new DnDCreatureDefinition(monster, "DnD"));
            }

            //Load item definitions
            Gear gearList = JsonUtility.FromJson<Gear>(GearDatabase.text);
            Gear toolList = JsonUtility.FromJson<Gear>(ToolDatabase.text);
            Armor[] armorList = JsonHelper.FromJson<Armor>(ArmorDatabase.text);
            Weapon[] weaponList = JsonHelper.FromJson<Weapon>(WeaponDatabase.text);

            if (ItemDefinitions != null)
            {
                if (ItemDefinitions.Count > 0) ItemDefinitions.Clear();
            }

            for (int i = 0; i < gearList.name.Length; i++)
            {
                ItemDefinitions.Add(new DnDItemDefinition("Gear", gearList.name[i], gearList.description[i], gearList.weight[i], gearList.cost[i]));
            }

            for (int i = 0; i < toolList.name.Length; i++)
            {
                ItemDefinitions.Add(new DnDItemDefinition("Tool", toolList.name[i], toolList.description[i], toolList.weight[i], toolList.cost[i]));
            }

            if(ArmorDefinitions != null)
            {
                if(ArmorDefinitions.Count > 0) ArmorDefinitions.Clear();
            }

            for(int i = 0; i < armorList.Length; i++)
            {
                for(int j = 0; j < armorList[i].name.Length; j++)
                {
                    ArmorDefinitions.Add(new DnDArmorDefinition("Armor", armorList[i].name[j], armorList[i].description[j], armorList[i].weight[j], armorList[i].cost[j], armorList[i].type, armorList[i].armor_class[j], armorList[i].strength[j], armorList[i].stealth[j]));
                }
            }

            if (WeaponDefinitions != null)
            {
                if (WeaponDefinitions.Count > 0) WeaponDefinitions.Clear();
            }

            for (int i = 0; i < weaponList.Length; i++)
            {
                for (int j = 0; j < weaponList[i].name.Length; j++)
                {
                    WeaponDefinitions.Add(new DnDWeaponDefinition("Weapon", weaponList[i].name[j], weaponList[i].description[j], weaponList[i].weight[j], weaponList[i].cost[j], weaponList[i].type, weaponList[i].damage[j], weaponList[i].properties[j]));
                }
            }
        }


        public void InitContentDatabase()
        {
            if (instance == null)
            {
                Debug.Log("Creating ContentDatabase instance");
            }
            else
            {
                LoadDefinitionsFromDatabase();
            }
        }

        #region monster_definitions

        public List<DnDCreatureDefinition> GetDnDMonsterDefinitions() { return MonsterDefinitions; }

        public DnDCreatureDefinition GetMonsterDefinitionByName(string name)
        {
            foreach (DnDCreatureDefinition definition in MonsterDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region item_definitions

        public List<DnDItemDefinition> GetDnDItemDefinitions() { return ItemDefinitions; }

        public DnDItemDefinition GetItemDefinitionByName(string name)
        {
            foreach (DnDItemDefinition definition in ItemDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region armor_definitions

        public List<DnDArmorDefinition> GetDnDArmorDefinitions() { return ArmorDefinitions; }

        public DnDArmorDefinition GetArmorDefinitionByName(string name)
        {
            foreach (DnDArmorDefinition definition in ArmorDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region weapon_definitions

        public List<DnDWeaponDefinition> GetDnDWeaponDefinitions() { return WeaponDefinitions; }

        public DnDWeaponDefinition GetWeaponDefinitionByName(string name)
        {
            foreach (DnDWeaponDefinition definition in WeaponDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region npc_definitions

        public List<DnDNPCDefinition> GetDnDNPCDefinitions() { return NPCDefinitions; }

        public DnDNPCDefinition GetNPCDefinitionByName(string name)
        {
            foreach (DnDNPCDefinition definition in NPCDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region location_definitions

        public List<DnDLocationDefinition> GetDnDLocationDefinitions() { return LocationDefinitions; }

        public DnDLocationDefinition GetLocationDefinitionByName(string name)
        {
            foreach (DnDLocationDefinition definition in LocationDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

        #region player_definitions

        public List<DnDPlayerDefinition> GetDnDPlayerDefinitions() { return PlayerDefinitions; }

        public DnDPlayerDefinition GetPlayerDefinitionByName(string name)
        {
            foreach (DnDPlayerDefinition definition in PlayerDefinitions)
            {
                if (definition.m_name == name) return definition;
            }
            return null;
        }

        #endregion

    }
}

