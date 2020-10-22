using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    class Unit
    {
        public string Name { get; set; }
        public int IconIndex { get; set; }
        public int Level { get; set; } = 1;

        public float Experience { get; set; } = 0;

        public float Health { get; set; }
        public float Shield { get; set; }
        public float Soul { get; set; }
        public float FarFight { get; set; }
        public float NearFight { get; set; }
        public float Avoidance { get; set; }
        public float CriticalChance { get; set; }
        public float Moving { get; set; }
        public int BuyPrice { get; set; }

        public List<Perk> Perks { get; } = new List<Perk>();

        public IEnumerable<IItem> Items => 
            Armors.Cast<IItem>().Where(a => a != null).Union
            (Modules.Cast<IItem>().Where(a => a != null)).Union
            (Weapons.Cast<IItem>().Where(a => a != null));

        public Armor[] Armors { get; } = new Armor[1];
        public Module[] Modules { get; } = new Module[3];
        public Weapon[] Weapons { get; } = new Weapon[2];

        public Unit()
        {
            RecalcAbilities();
        }

        public void RecalcAbilities()
        {
            Database.InitUnit(this);

            //add perks
            Perks.Foreach(p => p.ApplyEffect?.Invoke(this));

            //add items effects
            Items.Foreach(i => i.ApplyEffect?.Invoke(this));
        }

        #region Add/remove item in slots

        public bool AddItemFromStorage(IItem item, int slotIndex)
        {
            if (!Player.Instance.StorageItems.Contains(item))
                return false;

            if (item is Armor armor) return ToSlot(Armors, armor, slotIndex);
            if (item is Module module) return ToSlot(Modules, module, slotIndex);
            if (item is Weapon weapon) return ToSlot(Weapons, weapon, slotIndex);

            return false;
        }

        private bool ToSlot<T>(T[] items, T item, int slotIndex) where T : IItem
        {
            if (slotIndex >= items.Length)
                return false;

            //remove from storage
            Player.Instance.StorageItems.Remove(item);

            //assign new item to slot
            var prev = items[slotIndex];
            items[slotIndex] = item;

            //return old item to storage (if was presented)
            if (prev != null)
                Player.Instance.StorageItems.Add(prev);

            RecalcAbilities();
            Bus.PlayerStorageChanged += true;
            Bus.UnitSlotChanged += this;

            return true;
        }

        public bool ChangeSlot(IItem item, int fromIndex, int toIndex)
        {
            if (fromIndex == toIndex)
                return false;

            if (item is Armor armor) return ChangeSlot(Armors, fromIndex, toIndex);
            if (item is Module module) return ChangeSlot(Modules, fromIndex, toIndex);
            if (item is Weapon weapon) return ChangeSlot(Weapons, fromIndex, toIndex);

            return false;
        }

        private bool ChangeSlot<T>(T[] items, int fromIndex, int toIndex) where T : IItem
        {
            if (fromIndex == toIndex || fromIndex >= items.Length || toIndex >= items.Length) return false;
            if (items[fromIndex] == null) return false;

            RemoveFromSlot(items, toIndex);
            items[toIndex] = items[fromIndex];
            items[fromIndex] = default;

            RecalcAbilities();
            Bus.UnitSlotChanged += this;
            return true;
        }

        public bool RemoveFromSlotToStorage(IItem item, int slotIndex)
        {
            if (!Items.Contains(item))
                return false;

            if (item is Armor armor) return RemoveFromSlot(Armors, slotIndex);
            if (item is Module module) return RemoveFromSlot(Modules, slotIndex);
            if (item is Weapon weapon) return RemoveFromSlot(Weapons, slotIndex);

            return false;
        }

        private bool RemoveFromSlot<T>(T[] items, int slotIndex) where T : IItem
        {
            if (slotIndex >= items.Length)
                return false;

            if (items[slotIndex] == null)
                return false;

            //move to storage
            Player.Instance.StorageItems.Add(items[slotIndex]);

            //null to slot
            items[slotIndex] = default;

            RecalcAbilities();
            Bus.PlayerStorageChanged += true;
            Bus.UnitSlotChanged += this;

            return true;
        }

        public void SwapWeapons()
        {
            var w0 = Weapons[0];
            Weapons[0] = Weapons[1];
            Weapons[1] = w0;

            Bus.UnitSlotChanged += this;
        }

        #endregion
    }
}