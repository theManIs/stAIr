using System;

namespace Model
{
    /// <summary>Броня</summary>
    class Armor : IItem
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public string EffectDescription { get; set; }
        public Action<Unit> ApplyEffect { get; set; }

        public string Image => "Armor " + Id;

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ Id;
        }

        public override bool Equals(object obj)
        {
            var armor = obj as Armor;
            if (armor == null)
                return false;

            return Id == armor.Id;
        }
    }
}