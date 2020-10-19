using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitsPanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Build();
            Bus.PlayerUnitsChanged.Subscribe(this, Rebuild).CallWhenInactive();
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            DestroyDynamicallyCreatedChildren();
            //
            foreach (var unit in Player.Instance.Units)
            {
                var view = Instantiate(UnitButton);
                view.gameObject.SetActive(true);
                view.Build(unit, true);
                view.Show(this);
                view.Clicked += (u) =>
                {
                    UnitInfoPanel.Build(u);
                    UnitInfoPanel.Show(this);
                };
            }
        }
    }
}