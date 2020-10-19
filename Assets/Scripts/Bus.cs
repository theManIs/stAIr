using CometUI;
using Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bus
{
    public readonly static State<Units> Units;
    public readonly static State<List<Unit>> UnitsToSell;
    public static State<int> ShowTextQuest;
    public static bool IsAnyFullScreenWindowOpened => UIManager.IsAnyFullScreenFadeOpened;

    static Bus()
    {
        BusHelper.InitFields<Bus>();
        Units.Value = new Units();
        UnitsToSell.Value = new List<Unit>();
    }
}