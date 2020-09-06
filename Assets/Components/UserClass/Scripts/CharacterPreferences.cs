using System;
using System.Globalization;
using UnityEngine;

namespace Assets.Components.UserClass.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterPrefs", order = 1)]
    public class CharacterPreferences : ScriptableObject
    {

        public string CharacterOfficialName;
        public float BaseAim;
        public float BaseDamage;
        public float BaseDodge;
        public float BaseArmor;
        public float BaseHp;
        public float BaseShield;
        public float BaseAmoCount;
        public float BaseCritChance;
        public float BaseDetectionArea;
        public float BaseMovePoints;
        public float BaseActionPoints;

        public float BaseFireRateType;
        public float BaseArmorType;
        public float BaseWeaponType;

        public string GetString(string valueName)
        {
            return Convert.ToString(typeof(CharacterPreferences).GetField(valueName).GetValue(this), CultureInfo.InvariantCulture);
        }
    }
}