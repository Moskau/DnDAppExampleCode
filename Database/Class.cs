using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Class
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string hit_points;
        [SerializeField]
        public Proficiencies proficiencies;
        [SerializeField]
        public string[] equipment;
        [SerializeField]
        private string[][] features;
    }
}