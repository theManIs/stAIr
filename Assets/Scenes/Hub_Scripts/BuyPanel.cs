using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class BuyPanel : BaseView
    {
        List<Unit> UnitsToSell => Bus.UnitsToSell.Value;
        List<IItem> ItemsToSell => Bus.ItemsToSell.Value;
        bool IsSold(object obj) => Bus.SoldItems.Value.Contains(obj);
        UnitButton[] unitButtons;
        WeaponButton[] itemButtons;

        public override void Init()
        {
            base.Init();

            unitButtons = new[] { pnUnit0, pnUnit1, pnUnit2, pnUnit3 };
            itemButtons = new[] { pnWeaponButton0, pnWeaponButton1, pnWeaponButton2, pnWeaponButton3, pnWeaponButton4, pnWeaponButton5, pnWeaponButton6, pnWeaponButton7 };
        }

        private void Start()
        {
            //subscribe buttons or events here
            Array.ForEach(unitButtons, b => b.Clicked += ShowUnitBuyPanel);
            Array.ForEach(itemButtons, b => b.Clicked += ShowItemBuyPanel);

            Bus.UnitsToSell.Subscribe(this, Rebuild);
            Bus.ItemsToSell.Subscribe(this, Rebuild);
            Bus.SoldItems.Subscribe(this, Rebuild);
        }

        private void ShowItemBuyPanel(IItem item)
        {
            BuyItemPanel.Close(noAnimation: true);
            BuyItemPanel.Build(item);
            BuyItemPanel.Show(this);
        }

        private void ShowUnitBuyPanel(Unit unit)
        {
            BuyUnitPanel.Close(noAnimation: true);
            BuyUnitPanel.Build(unit);
            BuyUnitPanel.Show(this);
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            for (int i=0; i < unitButtons.Length; i++)
                unitButtons[i].Build(UnitsToSell[i], !IsSold(UnitsToSell[i]));

            for (int i = 0; i < itemButtons.Length; i++)
                itemButtons[i].Build(ItemsToSell[i], !IsSold(ItemsToSell[i]));
        }
    }
}