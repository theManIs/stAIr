using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class SellSlot : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            //Set(imBackground, default);
        }

        public override bool CanDropIn(BaseView draggedView)
        {
            return draggedView is ItemButton bt;
        }
    }
}