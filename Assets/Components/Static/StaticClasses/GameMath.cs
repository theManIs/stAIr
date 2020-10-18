namespace Assets.Components.Static.StaticClasses
{
    public static class GameMath
    {
        public static float GetTargetAccuracy(float[] weaponAccuracyTable, int hexRange, float characterBaseAccuracy, float characterDodge, float coverModifier)
        {
            return weaponAccuracyTable[hexRange] + characterBaseAccuracy * 0.1f - characterDodge * 0.1f - coverModifier;
        }
    }
}