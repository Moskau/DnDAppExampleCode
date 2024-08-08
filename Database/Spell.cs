using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Spell
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string[] description;
        [SerializeField]
        public string[] deity;
        [SerializeField]
        public string[] alignment;
        [SerializeField]
        public string[] domains;
        [SerializeField] 
        public string[] symbol;
        [SerializeField]
        public string[] img_url;
    }
}


