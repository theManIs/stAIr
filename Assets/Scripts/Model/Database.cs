﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    static partial class Database
    {
        public static readonly List<Perk> Perks = new List<Perk>();
        public static readonly List<Weapon> Weapons = new List<Weapon>();
        public static readonly List<string> UnitNames = new List<string>();
        public static readonly List<Armor> Armors = new List<Armor>();
        public static readonly List<Module> Modules = new List<Module>();
        public static readonly List<Quest> Quests = new List<Quest>();

        static Database()
        {
            //build database
            Perk();
            Weapon();
            UnitName();
            Armor();
            Module();
            Quest();
        }

        #region Add methods

        static void AddPerk(int groupId, string name, string desc, Action<Unit> apply)
        {
            var id = Perks.Count;
            Perks.Add(new Perk(id, name, desc, groupId, apply));
        }

        static void AddName(string name)
        {
            UnitNames.Add(name);
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
            var id = Weapons.Count;
            Weapons.Add(new Weapon { Id = id, Type = type, Name = name, Rarity = rarity, Damage = damage, Range = range, Capacity = capacity, BuyPrice = buyPrice, SellPrice = sellPrice, EffectDescription = effectDescription, ApplyEffect = effect });
        }

        static void AddArmor(int groupId, string name, Rarity rarity, int buyPrice, int sellPrice, string effectDesc, Action<Unit> effect)
        {
            var id = Armors.Count;
            Armors.Add(new Armor { Id = id, GroupId = groupId, Name = name, Rarity = rarity, BuyPrice = buyPrice, SellPrice = sellPrice, EffectDescription = effectDesc, ApplyEffect = effect });
        }

        static void AddModule(string name, Rarity rarity, int buyPrice, int sellPrice/*, string effectDesc, Action<Unit> effect*/)
        {
            var id = Modules.Count;
            Modules.Add(new Module { Id = id, Name = name, Rarity = rarity, BuyPrice = buyPrice, SellPrice = sellPrice/*, EffectDescription = effectDesc, ApplyEffect = effect*/ });
        }

        static void CreateQuest(string name, string iconName, string description)
        {
            var id = Quests.Count;
            Quests.Add(new Quest { Id = id, Name = name, Image = iconName, Description = description });
        }

        static void AddVariant(string description, Func<Player, bool> condition = null)
        {
            var variant = new QuestVariant { Description = description, Condition = condition };
            Quests.Last().Variants.Add(variant);
        }

        static void AddResult(int probability, string description, string effectDescription, Action<Player> effect)
        {
            var result = new QuestResult { Probability = probability, Description = description, EffectDescription = effectDescription, Effect = effect };
            Quests.Last().Variants.Last().Results.Add(result);
        }

        #endregion

        static partial void Perk();
        static partial void Weapon();
        static partial void UnitName();
        static partial void Armor();
        static partial void Module();
        static partial void Quest();
    }
}