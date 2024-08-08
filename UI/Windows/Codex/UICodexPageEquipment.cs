using DnD.Content;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UICodexPageEquipment : UICodexPage
    {
        [SerializeField]
        private RectTransform m_content;

        //Codex Page Header
        [SerializeField]
        private TextMeshProUGUI m_rarity;
        [SerializeField]
        private TextMeshProUGUI m_weightText;
        [SerializeField]
        private TextMeshProUGUI m_costText;

        //Codex Page Top
        [SerializeField]
        private GameObject m_goDamage;
        [SerializeField]
        private TextMeshProUGUI m_damageText;
        [SerializeField]
        private GameObject m_goArmor;
        [SerializeField]
        private TextMeshProUGUI m_armorText;
        [SerializeField]
        private TextMeshProUGUI m_stealthText;
        [SerializeField]
        private TextMeshProUGUI m_strengthText;

        //Codex Page Bottom
        [SerializeField]
        private TextMeshProUGUI m_properties;
        [SerializeField]
        private TextMeshProUGUI m_traits;

        [SerializeField]
        private Image m_image;

        private DnDItemDefinition m_itemDefinition;
        private DnDWeaponDefinition m_weaponDefinition;
        private DnDArmorDefinition m_armorDefinition;

        private const string URL_PATH = "https://www.aidedd.org/dnd/monstres.php?vo=";

        public override void UpdateCodexPage(DnDContentDefinition itemDefinition)
        {
            this.gameObject.SetActive(true);

            m_itemDefinition = itemDefinition as DnDItemDefinition;

            m_contentName.text = itemDefinition.m_name;
            m_contentDescription.text = itemDefinition.m_description;
            m_weightText.text = m_itemDefinition.itemWeight;
            m_costText.text = m_itemDefinition.itemCost;
           
            m_goArmor.SetActive(false); 
            m_goDamage.SetActive(false);
            m_rarity.gameObject.SetActive(false);
            m_properties.gameObject.SetActive(false);
            m_traits.gameObject.SetActive(false);
            m_stealthText.gameObject.SetActive(false);
            m_strengthText.gameObject.SetActive(false);

            m_image.sprite = Resources.Load<Sprite>(m_itemDefinition.itemType.ToString() + "/" + m_itemDefinition.m_name.Replace("’", "").Replace(" ","_"));

            if (m_itemDefinition != null )
            {
                if(m_itemDefinition.itemType == "Weapon")
                {
                    m_weaponDefinition = itemDefinition as DnDWeaponDefinition;

                    if (m_weaponDefinition != null)
                    {
                        m_goDamage.SetActive(true);
                        m_damageText.text = m_weaponDefinition.weaponDamage;

                        m_properties.gameObject.SetActive(true);
                        m_properties.text = m_weaponDefinition.weaponProperties;
                    }  
                }
                else if(m_itemDefinition.itemType == "Armor")
                {
                    m_armorDefinition = itemDefinition as DnDArmorDefinition;

                    if (m_armorDefinition != null)
                    {
                        m_goArmor.SetActive(true);
                        m_armorText.text = m_armorDefinition.armorClass;

                        m_properties.gameObject.SetActive(true);
                        m_properties.text = m_armorDefinition.armorType;

                        if(m_armorDefinition.armorStealthDisadvantage != "-")
                        {
                            m_stealthText.gameObject.SetActive(true);
                        }
                        if(m_armorDefinition.armorStrengthRequirement != "-")
                        {
                            m_strengthText.gameObject.SetActive(true);
                            m_strengthText.text = m_armorDefinition.armorStrengthRequirement;
                        }
                            
                    }
                }
            }

            RefreshLayoutGroupsImmediateAndRecursive(m_content.gameObject);
            LayoutRebuilder.ForceRebuildLayoutImmediate(m_content);
            Canvas.ForceUpdateCanvases();
        }

        public void OnInspect()
        {
            Application.OpenURL(URL_PATH + m_contentName.text);
        }

        public void OnBackButton()
        {
            this.gameObject.SetActive(false);
        }

        public void RefreshLayoutGroupsImmediateAndRecursive(GameObject root)
        {
            foreach (var layoutGroup in root.GetComponentsInChildren<LayoutGroup>())
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
            }
        }
    }
}


