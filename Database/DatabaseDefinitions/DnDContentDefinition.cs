using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class DnDContentDefinition
    {
        [SerializeField]
        public string m_name;
        [SerializeField]
        public List<string> m_campaignIDs = new List<string>();
        [SerializeField]
        public string m_description;
        [SerializeField]
        public string m_system;
    }
}