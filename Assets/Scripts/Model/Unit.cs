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

        public List<IItem> Items { get; } = new List<IItem>();

        public IEnumerable<Weapon> Weapons => Items.OfType<Weapon>();
        public IEnumerable<Armor> Armors => Items.OfType<Armor>();
        public IEnumerable<Module> Modules => Items.OfType<Module>();

        public Unit()
        {
            Database.InitUnit(this);
        }
    }
}