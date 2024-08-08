using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Gear
    {
        [SerializeField]
        public string[] name;
        [SerializeField]
        public string[] description;
        [SerializeField]
        public string[] cost;
        [SerializeField]
        public string[] weight;
    }
}