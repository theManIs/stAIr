using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Player
{
    public static Player Instance;

    static Player()
    {
        Instance = new Player();
    }

    public Player()
    {
        Database.InitPlayer(this);
    }

    /// <summary>Money</summary>
    public decimal Money { get; set; }

    /// <summary>Units of Player</summary>
    public List<Unit> Units = new List<Unit>();

    /// <summary>Items in storage</summary>
    public List<IItem> StorageItems = new List<IItem>();


    /// <summary>Is there any unit with module?</summary>
    public bool HasModule(string moduleName)
    {
        return Units.Any(u=>u.Modules.Any(m=>m.Name == moduleName));
    }

    public bool Buy(IItem item)
    {
        if (item.BuyPrice > Money)
            return false;

        StorageItems.Add(item);
        Money -= item.BuyPrice;

        Bus.PlayerStorageChanged += true;
        Bus.PlayerMoneyChanged += true;

        return true;
    }

    public int GetItemsCount(IItem item)
    {
        var c1 = StorageItems.Count(i => i == item);
        var c2 = Units.Sum(u => u.Items.Count(i => i == item));

        return c1 + c2;
    }

    public bool Buy(Unit unit)
    {
        if (unit.BuyPrice > Money)
            return false;

        Units.Add(unit);
        Money -= unit.BuyPrice;

        Bus.PlayerUnitsChanged += true;
        Bus.PlayerMoneyChanged += true;

        return true;
    }
}