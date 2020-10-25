namespace Model
{
    partial class Database
    {
        /*ВНИМАНИЕ! Не меняйте порядок слотов, не удаляйте слоты! Это приведет к сбою в сохранениях игрока!*/
        static partial void Module()
        {
            AddModule("Граната", Rarity.Usual, 150, 30);
            AddModule("Генератор барьера", Rarity.Usual, 150, 30);
            AddModule("Взрывная мина", Rarity.Usual, 150, 30);
            AddModule("Прыжок", Rarity.Usual, 150, 30);
            AddModule("Указатель", Rarity.Usual, 150, 30);
            AddModule("Сеть", Rarity.Usual, 150, 30);
            AddModule("Генератор помех", Rarity.Usual, 150, 30);
            AddModule("Модуль невидимости", Rarity.Rare, 300, 60);
            AddModule("Модуль взлома", Rarity.Rare, 300, 60);
            AddModule("Модуль траектории", Rarity.Rare, 300, 60);
            AddModule("Модуль связи", Rarity.Rare, 300, 60);
            AddModule("Ракетный модуль", Rarity.Rare, 300, 60);
            AddModule("Огнемет", Rarity.Rare, 300, 60);
            AddModule("Парализующая мина", Rarity.Rare, 300, 60);
            AddModule("Дрон", Rarity.Unique, 600, 120);
            AddModule("Генератор молнии", Rarity.Unique, 600, 120);
            AddModule("Энергобатарея", Rarity.Unique, 600, 120);
            AddModule("Нейростимулятор", Rarity.Unique, 600, 120);
            AddModule("Лазерный барьер", Rarity.Unique, 600, 120);
        }
    }
}
