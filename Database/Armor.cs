using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Armor
    {
        [SerializeField]
        public string type;
        [SerializeField]
        public string[] name;
        [SerializeField]
        public string[] description;
        [SerializeField] 
        public string[] cost;
        [SerializeField]
        public string[] armor_class;
        [SerializeField] 
        public string[] strength;
        [SerializeField]
        public string[] stealth;
        [SerializeField]
        public string[] weight;
    }
}


