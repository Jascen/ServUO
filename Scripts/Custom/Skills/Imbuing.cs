using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public partial class ImbuingGumpC
    {
        public const int MaxProps = 4;
    }
}

namespace Server.SkillHandlers
{
    public partial class Imbuing
    {
        public static int GetMaxWeight(Item item)
        {
            var maxWeight = 350;

            IQuality quality = item as IQuality;
            if (quality != null && quality.Quality == ItemQuality.Exceptional)
                maxWeight += 50;

            
            return item.IsArtifact ? 500 : maxWeight;
        }

        public static bool IsSpecialItem(Item item)
        {
            if (item == null)
                return true;

            if (IsSpecialImbuable(item))
                return false;

            if (item.GetType() == typeof(SilverRing) || item.GetType() == typeof(SilverBracelet))
                return false;

            foreach (CraftSystem system in CraftSystem.Systems)
            {
                CraftItem crItem = null;

                if (system != null && system.CraftItems != null)
                    crItem = system.CraftItems.SearchFor(item.GetType());

                if (crItem != null)
                    return false;
            }

            return true;
        }

        #region Prop Ranges

        private static int[][] _MaxResistArmorTable =
        {
            new int[] { 20, 22, 21, 21, 21 }, // cloth *hats
            new int[] { 17, 19, 18, 18, 19 }, // studded leather
            new int[] { 17, 19, 18, 18, 18 }, // leather & samurai studded leather
            new int[] { 18, 18, 19, 17, 19 }, // bone
            new int[] { 18, 18, 16, 20, 18 }, // ringmail
            new int[] { 19, 19, 19, 16, 17 }, // chain
            new int[] { 20, 18, 17, 18, 17 }, // platemail
            new int[] { 20, 17, 17, 17, 19 }, // platemail/samurai
            new int[] { 17, 18, 17, 19, 19 }, // leaf
            new int[] { 18, 18, 19, 18, 17 }, // hide
            new int[] { 20, 16, 17, 17, 20 }, // woodland
            new int[] { 21, 21, 19, 23, 21 }, // stone
            new int[] { 18, 18, 18, 18, 18 }, // dragon
            new int[] { 22, 17, 17, 17, 17 }, // helmets
        };

        public static int[] GetPropRange(AosAttribute attr)
        {
            switch (attr)
            {
                case AosAttribute.Luck: return new int[] { 1, 100 };
                case AosAttribute.WeaponDamage: return new int[] { 2, 50 };
                case AosAttribute.WeaponSpeed: return new int[] { 5, 30 };
                case AosAttribute.LowerRegCost: return new int[] { 1, 20 };
                case AosAttribute.EnhancePotions: return new int[] { 5, 25 };
                case AosAttribute.AttackChance:
                case AosAttribute.DefendChance:
                case AosAttribute.ReflectPhysical: return new int[] { 1, 15 };
                case AosAttribute.SpellDamage: return new int[] { 1, 12 };
                case AosAttribute.BonusStr:
                case AosAttribute.BonusInt:
                case AosAttribute.BonusDex:
                case AosAttribute.BonusStam:
                case AosAttribute.BonusMana:
                case AosAttribute.LowerManaCost: return new int[] { 1, 8 };
                case AosAttribute.BonusHits: return new int[] { 1, 5 };
                case AosAttribute.CastRecovery:
                case AosAttribute.RegenStam: return new int[] { 1, 3 };
                case AosAttribute.RegenHits:
                case AosAttribute.RegenMana: return new int[] { 1, 2 };
                default:
                case AosAttribute.SpellChanneling:
                case AosAttribute.CastSpeed:
                case AosAttribute.Brittle:
                case AosAttribute.NightSight: return new int[] { 1, 1 };
            }
        }

        public static int[] GetPropRange(Item item, AosWeaponAttribute attr)
        {
            switch (attr)
            {
                case AosWeaponAttribute.DurabilityBonus:
                case AosWeaponAttribute.LowerStatReq: return new int[] { 10, 100 };
                case AosWeaponAttribute.HitLeechHits:
                case AosWeaponAttribute.HitLeechMana:
                case AosWeaponAttribute.HitLeechStam:
                case AosWeaponAttribute.HitLowerAttack:
                case AosWeaponAttribute.HitLowerDefend:
                case AosWeaponAttribute.HitMagicArrow:
                case AosWeaponAttribute.HitHarm:
                case AosWeaponAttribute.HitLightning:
                case AosWeaponAttribute.HitFireball:
                case AosWeaponAttribute.HitDispel:
                case AosWeaponAttribute.HitColdArea:
                case AosWeaponAttribute.HitFireArea:
                case AosWeaponAttribute.HitPhysicalArea:
                case AosWeaponAttribute.HitPoisonArea:
                case AosWeaponAttribute.HitCurse:
                case AosWeaponAttribute.HitFatigue:
                case AosWeaponAttribute.HitManaDrain: return new int[] { 2, 50 };
                case AosWeaponAttribute.HitEnergyArea:
                case AosWeaponAttribute.ResistFireBonus:
                case AosWeaponAttribute.ResistColdBonus:
                case AosWeaponAttribute.ResistPoisonBonus:
                case AosWeaponAttribute.ResistEnergyBonus:
                case AosWeaponAttribute.ResistPhysicalBonus: return new int[] { 1, 15 };
                case AosWeaponAttribute.MageWeapon: return new int[] { 1, 10 };
                case AosWeaponAttribute.SelfRepair: return new int[] { 1, 5 };
                case AosWeaponAttribute.SplinteringWeapon: return new int[] { 5, 30 };
                default:
                case AosWeaponAttribute.UseBestSkill:
                case AosWeaponAttribute.BattleLust:
                case AosWeaponAttribute.BloodDrinker: return new int[] { 1, 1 };
            }
        }

