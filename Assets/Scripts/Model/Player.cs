using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    class Player
    {
        public static Player Instance;

        /// <summary>Money</summary>
        public decimal Money { get; set; }

        /// <summary>Units of Player</summary>
        public List<Unit> Units { get; } = new List<Unit>();

        /// <summary>Items in storage</summary>
        public List<IItem> StorageItems { get; } = new List<IItem>();

        /// <summary>List of next missions. This field is generated after previous mission is completed.</summary>
        public Dictionary<MissionType, Mission> NextMissionsByTypes { get; } = new Dictionary<MissionType, Mission>();

        /// <summary>Is there any unit with module?</summary>
        public bool HasModule(string moduleName)
        {
            return Units.Any(u => u.Modules.Any(m => m.Name == moduleName));
        }

        static Player()
        {
            Instance = new Player();
        }

        public Player()
        {
            Database.InitPlayer(this);
            MissionsBuilder.Build(NextMissionsByTypes);
        }

        public int GetTotalItemsCount(IItem item)
        {
            var c1 = StorageItems.Count(i => i == item);
            var c2 = Units.Sum(u => u.Items.Count(i => i == item));

            return c1 + c2;
        }

        public int GetStorageItemsCount(IItem item)
        {
            return StorageItems.Count(i => i == item);
        }

        #region Buy/Sell

        public bool Buy(IItem item)
        {
            if (item.BuyPrice > Money)
                return false;

            StorageItems.Add(item);
            Money -= item.BuyPrice;

            Bus.PlayerStorageChanged += true;
            Bus.PlayerMoneyChanged += true;

            return true;
        }

        public bool Buy(Unit unit)
        {
            if (unit.BuyPrice > Money)
                return false;

            Units.Add(unit);
            Money -= unit.BuyPrice;

            Bus.PlayerUnitsChanged += true;
            Bus.PlayerMoneyChanged += true;

            return true;
        }

        public void SellFromStorage(IItem item)
        {
            //in storage?
            if (StorageItems.Contains(item))
            {
                //from storage
                StorageItems.Remove(item);
                Money += item.SellPrice;
                Bus.PlayerMoneyChanged += true;
                Bus.PlayerStorageChanged += true;
            }
        }

        public void SellFromSlot(Unit unit, IItem item, int slotIndex)
        {
            if (item is Armor armor) SellFromSlot(unit, unit.ArmorSlots, slotIndex);
            if (item is Module module) SellFromSlot(unit, unit.ModuleSlots, slotIndex);
            if (item is Weapon weapon) SellFromSlot(unit, unit.WeaponSlots, slotIndex);

        }

        private void SellFromSlot<T>(Unit unit, T[] items, int slotIndex) where T : IItem
        {
            if (slotIndex >= items.Length)
                return;
            var item = items[slotIndex];
            if (item == null)
                return;
            items[slotIndex] = default;
            Money += item.SellPrice;

            unit.RecalcAbilities();

            Bus.PlayerMoneyChanged += true;
            Bus.UnitSlotChanged += unit;
        }

        #endregion
    }
}