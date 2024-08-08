using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.Content
{
    [Serializable]
    public class Container
    {
        [SerializeField]
        private string[] name;
        [SerializeField]
        private string[] capacity;
    }
}