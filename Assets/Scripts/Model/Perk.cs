using System;

namespace Model
{
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