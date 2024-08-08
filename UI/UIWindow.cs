using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DnD.UI
{
    public abstract class UIWindow : MonoBehaviour
    {
        [SerializeField]
        private bool m_canBeClosed = false;
        public bool CanBeClosed { get { return m_canBeClosed; } }

        protected abstract bool CanBeClosedByBackButton { get; }

        protected static bool m_isAppQuitting = false;

        private UIManager m_manager = null;

        public UIManager Manager
        {
            get
            {
                if (m_manager == null)
                {
                    Transform parent = transform.parent;
                    while (parent != null && m_manager == null)
                    {
                        m_manager = parent.GetComponent<UIManager>();
                        parent = parent.parent;
                    }

                    if (m_manager == null)
                    {
                        Debug.LogError("Parent does not have a UI manager");
                    }
                }

                return m_manager;
            }
        }

        private void OnEnable()
        {
            OnEnableImplied();
        }

        private void OnDisable()
        {
            OnDisableImplied();
        }

        protected virtual void OnEnableImplied() { }

        protected virtual void OnDisableImplied() { }

        public void Close()
        {
            gameObject.SetActive(false);
            OnMenuClose();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            OnMenuOpen();
        }

        protected virtual void OnMenuOpen()
        {

        }

        protected virtual void OnMenuClose()
        {

        }

        public virtual void OnDeviceClose()
        {
            Close();
        }

        protected void ForceUpdateUI()
        {
            var rectTrans = GetComponent<RectTransform>();
            if (rectTrans != null)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(rectTrans);
            }
        }
    }
}

