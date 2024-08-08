using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDItemDefinition : DnDContentDefinition
    {
        [SerializeField]
        public string itemType;
        [SerializeField]
        public string itemWeight;
        [SerializeField]
        public string itemCost;

        public DnDItemDefinition(string itemType, string itemName, string itemDescription, string itemWeight, string itemCost)
        {
            this.itemType = itemType;
            this.itemCost = itemCost;
            this.itemWeight = itemWeight;
            this.m_description = itemDescription;
            this.m_name = itemName;

            this.m_system = "DnD";
        }
    }
}


