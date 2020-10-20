namespace Model
{
    /// <summary>Модуль</summary>
    class Module : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        //public string EffectDescription { get; set; }
        //public Action<Unit> ApplyEffect { get; set; }

        public string Image => "Module " + Id;

        public override int GetHashCode()
        {
            return GetType().GetHashCode() ^ Id;
        }

        public override bool Equals(object obj)
        {
            var module = obj as Module;
            if (module == null)
                return false;

            return Id == module.Id;
        }
    }
}