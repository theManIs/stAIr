using System;
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
        public static readonly List<MissionGoalInfo> MissionGoals = new List<MissionGoalInfo>();
        public static readonly List<MissionTypeInfo> MissionTypeInfos = new List<MissionTypeInfo>();
        public static readonly List<MissionDescription> MissionDescriptions = new List<MissionDescription>();

        public static readonly Dictionary<Rarity, RarityInfo> RarityToInfo = new Dictionary<Rarity, RarityInfo>();
        public static readonly Dictionary<SupplyType, SupplyInfo> SupplyToInfo = new Dictionary<SupplyType, SupplyInfo>();

        static Database()
        {
            //build database
            Perk();
            Weapon();
            UnitName();
            Armor();
            Module();
            Quest();
            Common();
            Mission();
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

        static void InitRarity(Rarity rarity, int chance, string name)
        {
            RarityToInfo[rarity] = new RarityInfo { Chance = chance, Name = name };
        }

        static void InitSupply(SupplyType type, int buyPrice)
        {
            SupplyToInfo[type] = new SupplyInfo { BuyPrice = buyPrice };
        }

        static void AddMissionGoal(MissionGoal goal, string name, string prizeDescription, Action<Player> onSuccess = null, Action<Player> onFail = null)
        {
            var id = MissionGoals.Count;
            MissionGoals.Add(new MissionGoalInfo {Id = id, Goal = goal, Name = name, PrizeDescription = prizeDescription, OnSuccess = onSuccess, OnFail = onFail });
        }

        static void AddMissionDescription(MissionGoal goal, string description, Action<Player> onSuccess = null, Action<Player> onFail = null)
        {
            var id = MissionDescriptions.Count;
            MissionDescriptions.Add(new MissionDescription {Goal = goal, Id = id, Description = description, OnSuccess = onSuccess, OnFail = onFail });
        }

        static void AddMissionType(MissionType type, string name, int prize, Rarity prizeRarity1, int prizeCount1, Rarity prizeRarity2, int prizeCount2, string addPrizeDescription = null, Action<Player> onSuccess = null, Action<Player> onFail = null)
        {
            var id = MissionTypeInfos.Count;
            MissionTypeInfos.Add(new MissionTypeInfo { Id = id, Type = type, Name = name, Prize = prize, PrizeRarity1 = prizeRarity1, PrizeCount1 = prizeCount1, PrizeRarity2 = prizeRarity2, PrizeCount2 = prizeCount2, AddPrizeDescription = addPrizeDescription, OnSuccess = onSuccess, OnFail = onFail });
        }

        #endregion

        static partial void Perk();
        static partial void Weapon();
        static partial void UnitName();
        static partial void Armor();
        static partial void Module();
        static partial void Quest();
        static partial void Common();
        static partial void Mission();
    }
}