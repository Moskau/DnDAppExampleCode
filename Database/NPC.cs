using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class NPC
    {
        [SerializeField]
        public string[] spells;
        [SerializeField]
        public string[] equipment;
        [SerializeField]
        public int challenge_rating;
    }
}

