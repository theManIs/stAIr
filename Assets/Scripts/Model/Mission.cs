using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    class Mission
    {
        public IEnumerable<Unit> Units => UnitsBySlots.Where(u => u != null);
        public Unit[] UnitsBySlots = new Unit[4];

        public Supply Energy { get; set; } = new Supply(SupplyType.EnergyCore);
        public Supply Stimpack { get; set; } = new Supply(SupplyType.Stimpack);
        public Supply AidKit { get; set; } = new Supply(SupplyType.AidKit);
        public Supply Stimulator { get; set; } = new Supply(SupplyType.Stimulator);

        public MissionType MissionType { get; set; }
        public MissionDescription MissionDescription { get; set; }
        public MissionGoalInfo MissionGoal { get; set; }


        //prize items
        public IItem[] VisiblePrizeItems { get; set; } = new IItem[0];
        public IItem[] InvisiblePrizeItems { get; set; } = new IItem[0];
    }

    class MissionDescription
    {
        public int Id { get; set; }
        public MissionGoal Goal { get; set; }
        public string Description { get; set; }
        public Action<Player> OnSuccess { get; set; }
        public Action<Player> OnFail { get; set; }
    }

    enum MissionType
    {
        None, Short, Middle, Long, Special
    }

    class MissionTypeInfo
    {
        public int Id { get; set; }
        public MissionType Type;
        public string Name { get; set; }
        public int Prize { get; set; }
        public Rarity PrizeRarity1 { get; set; }
        public int PrizeCount1 { get; set; }
        public Rarity PrizeRarity2 { get; set; }
        public int PrizeCount2 { get; set; }
        public string AddPrizeDescription { get; set; }
        public Action<Player> OnSuccess { get; set; }
        public Action<Player> OnFail { get; set; }
    }

    class MissionGoalInfo
    {
        public int Id { get; set; }
        public MissionGoal Goal { get; set; }
        public string Name { get; set; }
        public int Prize { get; set; }
        public string AddPrizeDescription { get; set; }
        public Action<Player> OnSuccess { get; set; }
        public Action<Player> OnFail { get; set; }
    }

    enum MissionGoal
    {
        ///<summary>Раазведка</summary>
        Reconnaissance,
        Evacuation,
        Search,
        Kill
    }

    enum SupplyType
    {
        EnergyCore, Stimpack, AidKit, Stimulator
    }

    class Supply
    {
        public SupplyType Type;
        public int Count;

        public Supply(SupplyType type)
        {
            Type = type;
        }
    }

    class SupplyInfo
    {
        public int BuyPrice { get; set; }
        public int MaxCount { get; set; }
    }

    class NextMissionDrafts
    {
        
    }
}