        public static int[] GetPropRange(AosArmorAttribute attr)
        {
            switch (attr)
            {
                case AosArmorAttribute.LowerStatReq:
                case AosArmorAttribute.DurabilityBonus: return new int[] { 10, 100 };
                case AosArmorAttribute.SoulCharge: return new int[] { 1, 10 };
                default:
                case AosArmorAttribute.ReactiveParalyze:
                case AosArmorAttribute.SelfRepair:
                case AosArmorAttribute.MageArmor: return new int[] { 1, 1 };
            }
        }

        public static int[] GetPropRange(SAAbsorptionAttribute attr)
        {
            switch (attr)
            {
                default:
                case SAAbsorptionAttribute.EaterFire:
                case SAAbsorptionAttribute.EaterCold:
                case SAAbsorptionAttribute.EaterPoison:
                case SAAbsorptionAttribute.EaterEnergy:
                case SAAbsorptionAttribute.EaterKinetic:
                case SAAbsorptionAttribute.EaterDamage:
                case SAAbsorptionAttribute.ResonanceFire:
                case SAAbsorptionAttribute.ResonanceCold:
                case SAAbsorptionAttribute.ResonancePoison:
                case SAAbsorptionAttribute.ResonanceEnergy:
                case SAAbsorptionAttribute.ResonanceKinetic:
                case SAAbsorptionAttribute.SoulChargeFire:
                case SAAbsorptionAttribute.SoulChargeCold:
                case SAAbsorptionAttribute.SoulChargePoison:
                case SAAbsorptionAttribute.SoulChargeEnergy:
                case SAAbsorptionAttribute.SoulChargeKinetic:
                case SAAbsorptionAttribute.CastingFocus: return new int[] { 1, 10 };
            }
        }

        public static int[] GetPropRange(AosElementAttribute attr)
        {
            return new int[] { 1, 15 };
        }

        public static int[] GetPropRange(Item item, AosElementAttribute attr)
        {
            int index = GetArmorIndex(item);

            if (index < 0 || index > _MaxResistArmorTable.Length) // Default Value
                return new int[] { 1, 15 };

            int attrIndex;

            switch (attr)
            {
                default:
                case AosElementAttribute.Physical: attrIndex = 0; break;
                case AosElementAttribute.Fire: attrIndex = 1; break;
                case AosElementAttribute.Cold: attrIndex = 2; break;
                case AosElementAttribute.Poison: attrIndex = 3; break;
                case AosElementAttribute.Energy: attrIndex = 4; break;
            }

            return new int[] { 1, _MaxResistArmorTable[index][attrIndex] };
        }

        public static int[] GetPropRange(Item item, ExtendedWeaponAttribute attr)
        {
            switch (attr)
            {
                default:
                case ExtendedWeaponAttribute.Bane:
                case ExtendedWeaponAttribute.BoneBreaker: return new int[] { 1, 1 };
                case ExtendedWeaponAttribute.HitSparks:
                case ExtendedWeaponAttribute.HitSwarm: return new int[] { 1, 20 };
            }
        }

        private static int GetArmorIndex(Item item)
        {
            if (item is BaseHat)
                return 0;

            BaseArmor armor = item as BaseArmor;

            if (armor != null)
            {
                if (item.Layer == Layer.Helm)
                    return 13;

                if (armor.MaterialType == ArmorMaterialType.Dragon)
                    return 12;

                if (armor is GargishStoneKilt || armor is GargishStoneChest || armor is GargishStoneLegs || armor is GargishStoneArms || armor is FemaleGargishStoneKilt || armor is FemaleGargishStoneChest || armor is FemaleGargishStoneLegs || armor is FemaleGargishStoneArms || armor is GargishStoneAmulet)
                    return 11;

                if (armor is WoodlandGorget || armor is WoodlandLegs || armor is WoodlandGloves || armor is WoodlandChest || armor is WoodlandArms)
                    return 10;

                if (armor is HidePants || armor is HidePauldrons || armor is HideGorget || armor is HideFemaleChest || armor is HideGloves || armor is HideChest)
                    return 9;

                if (armor is LeafLegs || armor is LeafTonlet || armor is LeafGorget || armor is LeafGloves || armor is LeafArms || armor is LeafChest)
                    return 8;

                if (armor is PlateSuneate || armor is PlateMempo || armor is PlateHiroSode || armor is PlateHatsuburi || armor is PlateHaidate || armor is PlateDo || armor is PlateBattleKabuto)
                    return 7;

                if (armor.MaterialType == ArmorMaterialType.Plate)
                    return 6;

                if (armor.MaterialType == ArmorMaterialType.Chainmail)
                    return 5;

                if (armor.MaterialType == ArmorMaterialType.Ringmail)
                    return 4;

                if (armor.MaterialType == ArmorMaterialType.Bone)
                    return 3;

                if (armor.MaterialType == ArmorMaterialType.Leather || armor is StuddedMempo || armor is StuddedSuneate || armor is StuddedHiroSode ||
                    armor is StuddedHaidate || armor is StuddedDo)
                    return 2;

                if (armor.MaterialType == ArmorMaterialType.Studded)
                    return 1;
            }

            return -1; // Studded Armor
        }

        #endregion Prop Ranges
    }
}
