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
    public readonly static State<List<Unit>> UnitsToSell;
    public static Signal<Quest> ShowQuest;
    public static bool IsAnyFullScreenWindowOpened => UIManager.IsAnyFullScreenFadeOpened;

    static Bus()
    {
        BusHelper.InitFields<Bus>();
        UnitsToSell.Value = new List<Unit>();
    }
}
