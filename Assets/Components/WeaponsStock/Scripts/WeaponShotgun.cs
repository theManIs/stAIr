using Assets.Static;
using UnityEngine;

namespace Assets.Components.WeaponsStock.Scripts
{
    public class WeaponShotgun : WeaponBase
    {
        public WeaponShotgun()
        {
            WeaponType = WeaponType.Дробовик;
            AudioClip = Resources.Load<AudioClip>("Media/drobo_ik-vystrel");
            Debug.Log(AudioClip);
        }

        public override void SingleShoot()
        {
            
        }
    }
}