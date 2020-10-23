using CometUI;
using Model;
using Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bus
{
    public static Signal PlayerUnitsChanged;
    public static Signal PlayerStorageChanged;
    public static Signal<Unit> UnitSlotChanged;
    public static Signal PlayerMoneyChanged;
    public static Signal<IItem> ShowItemInfo;
    public readonly static State<List<Unit>> UnitsToSell;
    public readonly static State<List<IItem>> ItemsToSell;
    public readonly static State<HashSet<object>> SoldItems;
    public static State<Mission> CurrentMission;
    public static Signal<Quest> ShowQuest;
    public static bool IsAnyFullScreenWindowOpened => UIManager.IsAnyFullScreenFadeOpened;

    static Bus()
    {
        BusHelper.InitFields<Bus>();
        UnitsToSell.Value = new List<Unit>();
        ItemsToSell.Value = new List<IItem>();
        SoldItems.Value = new HashSet<object>();
    }
}
