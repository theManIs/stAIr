using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;
using System.Text.RegularExpressions;

namespace Hub_UI
{
    partial class ItemInfo : BaseView
    {
        [SerializeField] bool showPresentedCount;

        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            DestroyDynamicallyCreatedChildren();

            if (item == null)
                return;

            //Data: Model.IItem item
            //copy data to UI controls here
            Set(txName, item.Name.Prepare());
            Set(imIcon, GameSettings.Instance.GetIcon(item));
            Set(txRarity, Database.RarityToInfo[item.Rarity].Name);
            var itemCount = Player.Instance.GetTotalItemsCount(item);
            Set(txInStorage, "В xранилище: " + itemCount.ToString());
            SetActive(txInStorage, itemCount > 0 && showPresentedCount);
            if (item is Weapon w) BuildStats(w);
            if (item is Armor a) BuildStats(a);
            if (item is Module m) BuildStats(m);
        }

        private void BuildStats(Module m)
        {
        }

        private void BuildStats(Armor a)
        {
            if (!string.IsNullOrWhiteSpace(a.EffectDescription))
            foreach (var line in a.EffectDescription.SplitEffects())
                BuildStatLine(line, "", "");
        }

        private void BuildStats(Weapon w)
        {
            BuildStatLine("Урон", w.Damage, "Наносимый урон");
            if (w.Type != WeaponType.Sword)
            {
                BuildStatLine("Дальность", w.Range, "Дальнодействие оружия");
                BuildStatLine("Патроны", w.Capacity, "Емкость магазина");
            }

            if (!string.IsNullOrWhiteSpace(w.EffectDescription))
            foreach (var line in w.EffectDescription.SplitEffects())
                BuildStatLine(line, "", "");
        }

        private void BuildStatLine(string text, object val, string tooltip = "")
        {
            var statLine = Instantiate(StatLine);
            statLine.Build(text.Prepare(), val?.ToString(), tooltip.Prepare());
            statLine.Show(this);
        }
    }
}