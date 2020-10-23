namespace Model
{
    partial class Database
    {
        static partial void Common()
        {
            InitRarity(Rarity.Usual, 89, "");
            InitRarity(Rarity.Rare, 10, "Редкое");
            InitRarity(Rarity.Unique, 1, "Уникальное");

            InitSupply(SupplyType.EnergyCore, 20, 10);
            InitSupply(SupplyType.Stimpack, 5, 40);
            InitSupply(SupplyType.AidKit, 5, 50);
            InitSupply(SupplyType.Stimulator, 5, 30);
        }
    }
}