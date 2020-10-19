using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitInfoPanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Unit unit
            //copy data to UI controls here
            //Set(imIcon, default);
            //Set(txName, unit.Name);
            pnUnitInfo.Build(unit);
            pnUnitInfo.Show(this);
        }
    }
}