using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.UI
{
    public class UIDashboard : UIWindow
    {
        protected override bool CanBeClosedByBackButton { get { return true; } }

        public void ShowCampaignWindow()
        {
            Manager.OpenWindow(eUIWindow.UICampaign.ToString(), true);
        }

        public void ShowCodexWindow()
        {
            Manager.OpenWindow(eUIWindow.UICodex.ToString(), true);
        }

        public void ShowHubWindow()
        {
            Manager.OpenWindow(eUIWindow.UIHub.ToString(), true);
        }

        public void ShowMapWindow()
        {
            Manager.OpenWindow(eUIWindow.UIMap.ToString(), true);
        }

        public void ShowInventoryWindow()
        {
            Manager.OpenWindow(eUIWindow.UIInventory.ToString(), true);
        }
    }
}

