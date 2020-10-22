namespace Model
{
    partial class Database
    {
        /*ВНИМАНИЕ! Не меняйте порядок слотов, не удаляйте слоты! Это приведет к сбою в сохранениях игрока!*/
        static partial void Mission()
        {
            //можно описать ровно один тип на каждый MissionType
            AddMissionType(MissionType.Short, "Короткая вылазка", 200, Rarity.Usual, 1, Rarity.Usual, 1);
            AddMissionType(MissionType.Middle, "Средний поход", 400, Rarity.Rare, 1, Rarity.Rare, 1);
            AddMissionType(MissionType.Long, "Долгая экспедиция", 600, Rarity.Unique, 1, Rarity.Unique, 1);
            AddMissionType(MissionType.Special, "Особое задание", 1200, Rarity.Unique, 1, Rarity.Unique, 2);

            //можно описать произвольное число целей (не менее 1 на каждый MissionGoal)
            AddMissionGoal(MissionGoal.Reconnaissance, "Разведка", "");
            AddMissionGoal(MissionGoal.Evacuation, "Эвакуация", "+100 кредитов", p => p.Money += 100);
            AddMissionGoal(MissionGoal.Search, "Поиск груза", "+200 кредитов", p => p.Money += 200);
            AddMissionGoal(MissionGoal.Kill, "Устранение цели", "+300 кредитов", p => p.Money += 300);

            //можно описать произвольное число описаний для произвольных целей (не менее 1 на каждую цель)
            AddMissionDescription(MissionGoal.Reconnaissance, "Побывать в 60% зон");
            AddMissionDescription(MissionGoal.Evacuation, "Найти в одной из зон нужного человека");
            AddMissionDescription(MissionGoal.Search, "Найти три зоны с нужным грузом");
            AddMissionDescription(MissionGoal.Kill, "Найти в одной из зон нужного врага и уничтожить");            
        }
    }
}