using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MocksController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //generate units
        var units = new Units();
        for (int i = 0; i < 10; i++)
        {
            units.Add(CreateUnit());
        }

        Bus.Units.Publish(units);

        //generate units to sell
        var unitsToSell = new List<Unit>();

        for (int i = 0; i < 4; i++)
            unitsToSell.Add(CreateUnit());

        Bus.UnitsToSell.Publish(unitsToSell);
    }

    private Unit CreateUnit()
    {
        var res = new Unit { Name = UnitNames[UnityEngine.Random.Range(0, UnitNames.Length)], IconIndex = UnityEngine.Random.Range(0, 100) };

        //create traits of different groups
        res.Traits.Clear();

        while (res.Traits.Count < 3)
        {
            var trait = PersonTrait.PersonTraits[UnityEngine.Random.Range(0, PersonTrait.PersonTraits.Count)];
            if (!res.Traits.Any(t => t.Group == trait.Group))
                res.Traits.Add(trait);
        }

        //apply traits
        foreach (var trait in res.Traits)
            trait.Apply(res);

        return res;
    }

    static string[] UnitNames = new[]
{
"Алан",
"Морган",
"Алекс",
"Никки",
"Алексис",
"Ноэль",
"Блэр",
"Оливер",
"Бобби",
"Робби",
"Вайолет",
"Робин",
"Вэл",
"Рэй",
"Гейл",
"Саймон",
"Даррен",
"Сидни",
"Дарси",
"Стивен",
"Джеймс",
"Сэм",
"Джеки",
"Тейлор",
"Диллон",
"Тео",
"Дэнни",
"Тони",
"Каллум",
"Уэйн",
"Кейси",
"Финн",
"Кори",
"Хью",
"Крис",
"Чарли",
"Лесли",
"Шеннон",
"Ли",
"Эдди",
"Макс",
"Элис",
"Мел",
"Энди",
"Меттью",
"Эшли",
"Микки"
};
}
