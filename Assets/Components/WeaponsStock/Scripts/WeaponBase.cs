using Assets.Static;
using UnityEngine;

namespace Assets.Components.WeaponsStock.Scripts
{
    public abstract class WeaponBase
    {
        public WeaponType WeaponType = WeaponType.None;
        public AudioClip AudioClip;

        public abstract void SingleShoot();

    }
}