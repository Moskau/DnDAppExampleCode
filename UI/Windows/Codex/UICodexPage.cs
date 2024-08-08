using DnD.Content;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UICodexPage : MonoBehaviour
    {
        //Codex Page Header
        [SerializeField]
        protected TextMeshProUGUI m_contentName;

        [SerializeField]
        protected TextMeshProUGUI m_contentDescription;

        public virtual void UpdateCodexPage(DnDContentDefinition contentDefinition)
        {

        }

        public virtual void InspectContent()
        {

        }
    }
}


