using Model;
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
    }

    private Unit CreateUnit()
    {
        var res = new Unit { Name = Database.UnitNames[UnityEngine.Random.Range(0, Database.UnitNames.Count)], IconIndex = UnityEngine.Random.Range(0, 100) };

        //init
        Database.InitUnit(res);

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
