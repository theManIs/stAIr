namespace Model
{
    partial class Database
    {
        /*ВНИМАНИЕ! Не меняйте порядок слотов, не удаляйте слоты! Это приведет к сбою в сохранениях игрока!*/
        static partial void Weapon()
        {
            AddPistol("Пистолет “Гарпия I”", Rarity.Usual, 2, 6, 2, 100, 20);
            AddPistol("Скорострельный пистолет “Медуза”", Rarity.Rare, 2, 6, 4, 200, 40);
            AddPistol("Пистолет “Тритон”", Rarity.Rare, 3, 6, 3, 200, 40, "-2 дальний бой", u => u.FarFight -= 2);
            AddPistol("Плазменный резак “Сатир II”", Rarity.Rare, 4, 6, 1, 200, 40, "+1 шанс крита", u => u.CriticalChance += 1);
            AddPistol("Пистолет “Гарпия II”", Rarity.Unique, 4, 6, 3, 400, 80, "+1 дальний бой", u => u.FarFight += 1);

            AddGun("Дробитель частиц “Мантикора I”", Rarity.Usual, 4, 4, 1, 150, 30);
            AddGun("Дробовик “Цербер I”", Rarity.Usual, 3, 4, 2, 150, 30);
            AddGun("Дробовик “Харибда”", Rarity.Rare, 5, 4, 1, 300, 60, "+1 шанс крита", u => u.CriticalChance += 1);
            AddGun("Дробовик “Цербер II”", Rarity.Rare, 4, 4, 2, 300, 60);
            AddGun("Дробитель частиц “Мантикора II”", Rarity.Unique, 5, 4, 3, 600, 120, "-1 передвижения", u => u.Moving -= 1);

            AddRifle("Автомат “Пегас I”", Rarity.Usual, 2, 8, 4, 200, 40);
            AddRifle("Автомат “Химера”", Rarity.Usual, 3, 8, 5, 200, 40, "-2 дальний бой", u => u.FarFight -= 2);
            AddRifle("Автомат “Пегас II”", Rarity.Rare, 3, 8, 4, 400, 80);
            AddRifle("Миниган “Гидра I”", Rarity.Rare, 4, 8, 6, 500, 100, "-2 дальний бой -1 передвижение", u => { u.FarFight -= 2; u.Moving -= 1; });
            AddRifle("Автомат “Пегас III”", Rarity.Unique, 4, 8, 4, 700, 140);
            AddRifle("Миниган “Гидра II”", Rarity.Unique, 6, 8, 6, 800, 160, "-2 дальний бой -2 передвижения", u => { u.FarFight -= 2; u.Moving -= 2; });

            AddSniperRifle("Снайперская винтовка “Титан I”", Rarity.Usual, 3, 10, 2, 200, 40, "-1 передвижения -1 уклонения", u => { u.Moving -= 1; u.Avoidance -= 1; });
            AddSniperRifle("Ускоритель частиц “Дракайн I”", Rarity.Usual, 2, 10, 2, 200, 40);
            AddSniperRifle("Снайперская винтовка “Циклоп”", Rarity.Rare, 5, 10, 1, 400, 80);
            AddSniperRifle("Ускоритель частиц “Дракайн II”", Rarity.Rare, 3, 10, 2, 400, 80, "+1 шанс крита", u => u.CriticalChance += 1);
            AddSniperRifle("Снайперская винтовка “Титан II”", Rarity.Unique, 5, 10, 2, 800, 160, "-2 передвижения -2 уклонения", u => { u.Moving -= 2; u.Avoidance -= 2; });
            AddSniperRifle("Ускоритель частиц “Дракайн III”", Rarity.Unique, 4, 10, 3, 800, 160, "+2 шанс крита", u => u.CriticalChance += 2);

            AddSword("Энергомеч “Василиск I”", Rarity.Usual, 3, 100, 20);
            AddSword("Энергобур “Минотавр I”", Rarity.Usual, 4, 100, 20, "-1 передвижения", u => u.Moving -= 1);
            AddSword("Энергомеч “Василиск II”", Rarity.Rare, 3, 200, 40, "+1 уклонения", u => u.Avoidance += 1);
            AddSword("Энергобур “Минотавр II”", Rarity.Rare, 5, 200, 40, "-1 передвижения", u => u.Moving -= 1);
            AddSword("Энергомеч “Василиск III”", Rarity.Unique, 4, 400, 80, "+2 уклонения", u => u.Avoidance += 2);
            AddSword("Энергобур “Минотавр III”", Rarity.Unique, 6, 400, 80, "-2 передвижения", u => u.Moving -= 2);
        }
    }
}