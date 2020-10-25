using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using CometUI;
using Model;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Hub_UI
{
    partial class StartMissionPanel : BaseView
    {
        [SerializeField] AnimationLink UnitsPanelAnimation;
        [SerializeField] AnimationLink PrizePanelAnimation;
        UnitSlot[] unitSlots;
        SupplyBuy[] supplies;
        Toggle[] typeToggles;

        private void Start()
        {
            //subscribe buttons or events here
            Subscribe(btStart, StartMission);
        }

        Mission missionToStart;

        private void StartMission()
        {
            missionToStart = Player.Instance.NextMissionsByTypes[MissionType];
            Player.Instance.Money -= CalcSumPriceOfMission();
            Bus.PlayerMoneyChanged += true;
            Close();
            Dispatcher.Enqueue(() =>
            {
                Bus.CurrentMission.Publish(missionToStart);
                SceneManager.LoadScene("HexMapScene");
            }, 0.5f);
        }

        protected override void OnShown()
        {
            base.OnShown();
            UnitsPanel.Instance.UnitPanelMode = UnitsPanel.Mode.UnitForMission;
            UnitsPanel.Instance.Rebuild();
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            UnitsPanel.Instance.UnitPanelMode = UnitsPanel.Mode.UnitInfo;
            UnitsPanel.Instance.Rebuild();
        }

        protected override void OnBuild(bool isFirstBuild)
        {
            if (isFirstBuild)
            {
                unitSlots = new[] { pnUnitSlot0, pnUnitSlot1, pnUnitSlot2, pnUnitSlot3 };
                supplies = new[] { pnSupplyBuy0, pnSupplyBuy1, pnSupplyBuy2, pnSupplyBuy3 };
                typeToggles = new[] { tgShort, tgMiddle, tgLong, tgSpecial };

                foreach (var supp in supplies)
                    supp.Changed = () => Rebuild();

                foreach (var slot in unitSlots)
                    slot.Gestured += (gi) =>
                    {
                        if (gi.Gesture == Gesture.Tap)
                        {
                            gi.IsHandled = true;
                            OnSlotClicked(slot);
                        }
                    };

                InitToggle(tgShort, MissionType.Short);
                InitToggle(tgMiddle, MissionType.Middle);
                InitToggle(tgLong, MissionType.Long);
                InitToggle(tgSpecial, MissionType.Special);
            }

            //copy data to UI controls here
            foreach (var slot in unitSlots)
                slot.Build(slot.unit);

            //can start?
            var canStart = true;
            var price = CalcSumPriceOfMission();
            SetActive(txError, false);
            if (price > Player.Instance.Money) { canStart = false; Error("Не хватает кредитов для старта миссии"); }
            if (MissionType == MissionType.None) { canStart = false; Error("Не выбран тип миссии"); }
            if (!unitSlots.Any(s => s.unit != null)) { canStart = false; Error("Не выбраны бойцы"); }

            Set(btStart,  price > 0 ? "Высадка - " + price : "Высадка");
            SetInteractable(btStart, canStart);
              
            //build prizes
            if (MissionType == MissionType.None)
            {
                SetActive(pnPrizes, false);
                SetInteractable(btStart, false);
            } else
            {
                BuildMissionInterface(Player.Instance.NextMissionsByTypes[MissionType]);
            }
        }

        private void Error(string error)
        {
            SetActive(txError, true);
            Set(txError, error);
        }

        private void BuildMissionInterface(Mission mission)
        {
            SetActive(pnPrizes, true);
            var typeInfo = Database.MissionTypeInfos.FirstOrDefault(i => i.Type == MissionType);
            Set(txDescription, $"<b>Цель:</b> {mission.MissionGoal.Name}\r\n\r\n{mission.MissionDescription.Description.Prepare()}");
            var prize = mission.MissionGoal.Prize + typeInfo.Prize;
            Set(txPrizeDesc, $"<b>Награда:</b> +{prize}$\r\n{mission.MissionGoal.AddPrizeDescription} {typeInfo.AddPrizeDescription}".Trim().Prepare());

            if (mission.VisiblePrizeItems.Length > 0)
            {
                pnItemIcon0.Build(mission.VisiblePrizeItems[0], mission.VisiblePrizeItems.Length, true);
                pnItemIcon0.Show(this, noAnimation: true);
            }else
                pnItemIcon0.Close(noAnimation: true);

            if (mission.InvisiblePrizeItems.Length > 0)
            {
                pnItemIcon1.Build(null, mission.InvisiblePrizeItems.Length, true);
                pnItemIcon1.Show(this, noAnimation: true);
            }
            else
                pnItemIcon1.Close(noAnimation : true);
        }

        int CalcSumPriceOfMission()
        {
            var sum = 0;
            foreach (var supply in supplies)
                sum += supply.count * supply.info.BuyPrice;

            return sum;
        }

        private void InitToggle(Toggle tg, MissionType type)
        {
            tg.onValueChanged.AddListener((on) =>
            {
                Rebuild();
            });

            var info = Database.MissionTypeInfos.FirstOrDefault(i => i.Type == type);
            tg.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = info.Name;
        }

        MissionType MissionType
        {
            get {
                if (tgShort.isOn) return MissionType.Short;
                if (tgMiddle.isOn) return MissionType.Middle;
                if (tgLong.isOn) return MissionType.Long;
                if (tgSpecial.isOn) return MissionType.Special;
                return MissionType.None;
            }
        }

        public bool HasUnit(Unit unit)
        {
            return unitSlots.Any(u => u.unit == unit);
        }

        public bool AddUnitToSlot(Unit unit)
        {
            //find first empty slot
            for (int i=0;i<unitSlots.Length;i++)
            {
                if (unitSlots[i].unit == null)
                {
                    unitSlots[i].Build(unit);
                    Rebuild();
                    return true;
                }
            }

            return false;
        }

        private void OnSlotClicked(UnitSlot slot)
        {
            UnitsPanelAnimation.Animation.Play(UnitsPanel.Instance.RectTransform);
        }
    }
}