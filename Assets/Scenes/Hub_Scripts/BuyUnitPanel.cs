using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class BuyUnitPanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btBuy, OnBuy);
        }

        private void OnBuy()
        {
            unit.IsSold = true;
            Bus.UnitsToSell.Publish(Bus.UnitsToSell.Value);
            Bus.Units.Value.Add(unit);
            Bus.Units.Publish(Bus.Units);
            Close();
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: UnitToSell unit
            //copy data to UI controls here
            UnitInfo.Build(unit);
            UnitInfo.Show(this);
        }
    }
}