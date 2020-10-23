using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using System.Linq;
using Model;

namespace Hub_UI
{
    partial class UnitInfoPanel : BaseView
    {
        bool needRebuild;

        private void Start()
        {
            //subscribe buttons or events here
            Bus.PlayerStorageChanged.Subscribe(this, () => needRebuild = true);
            Bus.UnitSlotChanged.Subscribe(this, (u) => needRebuild = true).Condition(u => u == unit);
            Bus.ShowItemInfo.Subscribe(this, ShowItemInfo);
            Subscribe(btSwapWeapons, () => unit.SwapWeapons());
        }

        private void ShowItemInfo(IItem item)
        {
            if (pnItemInfo.item != item)
            {
                //pnItemInfo.ReopenAnimated(this, onCloseAnimationDone: () => pnItemInfo.Build(item));
                pnItemInfo.Close(noAnimation: true);
                pnItemInfo.Build(item);
                if (item != null)
                    pnItemInfo.Show(this);
            }
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            pnItemInfo.Build(null);
        }

        private void Update()
        {
            if (needRebuild)
            {
                needRebuild = false;
                Rebuild();
            }
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            if (isFirstBuild)
                pnItemInfo.Close();

            //Data: Unit unit
            //copy data to UI controls here
            //Set(imIcon, default);
            //Set(txName, unit.Name);
            pnUnitInfo.Build(unit);
            pnUnitInfo.Show(this);

            StoragePanel.Build();

            slArmor.Build(unit, unit.ArmorSlots[0]);
            slModule0.Build(unit, unit.ModuleSlots[0]);
            slModule1.Build(unit, unit.ModuleSlots[1]);
            slModule2.Build(unit, unit.ModuleSlots[2]);
            slWeapon0.Build(unit, unit.WeaponSlots[0]);
            slWeapon1.Build(unit, unit.WeaponSlots[1]);
        }
    }
}