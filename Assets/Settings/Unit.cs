namespace Model
{
    partial class Database
    {
        public static void InitUnit(Unit unit)
        {
            //Задавайте здесь только начальные характеристики юнита. Другие параметры не нужно здесь задавать.
            unit.Health = 5;
            unit.Shield = 2;
            unit.Soul = 5;
            unit.FarFight = 2;
            unit.NearFight = 2;
            unit.Avoidance = 2;
            unit.CriticalChance = 1;
            unit.Moving = 4;

            unit.BuyPrice = 200;
        }
    }
}