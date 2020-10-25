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
            Armors.Cast<IItem>().Union
            (Modules.Cast<IItem>()).Union
            (Weapons.Cast<IItem>());

        public IEnumerable<Armor> Armors => ArmorSlots.Where(a => a != null);
        public IEnumerable<Module> Modules => ModuleSlots.Where(m => m != null);
        public IEnumerable<Weapon> Weapons => WeaponSlots.Where(w => w != null);

        public Armor[] ArmorSlots { get; } = new Armor[1];
        public Module[] ModuleSlots { get; } = new Module[3];
        public Weapon[] WeaponSlots { get; } = new Weapon[2];

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

            if (item is Armor armor) return ToSlot(ArmorSlots, armor, slotIndex);
            if (item is Module module) return ToSlot(ModuleSlots, module, slotIndex);
            if (item is Weapon weapon) return ToSlot(WeaponSlots, weapon, slotIndex);

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

            if (item is Armor armor) return ChangeSlot(ArmorSlots, fromIndex, toIndex);
            if (item is Module module) return ChangeSlot(ModuleSlots, fromIndex, toIndex);
            if (item is Weapon weapon) return ChangeSlot(WeaponSlots, fromIndex, toIndex);

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

            if (item is Armor armor) return RemoveFromSlot(ArmorSlots, slotIndex);
            if (item is Module module) return RemoveFromSlot(ModuleSlots, slotIndex);
            if (item is Weapon weapon) return RemoveFromSlot(WeaponSlots, slotIndex);

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
            var w0 = WeaponSlots[0];
            WeaponSlots[0] = WeaponSlots[1];
            WeaponSlots[1] = w0;

            Bus.UnitSlotChanged += this;
        }

        #endregion
    }
}