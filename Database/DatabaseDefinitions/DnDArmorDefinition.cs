using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDArmorDefinition : DnDItemDefinition
    {
        [SerializeField]
        public string armorType;
        [SerializeField]
        public string armorClass;
        [SerializeField]
        public string armorStrengthRequirement;
        [SerializeField]
        public string armorStealthDisadvantage;

        public DnDArmorDefinition(string itemType, string itemName, string itemDescription, string itemWeight, string itemCost, string armorType, string armorClass, string armorStrengthRequirement, string armorStealthDisadvantage) 
            : base(itemType, itemName, itemDescription, itemWeight, itemCost)
        {
            this.itemType = itemType;
            this.itemCost = itemCost;
            this.itemWeight = itemWeight;
            this.m_description = itemDescription;
            this.m_name = itemName;
            this.armorType = armorType;
            this.armorClass = armorClass;
            this.armorStrengthRequirement = armorStrengthRequirement;
            this.armorStealthDisadvantage = armorStealthDisadvantage;

            this.m_system = "DnD";
        }
    }
}


