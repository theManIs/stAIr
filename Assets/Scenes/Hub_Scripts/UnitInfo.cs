using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;

namespace Hub_UI
{
    partial class UnitInfo : BaseView
    {
        private void Start()
        {
            //subscribe buttons or events here
        }
        
        protected override void OnBuild(bool isFirstBuild)
        {
            //Data: Unit unit
            //copy data to UI controls here
            Set(txName, unit.Name);
            var faces = GameSettings.Instance.GameResources.Faces;
            Set(imIcon, faces[unit.IconIndex % faces.Length]);
            Set(txLevel, "Уровень: " + unit.Level);
            Set(txExp, unit.Experience.ToString("0.") + "/100");
            Set(txHealth, unit.Health.ToString("0."));
            Set(txenShield, unit.Shield.ToString("0."));
            Set(txSoul, unit.Soul.ToString("0."));
            Set(txFarFight, unit.FarFight.ToString("0."));
            Set(txNearFight, unit.NearFight.ToString("0."));
            Set(txAvoidance, unit.Avoidance.ToString("0."));
            Set(txCrit, unit.CriticalChance.ToString("0."));
            Set(txMoving, unit.Moving.ToString("0."));

            BuildTraitIcon(imTrait0, unit.Perks[0]);
            BuildTraitIcon(imTrait1, unit.Perks[1]);
            BuildTraitIcon(imTrait2, unit.Perks[2]);
        }

        private void BuildTraitIcon(Image im, Perk trait)
        {
            var tt = im.GetComponent<Tooltip>();
            tt.TextLeft = "<b>" + trait.Name + "</b>\r\n" + trait.Desc.Prepare();
        }
    }
}