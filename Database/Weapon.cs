using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Weapon
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
        public string[] damage;
        [SerializeField]
        public string[] weight;
        [SerializeField]
        public string[] properties;
    }
}


