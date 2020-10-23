using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitInSlot : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.Unit unit
            //copy data to UI controls here
            Set(txName, unit.Name);
            Set(imFace, GameSettings.Instance.GetFace(unit.IconIndex));
        }
    }
}