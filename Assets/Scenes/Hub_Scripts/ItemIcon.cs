using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class ItemIcon : BaseView
    {
        [SerializeField] Sprite Empty;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(bt, () => {;});
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.IItem item, int count, bool isActive
            //copy data to UI controls here
            Set(txCount, count.ToString());
            SetActive(imCountCircle, count > 1);
            SetInteractable(bt, isActive);
            Set(bt, item == null ? Empty : GameSettings.Instance.GetIcon(item));
            GetComponentInChildren<Tooltip>().TextLeft = item == null ? "" : item.Name.Prepare();
        }
    }
}