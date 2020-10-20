using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

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
            if (!Player.Instance.Buy(unit))
                return;

            Bus.SoldItems.Value.Add(unit);
            Bus.SoldItems.Publish(Bus.SoldItems.Value);

            Close();
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: UnitToSell unit
            //copy data to UI controls here
            UnitInfo.Build(unit);
            UnitInfo.Show(this);

            Set(btBuy,  "Купить - " + unit.BuyPrice.ToString("0."));
            SetInteractable(btBuy, unit.BuyPrice <= Player.Instance.Money);
        }
    }
}