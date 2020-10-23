using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class SupplyBuy : BaseView
    {
        public SupplyInfo info => Database.SupplyToInfo[supplyType];
        public Action Changed;
        public int count;
        public SupplyType supplyType;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btAdd, () => { count++; Changed?.Invoke(); });
            Subscribe(btSub, () => { count--; Changed?.Invoke(); });

            Build();
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.Supply supply
            //copy data to UI controls here
            Set(txPrice, "$" + info.BuyPrice.ToString());
            Set(txCount, "x" + count.ToString());

            SetInteractable(btAdd, count < info.MaxCount);
            SetInteractable(btSub, count > 0);
        }
    }
}