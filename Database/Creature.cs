using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Creature
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public string description;
        [SerializeField]
        public int armor_class;
        [SerializeField]
        public int hit_points;
        [SerializeField]
        public string Speed;
        [SerializeField]
        public string STR;
        [SerializeField]
        public string STR_mod;
        [SerializeField]
        public string DEX;
        [SerializeField]
        public string DEX_mod;
        [SerializeField]
        public string CON;
        [SerializeField]
        public string CON_mod;
        [SerializeField]
        public string INT;
        [SerializeField]
        public string INT_mod;
        [SerializeField]
        public string WIS;
        [SerializeField]
        public string WIS_mod;
        [SerializeField]
        public string CHA;
        [SerializeField]
        public string CHA_mod;
        [SerializeField]
        public string saving_throws;
        [SerializeField]
        public string Skills;
        [SerializeField]
        public string Senses;
        [SerializeField]
        public string Languages;
        [SerializeField]
        public string Challenge;
        [SerializeField]
        public string Traits;
        [SerializeField]
        public string Actions;
        [SerializeField]
        public string legendary_actions;
        [SerializeField]
        public string img_url;
    }
}


