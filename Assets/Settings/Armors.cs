namespace Model
{
    partial class Database
    {
        static partial void Armor()
        {
            AddArmor(1, "Легкая броня “Гермес I”", Rarity.Usual, 200, 40, "+1 передвижения +1 уклонения", u => { u.Moving += 1; u.Avoidance += 1; } );
            AddArmor(1, "Легкая броня “Морфей I”", Rarity.Usual, 200, 40, "+1 передвижения +1 дальний бой", u => { u.Moving += 1; u.FarFight += 1; });
            AddArmor(1, "Легкая броня “Морфей II”", Rarity.Rare, 400, 80, "+2 передвижения +2 дальний бой", u => { u.Moving += 2; u.FarFight += 2; });
            AddArmor(1, "Легкая броня “Гермес II”", Rarity.Rare, 400, 80, "+2 передвижения +2 уклонения", u => { u.Moving += 2; u.Avoidance += 2; });
            AddArmor(1, "Легкая броня “Дионис”", Rarity.Rare, 400, 80, "+4 передвижения", u => { u.Moving += 4; } );
            AddArmor(1, "Легкая броня “Гермес III”", Rarity.Unique, 800, 160, "+3 передвижения +2 уклонения  +2 дальний бой", u => { u.Moving += 3; u.Avoidance += 2; u.FarFight += 2; });
            AddArmor(1, "Легкая броня “Морфей III”", Rarity.Unique, 800, 160, "+2 передвижения +3 дальний бой +1 критический шанс", u => { u.Moving += 2; u.FarFight += 3; u.CriticalChance += 1; });

            AddArmor(2, "Средняя броня ”Зевс I” ", Rarity.Usual, 200, 40, "+2 здоровья +2 боевой дух", u => { u.Health += 2; u.Soul += 2; });
            AddArmor(2, "Средняя броня “Арес I”", Rarity.Usual, 200, 40, "+1 энергощит +1 ближний бой", u => { u.Shield += 1; u.NearFight += 1; });
            AddArmor(2, "Средняя броня “Арес II”", Rarity.Rare, 400, 80, "+2 энергощит +2 ближний бой", u => { u.Shield += 2; u.NearFight += 2; });
            AddArmor(2, "Средняя броня ”Зевс II” ", Rarity.Rare, 400, 80, "+3 здоровья +3 боевой дух", u => { u.Health += 3; u.Soul += 3; });
            AddArmor(2, "Средняя броня “Посейдон”", Rarity.Rare, 400, 80, "+2 здоровья +2 боевой дух +1 ближний бой", u => { u.Health += 2; u.Soul += 2; u.NearFight += 1; });
            AddArmor(2, "Средняя броня ”Зевс III” ", Rarity.Unique, 800, 160, "+2 здоровья +4 боевой дух +2 ближний бой", u => { u.Health += 2; u.Soul += 4; u.NearFight += 2; });
            AddArmor(2, "Средняя броня “Арес III”", Rarity.Unique, 800, 160, "+4 энергощит +4 ближний бой ", u => { u.Shield += 4; u.NearFight += 4; });

            AddArmor(3, "Тяжелая броня “Аид I”", Rarity.Usual, 200, 40, "+4 здоровья -1 передвижения", u => { u.Health += 4; u.Moving -= 1; });
            AddArmor(3, "Тяжелая броня “Гефест I”", Rarity.Usual, 200, 40, "+2 здоровья +2 энергощит -1 передвижения", u => { u.Health += 2; u.Shield += 2; u.Moving -= 1; } );
            AddArmor(3, "Тяжелая броня “Гефест II”", Rarity.Rare, 400, 80, "+4 здоровья +2 энергощит -2 передвижения", u => { u.Health += 4; u.Shield += 2; u.Moving -= 2; } );
            AddArmor(3, "Тяжелая броня “Антей I”", Rarity.Rare, 400, 80, "+2 здоровья +4 энергощит -1 передвижения -1 уклонения", u => { u.Health += 2; u.Shield += 4; u.Moving -= 1; u.Avoidance -= 1; } );
            AddArmor(3, "Тяжелая броня “Аид II”", Rarity.Rare, 400, 80, "+7 здоровья -2 передвижения", u => { u.Health += 7; u.Moving -= 2; } );
            AddArmor(3, "Тяжелая броня “Гефест III”", Rarity.Unique, 800, 160, "+5 здоровья +5 энергощита -3 передвижения", u => { u.Health += 5; u.Shield += 5; u.Moving -= 3; });
            AddArmor(3, "Тяжелая броня “Антей II”", Rarity.Unique, 800, 160, "+3 здоровья +3 энергощит +3 боевой дух -2 передвижения -1 уклонения", u => { u.Health += 3; u.Shield += 3; u.Soul += 3; u.Moving -= 2; u.Avoidance -= 1; } );
        }
    }
}