using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDWeaponDefinition : DnDItemDefinition
    {
        [SerializeField]
        public string weaponType;
        [SerializeField]
        public string weaponDamage;
        [SerializeField]
        public string weaponProperties;

        public DnDWeaponDefinition(string itemType, string itemName, string itemDescription, string itemWeight, string itemCost, string weaponType, string weaponDamage, string weaponProperties) 
            : base(itemType, itemName, itemDescription, itemWeight, itemCost)
        {
            this.itemType = itemType;
            this.itemCost = itemCost;
            this.itemWeight = itemWeight;
            this.m_description = itemDescription;
            this.m_name = itemName;
            this.weaponType = weaponType;
            this.weaponDamage = weaponDamage;
            this.weaponProperties = weaponProperties;

            this.m_system = "DnD";
        }
    }
}


