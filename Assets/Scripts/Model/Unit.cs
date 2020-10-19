using System;
using System.Collections.Generic;

namespace Model
{
    class Units : List<Unit>
    {
    }


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

        public decimal Price;
        public bool IsSold;
        public List<Perk> Perks = new List<Perk>();
    }

    class Perk
    {
        public int Id;
        public string Name;
        public string Desc;
        public string IconName => "Perk " + Id;
        public int Group;
        public Action<Unit> ApplyEffect;

        public Perk(int id, string name, string desc, int group, Action<Unit> effect)
        {
            Id = id;
            Name = name;
            Desc = desc;
            Group = group;
            ApplyEffect = effect;
        }

    }
}