using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using System.Linq;
using Model;

namespace Hub_UI
{
    partial class StoragePanel : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
            Build();
            Subscribe(btSortByType, () => { currentSortMode = SortMode.ByType; Rebuild(); });
            Subscribe(btSortByPrice, () => { currentSortMode = SortMode.ByPrice; Rebuild(); });
        }

        private void OnBecameVisible()
        {
            Rebuild();
        }

        enum SortMode
        {
            ByType, ByPrice
        }

        SortMode currentSortMode;

        protected override void OnBuild(bool isFirstBuild)
        {
            //copy data to UI controls here
            DestroyDynamicallyCreatedChildren();

            var items = Player.Instance.StorageItems.Distinct();
            switch(currentSortMode)
            {
                case SortMode.ByType: items = SortByType(items); break;
                case SortMode.ByPrice: items = SortByPrice(items); break;
            }

            foreach (var item in items)
            {
                var bt = Instantiate(ItemButton);
                bt.Build(item, Player.Instance.GetStorageItemsCount(item), true);
                bt.Show(this);
            }
        }

        private IEnumerable<IItem> SortByPrice(IEnumerable<IItem> items)
        {
            return items.OrderBy(item =>
            {
                var res = 0;
                if (item is Armor armor) res = 0 - 100000 * armor.BuyPrice;
                if (item is Weapon weapon) res = 10 * ((int)weapon.Type + 1) - 100000 * weapon.BuyPrice;
                if (item is Module module) res = 1000 - 100000 * module.BuyPrice;
                return res;
            });
        }

        private IEnumerable<IItem> SortByType(IEnumerable<IItem> items)
        {
            return items.OrderBy(item =>
            {
                var res = 0;
                if (item is Armor armor) res = 0 - armor.BuyPrice;
                if (item is Weapon weapon) res = 10000 * ((int)weapon.Type + 1) - weapon.BuyPrice;
                if (item is Module module) res = 100000 - module.BuyPrice;
                return res;
            });
        }

        public override bool CanDropIn(BaseView draggedView)
        {
            return draggedView is ItemButton bt && bt.MySlot != null;
        }
    }
}