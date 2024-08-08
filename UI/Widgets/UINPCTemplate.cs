using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DnD.UI
{
    public class UINPCTemplate : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_name;

        public void InitTemplate(string name)
        {
            m_name.text = name;
        }
    }
}