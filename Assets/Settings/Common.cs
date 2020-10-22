namespace Model
{
    partial class Database
    {
        static partial void Common()
        {
            InitRarity(Rarity.Usual, 89, "");
            InitRarity(Rarity.Rare, 10, "Редкое");
            InitRarity(Rarity.Unique, 1, "Уникальное");

            InitSupply(SupplyType.EnergyCore, 10);
            InitSupply(SupplyType.Stimpack, 40);
            InitSupply(SupplyType.AidKit, 50);
            InitSupply(SupplyType.Stimulator, 30);
        }
    }
}