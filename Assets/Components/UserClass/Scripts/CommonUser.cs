using Assets.Components.WeaponsStock.Scripts;
using Assets.Static;
using UnityEngine;

namespace Assets.Components.UserClass.Scripts
{
    public class CommonUser : MonoBehaviour
    {
        public GameObject CharacterPrefab;
        public CharacterPreferences UserPreferences;

        [Header("Consumables")]
        public float ActualHealth;
        public float ActualShield;
        public float ActualMovePoints;
        public float ActualActionPoints;
        public float ActualAmoCount;

        [Header("Types")] 
        public TeamType ActualTeamType = TeamType.None;

        public WeaponBase CharacterWeapon;

        private void Start()
        {
            ActualHealth = UserPreferences.BaseHealth - 2;
            ActualShield = UserPreferences.BaseShield - 10;
            ActualMovePoints = UserPreferences.BaseMovePoints - 1;
            ActualActionPoints = UserPreferences.BaseActionPoints;
            ActualAmoCount = UserPreferences.BaseAmoCount;
            ActualTeamType = UserPreferences.BaseTeamType;
            CharacterWeapon = new WeaponShotgun();
        }
    }
}
