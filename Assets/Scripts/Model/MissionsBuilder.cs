using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    static class MissionsBuilder
    {
        static System.Random rnd = new System.Random();

        public static void Build(Dictionary<MissionType, Mission> missionsByType)
        {
            foreach(MissionType type in Enum.GetValues(typeof(MissionType)))
            {
                if (type != MissionType.None)
                    missionsByType[type] = Build(type);
            }
        }

        private static Mission Build(MissionType type)
        {
            var mission = new Mission();
            mission.MissionType = type;

            //assign random goal and description
            mission.MissionGoal = Database.MissionGoals.GetRnd(rnd);
            mission.MissionDescription = Database.MissionDescriptions.Where(d => d.Goal == mission.MissionGoal.Goal).GetRnd(rnd);

            //build prize items
            var typeInfo = Database.MissionTypeInfos.Where(i => i.Type == type).GetRnd(rnd);
            mission.VisiblePrizeItems = BuildPrizeItems(typeInfo.PrizeRarity1, typeInfo.PrizeCount1);
            mission.InvisiblePrizeItems = BuildPrizeItems(typeInfo.PrizeRarity2, typeInfo.PrizeCount2);

            return mission;
        }

        private static IItem[] BuildPrizeItems(Rarity rarity, int count)
        {
            var items = Database.Armors.Cast<IItem>()
                        .Union(Database.Weapons.Cast<IItem>())
                        .Union(Database.Modules.Cast<IItem>()).ToList();
            return items.GetRnds(count, rnd).ToArray();
        }
    }
}