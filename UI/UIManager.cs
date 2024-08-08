using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DnD.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private List<UIWindow> m_windows = new List<UIWindow>();

        [SerializeField]
        private UIBackground m_background = null;
        [SerializeField]
        private UITopBar m_topBar = null;
        [SerializeField]
        private UIHub m_hub = null;

        public UIBackground Background { get { return m_background; } }
        public UITopBar TopBar {  get { return m_topBar; } }
        public UIHub HudWindow { get { return m_hub; } }

        public UnityAction<string> onMenuShown;

#region private_methods

        // Start is called before the first frame update
        private void Awake()
        {

        }

        private void LateAwake()
        {
            OpenInitWindow();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void OpenInitWindow()
        {
            OpenWindow(eUIWindow.UIHub.ToString(), true);
        }

#endregion

#region public_methods

        public static T GetUIWindow<T>() where T : UIWindow
        {
            UIManager manager = GameObject.FindObjectOfType<UIManager>();

            if (manager != null)
            {
                var menu = manager.FindWindow<T>();
                if(menu != null)
                {
                    return menu as T;
                }
            }

            return null;
        }

        public string[] GetWindowNames()
        {
            if(m_windows.Count == 0) return null;

            string[] menuNames = new string[m_windows.Count];

            for(int i = 0 ; i < m_windows.Count; i++)
            {
                menuNames[i] = m_windows[i].name;
            }
            return menuNames;
        }

        public T FindWindow<T>() where T : UIWindow
        {
            for(int i = 0; i < m_windows.Count; ++i)
            {
                if (m_windows[i].GetType() == typeof(T)) return m_windows[i] as T;
            }

            return null;
        }

        public UIWindow FindWindow(string aWindowName)
        {
            for (int i = 0 ;i < m_windows.Count ; ++i)
            {
                if (m_windows[i].name == aWindowName) return m_windows[i];
            }

            return null;
        }

        public void OpenWindow(UIWindow aWindow, bool aCloseAllWindows)
        {
            if (aCloseAllWindows)
            {
                CloseAllActiveWindows();
            }

            if (!aWindow.gameObject.activeSelf)
            {
                aWindow.Open();
            }
        }

        public void OpenWindow(string windowName, bool aCloseAllWindows)
        {
            UIWindow newMenu = FindWindow(windowName);

            if (aCloseAllWindows)
            {
                CloseAllActiveWindows();
            }

            if(newMenu != null)
            {
                OpenWindow(newMenu, aCloseAllWindows);
            }
        }

        public void CloseAllActiveWindows()
        {
            foreach (UIWindow window in m_windows)
            {
                if (window.CanBeClosed)
                {
                    window.Close();
                } 
            }
        }

        public void SetAllWindowsActive(bool aActive)
        {
            foreach(UIWindow window in m_windows)
            {
                if(window.CanBeClosed)
                    window.gameObject.SetActive(aActive);
            }
        }

#endregion

    }
}

