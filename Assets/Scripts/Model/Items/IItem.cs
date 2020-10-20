namespace Model
{
    interface IItem
    {
        int Id { get; }
        string Image { get; }
        string Name { get; }
        Rarity Rarity { get; }
        int BuyPrice { get; }
        int SellPrice { get; }
    }
}