using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class BuyPanel : BaseView
    {
        List<Unit> UnitsToSell => Bus.UnitsToSell.Value;

        private void Start()
        {
            //subscribe buttons or events here
            pnUnit0.Clicked += ShowUnitBuyPanel;
            pnUnit1.Clicked += ShowUnitBuyPanel;
            pnUnit2.Clicked += ShowUnitBuyPanel;
            pnUnit3.Clicked += ShowUnitBuyPanel;

            Bus.UnitsToSell.Subscribe(this, Rebuild);
        }

        private void ShowUnitBuyPanel(Unit unit)
        {
            BuyUnitPanel.Hide(noAnimation: true);
            BuyUnitPanel.Build(unit);
            BuyUnitPanel.Show(this);
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            pnUnit0.Build(UnitsToSell[0], !UnitsToSell[0].IsSold);
            pnUnit1.Build(UnitsToSell[1], !UnitsToSell[1].IsSold);
            pnUnit2.Build(UnitsToSell[2], !UnitsToSell[2].IsSold);
            pnUnit3.Build(UnitsToSell[3], !UnitsToSell[3].IsSold);
        }
    }
}