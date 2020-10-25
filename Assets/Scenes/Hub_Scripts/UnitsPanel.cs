using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class UnitsPanel : BaseView
    {
        public Mode UnitPanelMode;

        public enum Mode
        {
            UnitInfo, UnitForMission
        }

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
                var isActive = true;

                if (UnitPanelMode == Mode.UnitForMission && StartMissionPanel.Instance.HasUnit(unit))
                    isActive = false;

                var view = Instantiate(UnitButton);
                //view.gameObject.SetActive(true);
                view.Build(unit, isActive);
                view.Show(this);
                view.DragMode = UnitPanelMode == Mode.UnitForMission && isActive ? DragMode.Move : DragMode.None;
                view.Clicked += (u) =>
                {
                    if (UnitPanelMode == Mode.UnitInfo)
                    {
                        UnitInfoPanel.Build(u);
                        UnitInfoPanel.Show(this);
                    }
                    if (UnitPanelMode == Mode.UnitForMission && isActive)
                    {
                        StartMissionPanel.Instance.AddUnitToSlot(u);
                        Rebuild();
                    }
                };
            }
        }

        public override bool CanDropIn(BaseView draggedView)
        {
            return draggedView is UnitInSlot;
        }

        public override bool ConfirmDropIn(BaseView draggedView)
        {
            if (draggedView is UnitInSlot)
            {
                var slot = draggedView.Owner as UnitSlot;
                slot.Build(null);
                StartMissionPanel.Instance.Rebuild();
                Rebuild();
                draggedView.gameObject.SetActive(false);

                return false;
            }

            return true;
        }
    }
}