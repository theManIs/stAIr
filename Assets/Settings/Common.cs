namespace Model
{
    partial class Database
    {
        static partial void Common()
        {
            InitRarity(Rarity.Usual, 89, "");
            InitRarity(Rarity.Rare, 10, "Редкое");
            InitRarity(Rarity.Unique, 1, "Уникальное");
        }
    }
}