namespace Model
{
    partial class Database
    {
        public static void InitUnit(Model.Unit unit)
        {
            unit.Health = 5;
            unit.Shield = 2;
            unit.Soul = 5;
            unit.FarFight = 2;
            unit.NearFight = 2;
            unit.Avoidance = 2;
            unit.CriticalChance = 1;
            unit.Moving = 4;
        }
    }
}