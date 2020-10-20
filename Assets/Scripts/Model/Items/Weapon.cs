using System;

namespace Model
{
    class Weapon : IItem
    {
        public int Id { get; set; }
        public WeaponType Type { get; set; }
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public int Capacity { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public string EffectDescription { get; set; }
        public Action<Unit> ApplyEffect { get; set; }

        public string Image => Type + " " + Id;

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ Id ^ (10000 * Type.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            var weapon = obj as Weapon;
            if (weapon == null)
                return false;

            return Id == weapon.Id && Type == weapon.Type;
        }
    }

    /// <summary>Редкость</summary>
    enum Rarity
    {
        /// <summary>Обычная</summary>
        Usual,
        /// <summary>Редкая</summary>
        Rare,
        /// <summary>Уникальная</summary>
        Unique
    }

    class RarityInfo
    {
        public float Chance = 100;
        public string Name = "";
    }

    enum WeaponType
    {
        /// <summary>Пистолет</summary>
        Pistol,
        /// <summary>Дробовик</summary>
        Gun,
        /// <summary>Автомат</summary>
        Rifle,
        /// <summary>Снайперка</summary>
        SniperRifle,
        /// <summary>Меч</summary>
        Sword
    }
}