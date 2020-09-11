using System;
using System.Globalization;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Components.UserClass.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterPrefs", order = 1)]
    public class CharacterPreferences : ScriptableObject
    {
        [Header("Fixed")]
        public string CharacterOfficialName;
        public Sprite CharacterPortrait;
        public Sprite WeaponBaseAvatar;
        public float BaseAim;
        public float BaseDamage;
        public float BaseDodge;
        public float BaseArmor;
        public float BaseCritChance;
        public float BaseDetectionArea;
        public float BaseAttackRange;

        [Header("Consumables")]
        public float BaseHealth;
        public float BaseShield;
        public float BaseMovePoints;
        public float BaseActionPoints;
        public float BaseAmoCount;

        [Header("Types")]
        public FireRateType BaseFireRateType = FireRateType.Нет;
        public float BaseArmorType;
        public float BaseWeaponType;

        public string GetString(string valueName)
        {
            return Convert.ToString(typeof(CharacterPreferences).GetField(valueName).GetValue(this), CultureInfo.InvariantCulture);
        }
    }
}