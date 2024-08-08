using DnD.Content;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DnD.UI
{
    public class UIHub : UIWindow
    {
        protected override bool CanBeClosedByBackButton { get { return true; } }

        public void InitDatabase() 
        {
            ContentDatabase.Instance.InitContentDatabase();
        }
    }
}

