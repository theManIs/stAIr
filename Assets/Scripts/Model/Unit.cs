using System.Collections.Generic;

namespace Model
{
    class Unit
    {
        public string Name;
        public int IconIndex;
        public int Level = 80;

        public float Experience = 0;
        public float Health = 5;
        public float Shield = 5;
        public float Soul = 5;
        public float FarFight = 5;
        public float NearFight = 5;
        public float Avoidance = 5;
        public float CriticalChance = 5;
        public float Moving = 5;

        public float Price;
        public bool IsSold;

        public List<Perk> Perks = new List<Perk>();
        public List<Weapon> Weapons = new List<Weapon>();
        public List<Armor> Armors = new List<Armor>();
        public List<Module> Modules = new List<Module>();
    }
}