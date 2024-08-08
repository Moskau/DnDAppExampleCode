using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UIMonsterTemplate : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_name;
        [SerializeField]
        private TextMeshProUGUI m_challengeRating;
        [SerializeField]
        private Button m_itemButton;

        public Button ItemButton { get { return m_itemButton; } }

        public void InitTemplate(string name, string challengeRating)
        {
            m_name.text = name;
            m_challengeRating.text = challengeRating;
        }
    }
}