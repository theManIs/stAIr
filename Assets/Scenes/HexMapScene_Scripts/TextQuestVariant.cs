using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace HexMapScene_UI
{
    partial class TextQuestVariant : BaseView
    {
        public Action Clicked;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(bt, Clicked);
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: QuestVariant variant
            //copy data to UI controls here
            Set(tx, variant.Description);
        }
    }
}