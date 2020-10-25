using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    /// <summary>Отображение Item в окне продажи</summary>
    partial class WeaponButton : BaseView
    {
        [SerializeField] Sprite defaultIcon;
        public Action<IItem> Clicked;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(bt, () => Clicked(item));
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.IItem, bool isActive
            //copy data to UI controls here
            Set(bt, GameSettings.Instance.GetIcon(item));
            Set(txPrice, item.BuyPrice.ToString());
            SetInteractable(bt, isActive);

            GetComponent<Tooltip>().TextLeft = item.Name.Prepare();
        }
    }
}