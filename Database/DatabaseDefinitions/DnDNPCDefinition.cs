using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDNPCDefinition : DnDContentDefinition
    {
        [SerializeField]
        public Creature m_creature;

        public DnDNPCDefinition(Creature creature, string name, string description, string campaignID, string system)
        {
            m_creature = creature;
            m_name = name;
            m_description = description;
            m_campaignIDs.Add(campaignID);
            m_system = system;
        }
    }
}
