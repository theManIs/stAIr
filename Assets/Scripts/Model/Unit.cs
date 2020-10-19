using System;
using System.Collections.Generic;

class Units : List<Unit>
{
}


class Unit
{
    public string Name;
    public int IconIndex;
    public int Level = 80;

    public float Experience = 0;
    public float Health = 5;
    public float Shield = 5;
    public float Soul = 5;
    public float FarFight = 5;
    public float NearFight = 5;
    public float Avoidance = 5;
    public float CriticalChance = 5;
    public float Moving = 5;

    public decimal Price;
    public bool IsSold;
    public List<PersonTrait> Traits = new List<PersonTrait>();
}

class PersonTrait
{
    public string Name;
    public string Desc;
    public string IconName;
    public int Group;
    public Action<Unit> Apply;

    public PersonTrait(string name, string desc, string iconName, int group, Action<Unit> apply)
    {
        Name = name;
        Desc = desc;
        IconName = iconName;
        Group = group;
        Apply = apply;
    }

    public static List<PersonTrait> PersonTraits;

    static PersonTrait()
    {
        PersonTraits = new List<PersonTrait>();

        PersonTraits.Add(new PersonTrait("Крепкий", "+3 здоровья", "", 1, (u) => u.Health += 3));
        PersonTraits.Add(new PersonTrait("Хрупкий", "-3 здоровья", "", 1, (u) => u.Health -= 3));
        PersonTraits.Add(new PersonTrait("Технарь", "+2 энергощит", "", 2, (u) => u.Shield += 2));
        PersonTraits.Add(new PersonTrait("Глупый", "-2 энергощит", "", 2, (u) => u.Shield -= 2));
        PersonTraits.Add(new PersonTrait("Смелый", "+2 боевого духа", "", 3, (u) => u.Soul += 2));
        PersonTraits.Add(new PersonTrait("Трусливый", "-2 боевого духа", "", 3, (u) => u.Soul -= 2));
        PersonTraits.Add(new PersonTrait("Дальнозоркий", "+2 дальний бой", "", 4, (u) => u.FarFight += 2));
        PersonTraits.Add(new PersonTrait("Близорукий", "-2 дальний бой", "", 4, (u) => u.FarFight -= 2));
        PersonTraits.Add(new PersonTrait("Сильный", "+2 ближний бой", "", 5, (u) => u.NearFight += 2));
        PersonTraits.Add(new PersonTrait("Слабый", "-2 ближний бой", "", 5, (u) => u.NearFight -= 2));
        PersonTraits.Add(new PersonTrait("Ловкий", "+2 уклонения", "", 6, (u) => u.Avoidance += 2));
        PersonTraits.Add(new PersonTrait("Неуклюжий", "-2 уклонения", "", 6, (u) => u.Avoidance -= 2));
        PersonTraits.Add(new PersonTrait("Удачливый", "+1 шанс крита", "", 7, (u) => u.CriticalChance += 1));
        PersonTraits.Add(new PersonTrait("Неудачник", "-1 шанс крита", "", 7, (u) => u.CriticalChance -= 1));
        PersonTraits.Add(new PersonTrait("Быстрый", "+2 перемещения", "", 8, (u) => u.Moving += 2));
        PersonTraits.Add(new PersonTrait("Косолапый", "-2 перемещения", "", 8, (u) => u.Moving -= 2));
    }
}
