using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class StatLine : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: string text, string value, string tooltip
            //copy data to UI controls here
            Set(txName, text);
            Set(txValue, value);
            GetComponent<Tooltip>().TextLeft = tooltip.Prepare();
        }
    }
}