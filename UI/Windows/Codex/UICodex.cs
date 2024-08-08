using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DnD.Content;


namespace DnD.UI
{
    public class UICodex : UIWindow
    {
        protected override bool CanBeClosedByBackButton { get { return true; } }

        [SerializeField]
        private UIMonsterTemplate m_monsterTemplate;
        [SerializeField]
        private UIItemTemplate m_itemTemplate;
        [SerializeField]
        private UINPCTemplate m_npcTemplate;

        [SerializeField]
        private GameObject m_goListMonsters;
        [SerializeField]
        private GameObject m_goListItems;
        [SerializeField]
        private GameObject m_goListNPCs;
        [SerializeField]
        private GameObject m_goListArmor;
        [SerializeField]
        private GameObject m_goListWeapons;

        [SerializeField]
        private Toggle m_togMonsters;
        [SerializeField]
        private Toggle m_togItems;
        [SerializeField]
        private Toggle m_togNPCs;
        [SerializeField]
        private Toggle m_togArmor;
        [SerializeField]
        private Toggle m_togWeapons;
        [SerializeField]
        private ToggleGroup m_codexFilters;

        [SerializeField]
        private UICodexPageMonster m_pageMonster;
        [SerializeField]
        private UICodexPageEquipment m_pageEquipment;

        private enum FilterType
        {
            monster,
            item,
            weapon,
            armor,
            npc,
            location,
            all
        }

        // Start is called before the first frame update
        void Start()
        {
            ChangeCodexList();
            LoadContent(FilterType.monster);
        }

        private void LoadContent(FilterType filterType)
        {
            if(filterType == FilterType.monster || filterType == FilterType.all) 
            {
                foreach (DnDCreatureDefinition monsterDefinition in ContentDatabase.Instance.GetDnDMonsterDefinitions())
                {
                    UIMonsterTemplate monsterTemplate = Instantiate(m_monsterTemplate);
                    monsterTemplate.InitTemplate(monsterDefinition.m_name, monsterDefinition.m_monster.Challenge);
                    monsterTemplate.transform.SetParent(m_goListMonsters.transform, false);
                    monsterTemplate.ItemButton.onClick.AddListener(() => { LoadCodexPage(monsterDefinition.m_name, filterType); });
                }
            }

            if (filterType == FilterType.item || filterType == FilterType.all)
            {
                foreach (DnDItemDefinition itemDefinition in ContentDatabase.Instance.GetDnDItemDefinitions())
                {
                    UIItemTemplate itemTemplate = Instantiate(m_itemTemplate);
                    itemTemplate.InitTemplate(itemDefinition.m_name, itemDefinition.itemType);
                    itemTemplate.transform.SetParent(m_goListItems.transform, false);
                    itemTemplate.ItemButton.onClick.AddListener(() => { LoadCodexPage((string)itemDefinition.m_name, filterType); });
                }
            }
            if (filterType == FilterType.armor || filterType == FilterType.all)
            {
                foreach (DnDArmorDefinition armorDefinition in ContentDatabase.Instance.GetDnDArmorDefinitions())
                {
                    UIItemTemplate itemTemplate = Instantiate(m_itemTemplate);
                    itemTemplate.InitTemplate(armorDefinition.m_name, armorDefinition.itemType);
                    itemTemplate.transform.SetParent(m_goListArmor.transform, false);
                    itemTemplate.ItemButton.onClick.AddListener(() => { LoadCodexPage((string)armorDefinition.m_name, filterType); });
                }
            }

            if (filterType == FilterType.weapon || filterType == FilterType.all)
            {
                foreach (DnDWeaponDefinition weaponDefinition in ContentDatabase.Instance.GetDnDWeaponDefinitions())
                {
                    UIItemTemplate itemTemplate = Instantiate(m_itemTemplate);
                    itemTemplate.InitTemplate(weaponDefinition.m_name, weaponDefinition.itemType);
                    itemTemplate.transform.SetParent(m_goListWeapons.transform, false);
                    itemTemplate.ItemButton.onClick.AddListener(() => { LoadCodexPage((string)weaponDefinition.m_name, filterType); });
                }
            }

            if (filterType == FilterType.npc || filterType == FilterType.all)
            {
                foreach (DnDNPCDefinition npcDefinition in ContentDatabase.Instance.GetDnDNPCDefinitions())
                {
                    UINPCTemplate npcTemplate = Instantiate(m_npcTemplate);
                    npcTemplate.InitTemplate(npcDefinition.m_name);
                    npcTemplate.transform.SetParent(m_goListNPCs.transform, false);
                }
            } 
        }

        private void LoadCodexPage(string name, FilterType filter)
        {
            switch (filter)
            {
                case FilterType.item:
                    m_pageEquipment.UpdateCodexPage(ContentDatabase.Instance.GetItemDefinitionByName(name));
                    break;
                case FilterType.armor:
                    m_pageEquipment.UpdateCodexPage(ContentDatabase.Instance.GetArmorDefinitionByName(name));
                    break;
                case FilterType.weapon:
                    m_pageEquipment.UpdateCodexPage(ContentDatabase.Instance.GetWeaponDefinitionByName(name));
                    break;
                case FilterType.npc:
                case FilterType.monster:
                    m_pageMonster.UpdateCodexPage(ContentDatabase.Instance.GetMonsterDefinitionByName(name));
                    break;
                case FilterType.location: 
                    break;
            }
            //Refresh Canvas
        }

        private void ChangeCodexList()
        {
            m_goListMonsters.SetActive(m_togMonsters.isOn);
            m_goListItems.SetActive(m_togItems.isOn);
            m_goListNPCs.SetActive(m_togNPCs.isOn);
            m_goListWeapons.SetActive(m_togWeapons.isOn);
            m_goListArmor.SetActive(m_togArmor.isOn);
        }

        public void RefreshCodexList()
        {
            //LoadContent();
        }

        public void OnMonsterToggle()
        {
            ChangeCodexList();
            if (m_goListMonsters.GetComponentsInChildren<Transform>(true).Length <= 1)
            {
                LoadContent(FilterType.monster);
            }
        }

        public void OnItemToggle() 
        {
            ChangeCodexList();
            if(m_goListItems.GetComponentsInChildren<Transform>(true).Length <= 1) 
            {
                LoadContent(FilterType.item);
            }
        }

        public void OnWeaponToggle()
        {
            ChangeCodexList();
            if (m_goListWeapons.GetComponentsInChildren<Transform>(true).Length <= 1)
            {
                LoadContent(FilterType.weapon);
            }
        }

        public void OnArmorToggle()
        {
            ChangeCodexList();
            if (m_goListArmor.GetComponentsInChildren<Transform>(true).Length <= 1)
            {
                LoadContent(FilterType.armor);
            }
        }

        public void OnNPCToggle() 
        {
            ChangeCodexList();
            if (m_goListNPCs.GetComponentsInChildren<Transform>(true).Length <= 1)
            {
                LoadContent(FilterType.npc);
            }
        }   
    }
}

