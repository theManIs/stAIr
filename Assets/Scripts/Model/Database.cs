using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    static partial class Database
    {
        public static List<Perk> PerkList = new List<Perk>();
        public static List<Weapon> WeaponList = new List<Weapon>();
        public static List<string> UnitNameList = new List<string>();

        static Database()
        {
            //build database
            Perks();
            Weapons();
            UnitNames();
        }

        static void AddPerk(int groupId, string name, string desc, Action<Unit> apply)
        {
            var id = PerkList.Count;
            PerkList.Add(new Perk(id, name, desc, groupId, apply));
        }

        static void AddName(string name)
        {
            UnitNameList.Add(name);
        }

        static void AddPistol(string name, Rarity rarity, int damage, int range, int capacity, int buyPrice, int sellPrice, string effectDescription = null, Action<Unit> effect = null)
        {
            AddWeapon(WeaponType.Pistol, name, rarity, damage, range, capacity, buyPrice, sellPrice, effectDescription, effect);
        }

        static void AddRifle(string name, Rarity rarity, int damage, int range, int capacity, int buyPrice, int sellPrice, string effectDescription = null, Action<Unit> effect = null)
        {
            AddWeapon(WeaponType.Rifle, name, rarity, damage, range, capacity, buyPrice, sellPrice, effectDescription, effect);
        }

        static void AddGun(string name, Rarity rarity, int damage, int range, int capacity, int buyPrice, int sellPrice, string effectDescription = null, Action<Unit> effect = null)
        {
            AddWeapon(WeaponType.Gun, name, rarity, damage, range, capacity, buyPrice, sellPrice, effectDescription, effect);
        }

        static void AddSniperRifle(string name, Rarity rarity, int damage, int range, int capacity, int buyPrice, int sellPrice, string effectDescription = null, Action<Unit> effect = null)
        {
            AddWeapon(WeaponType.SniperRifle, name, rarity, damage, range, capacity, buyPrice, sellPrice, effectDescription, effect);
        }

        static void AddSword(string name, Rarity rarity, int damage, int buyPrice, int sellPrice, string effectDescription = null, Action<Unit> effect = null)
        {
            AddWeapon(WeaponType.Sword, name, rarity, damage, 1, int.MaxValue, buyPrice, sellPrice, effectDescription, effect);
        }

        static void AddWeapon(WeaponType type, string name, Rarity rarity, int damage, int range, int capacity, int buyPrice, int sellPrice, string effectDescription, Action<Unit> effect)
        {
            var id = WeaponList.Count;
            WeaponList.Add(new Weapon { Id = id, Type = type, Name = name, Rarity = rarity, Damage = damage, Range = range, Capacity = capacity, BuyPrice = buyPrice, SellPrice = sellPrice, EffectDescription = effectDescription, ApplyEffect = effect });
        }

        static partial void Perks();
        static partial void Weapons();
        static partial void UnitNames();
    }
}