using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;

namespace Hub_UI
{
    partial class UnitSlot : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Model.Unit unit
            //copy data to UI controls here
            SetActive(imBackground, unit == null);

            if (unit == null)
            {
                pnUnitInSlot.Close(noAnimation: true);
            }else
            {
                pnUnitInSlot.Build(unit);
                pnUnitInSlot.Show(this, noAnimation: true);
            }
        }

        public override bool CanDropIn(BaseView draggedView)
        {
            return draggedView is UnitButton;
        }

        public override void DropIn(BaseView draggedView)
        {
            unit = (draggedView as UnitButton)?.unit;
            StartMissionPanel.Instance.Rebuild();
            UnitsPanel.Instance.Rebuild();
            draggedView.Close();
            Destroy(draggedView.gameObject);

            base.DropIn(draggedView);
        }
    }
}