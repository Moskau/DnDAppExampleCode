using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDCreatureDefinition : DnDContentDefinition
    {
        [SerializeField]
        public Creature m_monster;

        public DnDCreatureDefinition(Creature monster, string system)
        {
            m_monster = monster;
            m_system = system;

            m_name = m_monster.name;
            m_description = m_monster.description;
        }
    }
}
