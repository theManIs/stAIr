using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitButton : BaseView
    {
        public event Action<Unit> Clicked;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(bt, OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(unit);
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Unit unit
            //copy data to UI controls here
            Set(txName, unit.Name);
            var faces = GameSettings.Instance.GameResources.Faces;
            Set(bt, faces[unit.IconIndex % faces.Length]);
            SetInteractable(bt, isActive);
        }
    }
}