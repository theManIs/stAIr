using System;

namespace Model
{
    class Weapon
    {
        public int Id;
        public WeaponType Type;
        public string Name;
        public Rarity Rarity;
        public int Damage;
        public int Range;
        public int Capacity;
        public int BuyPrice;
        public int SellPrice;

        public string EffectDescription;
        public Action<Unit> ApplyEffect;
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