using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MocksController : MonoBehaviour
{
    static System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        //generate units
        var units = Player.Instance.Units;
        units.Clear();
        for (int i = 0; i < 10; i++)
        {
            units.Add(CreateUnit());
        }

        Bus.PlayerUnitsChanged += true;

        //generate units to sell
        var unitsToSell = new List<Unit>();

        for (int i = 0; i < 4; i++)
            unitsToSell.Add(CreateUnit());

        Bus.UnitsToSell.Publish(unitsToSell);

        //generate items to sell
        var items = new List<IItem>();
        items.AddRange(Database.Weapons);
        items.AddRange(Database.Armors);
        items.AddRange(Database.Modules);
        var probs = items.Select(item => Database.RarityToInfo[item.Rarity].Chance).ToList();
        var sum = probs.Sum();
        var itemsToSell = new HashSet<IItem>();

        while (itemsToSell.Count < 8)
            itemsToSell.Add(items.GetRnd(probs, rnd, sum));

        Bus.ItemsToSell.Publish(itemsToSell.ToList());

        //generate player's items
        Player.Instance.StorageItems.Add(Database.Armors[0]);
        Player.Instance.StorageItems.Add(Database.Weapons[0]);
        Player.Instance.StorageItems.Add(Database.Weapons[0]);
        Player.Instance.StorageItems.Add(Database.Weapons[1]);
        Player.Instance.StorageItems.Add(Database.Modules[0]);
        Player.Instance.StorageItems.Add(Database.Modules[1]);
        Player.Instance.StorageItems.Add(Database.Modules[2]);
        Player.Instance.StorageItems.Add(Database.Weapons[0]);
    }

    private Unit CreateUnit()
    {
        var res = new Unit { Name = Database.UnitNames[UnityEngine.Random.Range(0, Database.UnitNames.Count)], IconIndex = UnityEngine.Random.Range(0, 100) };

        //create traits of different groups
        res.Perks.Clear();

        while (res.Perks.Count < 3)
        {
            var trait = Database.Perks[UnityEngine.Random.Range(0, Database.Perks.Count)];
            if (!res.Perks.Any(t => t.Group == trait.Group))
                res.Perks.Add(trait);
        }

        //apply perks
        foreach (var perk in res.Perks)
            perk.ApplyEffect(res);

        return res;
    }
}
