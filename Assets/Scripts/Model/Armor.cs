using System;

namespace Model
{
    /// <summary>Броня</summary>
    class Armor
    {
        public int Id;
        public int GroupId;
        public string Name;
        public Rarity Rarity;
        public int BuyPrice;
        public int SellPrice;

        public string EffectDescription;
        public Action<Unit> ApplyEffect;
    }
}