using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Race
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string description;
        [SerializeField]
        public string ability_score_bonus;
        [SerializeField]
        public string age;
        [SerializeField]
        public string alignment;
        [SerializeField]
        public string size;
        [SerializeField]
        public string speed;
        [SerializeField]
        public string[] languages;
        [SerializeField]
        public string[] subraces;
    }
}

