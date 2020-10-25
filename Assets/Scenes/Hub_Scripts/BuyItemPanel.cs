using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class BuyItemPanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btBuy, OnBuy);
        }

        private void OnBuy()
        {
            if (!Player.Instance.Buy(item))
                return;

            Bus.SoldItems.Value.Add(item);
            Bus.SoldItems.Publish(Bus.SoldItems.Value);

            Close();
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.IItem item
            //copy data to UI controls here
            ItemInfo.Build(item);
            ItemInfo.Show(this);
            Set(btBuy, "Купить - " + item.BuyPrice.ToString("0."));
            SetInteractable(btBuy, item.BuyPrice <= Player.Instance.Money);
        }
    }
}