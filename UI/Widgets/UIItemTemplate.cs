using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UIItemTemplate : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_name;
        [SerializeField]
        private TextMeshProUGUI m_itemType;
        [SerializeField]
        private Button m_itemButton;

        public Button ItemButton { get { return m_itemButton; } }

        public void InitTemplate(string name, string itemType)
        {
            m_name.text = name;
            m_itemType.text = itemType;
        }
    }
}