using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class Slot : BaseView
    {
        [SerializeField] string AllowedType;
        public int SlotIndex;

        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            SetActive(imBackground, item == null);

            DestroyDynamicallyCreatedChildren();

            pnHolder.GetComponent<GridLayoutGroup>().cellSize = RectTransform.sizeDelta;

            if (item != null)
            {
                var bt = Instantiate(ItemButton.Instance);
                bt.transform.SetParent(pnHolder.transform);
                bt.Build(item, 1, true);
                bt.Show(this);
            }
        }

        public override bool CanDropIn(BaseView draggedView)
        {
            return draggedView is ItemButton bt && bt.item?.GetType().Name == AllowedType;
        }
    }
}