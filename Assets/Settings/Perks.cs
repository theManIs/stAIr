namespace Model
{
    partial class Database
    {
        static partial void Perk()
        {
            AddPerk(1, "Крепкий", "+3 здоровья", u => u.Health += 3);
            AddPerk(1, "Хрупкий", "-3 здоровья", u => u.Health -= 3);
            AddPerk(2, "Технарь", "+2 энергощит", u => u.Shield += 2);
            AddPerk(2, "Глупый", "-2 энергощит", u => u.Shield -= 2);
            AddPerk(3, "Смелый", "+2 боевого духа", u => u.Soul += 2);
            AddPerk(3, "Трусливый", "-2 боевого духа", u => u.Soul -= 2);
            AddPerk(4, "Дальнозоркий", "+2 дальний бой", u => u.FarFight += 2);
            AddPerk(4, "Близорукий", "-2 дальний бой", u => u.FarFight -= 2);
            AddPerk(5, "Сильный", "+2 ближний бой", u => u.NearFight += 2);
            AddPerk(5, "Слабый", "-2 ближний бой", u => u.NearFight -= 2);
            AddPerk(6, "Ловкий", "+2 уклонения", u => u.Avoidance += 2);
            AddPerk(6, "Неуклюжий", "-2 уклонения", u => u.Avoidance -= 2);
            AddPerk(7, "Удачливый", "+1 шанс крита", u => u.CriticalChance += 1);
            AddPerk(7, "Неудачник", "-1 шанс крита", u => u.CriticalChance -= 1);
            AddPerk(8, "Быстрый", "+2 перемещения", u => u.Moving += 2);
            AddPerk(8, "Косолапый", "-2 перемещения", u => u.Moving -= 2);
        }
    }
}