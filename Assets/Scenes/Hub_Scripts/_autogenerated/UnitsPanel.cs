/////////////////////////////////////////
//     THIS IS AUTOGENERATED CODE      //
//       do not change directly        //
/////////////////////////////////////////
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitsPanel : BaseView //Autogenerated
    {
        /// <summary>Static instance of the view</summary>
        public static UnitsPanel Instance { get; private set; }
        // Controls
        #pragma warning disable 0414
        //[Header("Controls (auto capture)")]
        [Header("Custom")]
        [AutoGenerated, SerializeField, HideInInspector] UnitButton UnitButton = default;
        [AutoGenerated, SerializeField, HideInInspector] UnitInfoPanel UnitInfoPanel = default;
        #pragma warning restore 0414
        
        public override void AutoSubscribe()
        {
            SubscribeOnChanged(UnitButton);
            SubscribeOnChanged(UnitInfoPanel);
        }
        
        [VisibleInGraph(false)]
        public void Build()
        {
            OnBuildSafe(true);
        }
    }
}