using Server.Commands;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using System.Collections.Generic;

namespace Server.Items
{
    public static partial class RunicReforging
    {
        #region Tables

        #region All

        public static int[][] DurabilityTable = {
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 }
        };

        public static int[][] EaterTable = {
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 }
        };

        public static int[][] LowerStatReqTable = {
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 },
            new[] { 60, 70, 80, 90, 100, 100, 100 }
        };

        public static int[][] ResistTable = {
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 }
        };

        public static int[][] SelfRepairTable = {
            new[] { 1, 2, 3, 4, 5, 1, 2 },
            new[] { 1, 2, 3, 4, 5, 1, 2 },
            new[] { 1, 2, 3, 4, 5, 1, 2 },
            new[] { 1, 2, 3, 4, 5, 1, 2 },
            new[] { 1, 2, 3, 4, 5, 1, 2 }
        };

        public static int[][] StatTable = {
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        #endregion All

        #region Weapon Tables

        public static int[][] ArmorHCIDCIStatTable = {
            new[] { 5 }
        };

        public static int[][] DrainArmorEnhPotTable = {
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 }
        };

        // Hit magic, area, HLA
        public static int[][] HitWeaponTable = {
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 }
        };

        public static int[][] LeechTable = {
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 }
                };

        public static int[][] LuckTable = {
            new[] { 40, 50, 60, 70, 80, 90, 100 },
            new[] { 40, 50, 60, 70, 80, 90, 100 },
            new[] { 40, 50, 60, 70, 80, 90, 100 },
            new[] { 40, 50, 60, 70, 80, 90, 100 },
            new[] { 40, 50, 60, 70, 80, 90, 100 }
        };

        public static int[][] MageWeaponTable = {
            new[] { 25, 20, 15, 25, 20, 20},
            new[] { 25, 20, 15, 25, 20, 20},
            new[] { 25, 20, 15, 25, 20, 20},
            new[] { 25, 20, 15, 25, 20, 20},
            new[] { 25, 20, 15, 25, 20, 20}
        };

        public static int[][] SpeedTable = {
            new[] { 1, 2, 3, 4, 5, 8, 10 },
            new[] { 1, 2, 3, 4, 5, 8, 10 },
            new[] { 1, 2, 3, 4, 5, 8, 10 },
            new[] { 1, 2, 3, 4, 5, 8, 10 },
            new[] { 1, 2, 3, 4, 5, 8, 10 }
        };

        public static int[][] WeaponDamageTable = {
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 }
        };

        public static int[][] WeaponEnhancePots = {
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 }
        };

        public static int[][] WeaponHCIDCITable = {
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 },
            new[] { 1, 2, 3, 4, 5, 8, 10, 12, 15 }
        };

        public static int[][] WeaponSpeedTable = {
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 }
        };
        public static int[][] WeaponVelocityTable = {
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 },
            new[] { 15, 25, 25, 30, 35, 40, 45, 50 }
        };

        #endregion Weapon Tables

        #region Armor Tables

        public static int[][] ArmorCastingFocusTable = {
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 }
        };

        public static int[][] ArmorManaRegenTable = {
            new[] { 1, 2, 2, 1, 1, 2, 2 },
            new[] { 1, 2, 2, 1, 1, 2, 2 },
            new[] { 1, 2, 2, 1, 1, 2, 2 },
            new[] { 1, 2, 2, 1, 1, 2, 2 },
            new[] { 1, 2, 2, 1, 1, 2, 2 }
        };

        public static int[][] HitsTable = {
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 2, 3, 4, 5 }
        };

        public static int[][] LowerRegTable = {
            new[] { 10, 15, 15, 15, 20 },
            new[] { 10, 15, 15, 15, 20 },
            new[] { 10, 15, 15, 15, 20 },
            new[] { 10, 15, 15, 15, 20 },
            new[] { 10, 15, 15, 15, 20 }
        };
        public static int[][] ShieldSoulChargeTable = {
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 },
            new[] { 5, 10, 15, 15, 15, 20, 20, 30 }
        };

        public static int[][] StamManaLmcTable = {
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            new[] { 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static int[][] WeaponLmcRegenTable = {
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 },
            new[] { 1, 2, 3, 1, 1, 2, 3 }
        };
        #endregion Armor Tables

        #endregion Tables

        public static void Configure()
        {
            CommandSystem.Register("GetCreatureScore", AccessLevel.GameMaster, e =>
            {
                e.Mobile.BeginTarget(12, false, TargetFlags.None, (from, targeted) =>
                {
                    if (targeted is BaseCreature)
                    {
                        ((BaseCreature)targeted).PrivateOverheadMessage(MessageType.Regular, 0x25, false, GetDifficultyFor((BaseCreature)targeted).ToString(), e.Mobile.NetState);
                    }
                });
            });

            m_MeleeWeaponList = new List<object>();
            m_RangedWeaponList = new List<object>();
            m_ArmorList = new List<object>();
            m_JewelList = new List<object>();
            m_ShieldList = new List<object>();

            m_MeleeWeaponList.AddRange(m_WeaponBasic);
            m_MeleeWeaponList.AddRange(m_MeleeStandard);

            m_RangedWeaponList.AddRange(m_WeaponBasic);
            m_RangedWeaponList.AddRange(m_RangedStandard);

            m_ArmorList.AddRange(m_ArmorStandard);
            m_JewelList.AddRange(m_JewelStandard);
            m_ShieldList.AddRange(m_ShieldStandard);

            // TypeIndex 0 - Weapon; 1 - Armor; 2 - Shield; 3 - Jewels
            // RunicIndex 0 - dullcopper; 1 - shadow; 2 - copper; 3 - spined; 4 - Oak; 5 - ash

            m_PrefixSuffixInfo[0] = null;
            m_PrefixSuffixInfo[1] = new[] //Might
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLeechHits, LeechTable),
                        new NamedInfoCol(AosAttribute.BonusHits, HitsTable),
                        new NamedInfoCol(AosAttribute.BonusStr, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable)
                    },

                    new[] // armor
                    {
                        new NamedInfoCol("RandomEater", EaterTable),
                        new NamedInfoCol(AosAttribute.BonusHits, HitsTable),
                        new NamedInfoCol(AosAttribute.BonusStr, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable)
                    },

                    new[] // shield
                    {
                        new NamedInfoCol("RandomEater", EaterTable),
                        new NamedInfoCol(AosAttribute.BonusHits, HitsTable),
                        new NamedInfoCol(AosAttribute.BonusStr, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable)
                    },

                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.BonusHits, HitsTable),
                        new NamedInfoCol(AosAttribute.BonusStr, StatTable)
                    }
                };

            m_PrefixSuffixInfo[2] = new[] //Mystic
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLeechMana, LeechTable),
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, WeaponLmcRegenTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.LowerRegCost, LowerRegTable),
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.RegenMana, ArmorManaRegenTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.RegenMana, ArmorManaRegenTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, StatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.LowerRegCost, LowerRegTable)
                    }
                };

            m_PrefixSuffixInfo[3] = new[] // Animated
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLeechStam, LeechTable),
                        new NamedInfoCol(AosAttribute.BonusStam, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusDex, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.WeaponSpeed, WeaponSpeedTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.BonusStam, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusDex, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.BonusStam, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusDex, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.WeaponSpeed, SpeedTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.BonusStam, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusDex, StatTable),
                        new NamedInfoCol(AosAttribute.WeaponSpeed, SpeedTable)
                    }
                };
            m_PrefixSuffixInfo[4] = new[] //Arcane
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLeechMana, LeechTable),
                        new NamedInfoCol(AosWeaponAttribute.HitManaDrain, DrainArmorEnhPotTable),
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.CastSpeed, 1),
                        new NamedInfoCol(AosAttribute.SpellChanneling, 1),
                        new NamedInfoCol(AosWeaponAttribute.MageWeapon, MageWeaponTable),
                        new NamedInfoCol(AosAttribute.RegenMana, ArmorManaRegenTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.RegenMana, ArmorManaRegenTable),
                        new NamedInfoCol(AosAttribute.LowerRegCost, LowerRegTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, ArmorHCIDCIStatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.RegenMana, ArmorManaRegenTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.BonusMana, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.BonusInt, StatTable),
                        new NamedInfoCol(AosAttribute.LowerManaCost, StamManaLmcTable),
                        new NamedInfoCol(AosAttribute.RegenMana, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.LowerRegCost, LowerRegTable),
                        new NamedInfoCol(AosAttribute.CastSpeed, 2),
                        new NamedInfoCol(AosAttribute.CastRecovery, 4),
                        new NamedInfoCol(AosAttribute.SpellDamage, 15)
                    }
                };
            m_PrefixSuffixInfo[5] = new[] // Exquisite
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.SelfRepair, SelfRepairTable),
                        new NamedInfoCol(AosWeaponAttribute.DurabilityBonus, DurabilityTable),
                        new NamedInfoCol(AosWeaponAttribute.HitLowerDefend, HitWeaponTable),
                        new NamedInfoCol(AosWeaponAttribute.LowerStatReq, LowerStatReqTable),
                        new NamedInfoCol("Slayer", 1),
                        new NamedInfoCol(AosWeaponAttribute.MageWeapon, MageWeaponTable),
                        new NamedInfoCol(AosAttribute.SpellChanneling, 1),
                        new NamedInfoCol(AosAttribute.BalancedWeapon, 1),
                        new NamedInfoCol("WeaponVelocity", WeaponVelocityTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosArmorAttribute.SelfRepair, SelfRepairTable),
                        new NamedInfoCol(AosArmorAttribute.DurabilityBonus, DurabilityTable),
                        new NamedInfoCol(AosArmorAttribute.LowerStatReq, LowerStatReqTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosArmorAttribute.SelfRepair, SelfRepairTable),
                        new NamedInfoCol(AosArmorAttribute.DurabilityBonus, DurabilityTable),
                        new NamedInfoCol(AosArmorAttribute.LowerStatReq, LowerStatReqTable)
                    },
                    new NamedInfoCol[] // jewels
                    {
                    }
                };
            m_PrefixSuffixInfo[6] = new[] //Vampiric
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLeechHits, LeechTable),
                        new NamedInfoCol(AosWeaponAttribute.HitLeechStam, LeechTable),
                        new NamedInfoCol(AosWeaponAttribute.HitLeechMana, LeechTable),
                        new NamedInfoCol(AosWeaponAttribute.HitManaDrain, DrainArmorEnhPotTable),
                        new NamedInfoCol(AosWeaponAttribute.HitFatigue, DrainArmorEnhPotTable),
                        new NamedInfoCol(AosWeaponAttribute.BloodDrinker, 1)
                    },
                    new NamedInfoCol[] // armor
                    {
                    },
                    new NamedInfoCol[] // shield
                    {
                    },
                    new NamedInfoCol[] // jewels
                    {
                    }
                };
            m_PrefixSuffixInfo[7] = new[] // Invigorating
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenMana, WeaponLmcRegenTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenMana, WeaponLmcRegenTable),

                        new NamedInfoCol("RandomEater",  EaterTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenMana, WeaponLmcRegenTable),
                        new NamedInfoCol(AosArmorAttribute.SoulCharge, ShieldSoulChargeTable),
                        new NamedInfoCol("RandomEater", EaterTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.RegenHits, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenStam, WeaponLmcRegenTable),
                        new NamedInfoCol(AosAttribute.RegenMana, WeaponLmcRegenTable),
                        new NamedInfoCol("RandomEater", EaterTable)
                    }
                };
            m_PrefixSuffixInfo[8] = new[] // Fortified
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.ResistPhysicalBonus, ResistTable),
                        new NamedInfoCol(AosWeaponAttribute.ResistFireBonus, ResistTable),
                        new NamedInfoCol(AosWeaponAttribute.ResistColdBonus, ResistTable),
                        new NamedInfoCol(AosWeaponAttribute.ResistPoisonBonus, ResistTable),
                        new NamedInfoCol(AosWeaponAttribute.ResistEnergyBonus, ResistTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosElementAttribute.Physical, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Fire, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Cold, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Poison, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Energy, ResistTable),
                        new NamedInfoCol("RandomEater", EaterTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosElementAttribute.Physical, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Fire, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Cold, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Poison, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Energy, ResistTable),
                        new NamedInfoCol("RandomEater", EaterTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosElementAttribute.Physical, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Fire, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Cold, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Poison, ResistTable),
                        new NamedInfoCol(AosElementAttribute.Energy, ResistTable)
                    }
                };
            m_PrefixSuffixInfo[9] = new[] // Auspicious
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosAttribute.Luck, LuckTable, LuckTable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.Luck, LuckTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.Luck, LuckTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.Luck, LuckTable)
                    }
                };
            m_PrefixSuffixInfo[10] = new[] // Charmed
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosAttribute.EnhancePotions, WeaponEnhancePots),
                        new NamedInfoCol(AosAttribute.BalancedWeapon, 1)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.EnhancePotions, DrainArmorEnhPotTable)
                    },
                    new NamedInfoCol[] // shield
                    {
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.EnhancePotions, WeaponEnhancePots)
                    }
                };
            m_PrefixSuffixInfo[11] = new[] //Vicious
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol("HitSpell", HitWeaponTable),
                        new NamedInfoCol("HitArea", HitWeaponTable),
                        new NamedInfoCol(AosAttribute.AttackChance, WeaponHCIDCITable, WeaponHCIDCITable),
                        new NamedInfoCol(AosAttribute.WeaponDamage, WeaponDamageTable),
                        new NamedInfoCol(AosWeaponAttribute.BattleLust, 1),
                        new NamedInfoCol(AosWeaponAttribute.SplinteringWeapon, 30),
                        new NamedInfoCol("Slayer", 1)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.AttackChance, ArmorHCIDCIStatTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.AttackChance, WeaponHCIDCITable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.AttackChance, WeaponHCIDCITable),
                        new NamedInfoCol(AosAttribute.SpellDamage, 15)
                    }
                };
            m_PrefixSuffixInfo[12] = new[] // Towering
				{
                    new[] // Weapon
                    {
                        new NamedInfoCol(AosWeaponAttribute.HitLowerAttack, HitWeaponTable),
                        new NamedInfoCol(AosWeaponAttribute.ReactiveParalyze, 1),
                        new NamedInfoCol(AosAttribute.DefendChance, WeaponHCIDCITable, WeaponHCIDCITable)
                    },
                    new[] // armor
                    {
                        new NamedInfoCol(AosAttribute.DefendChance, ArmorHCIDCIStatTable),
                        new NamedInfoCol(SAAbsorptionAttribute.CastingFocus, ArmorCastingFocusTable)
                    },
                    new[] // shield
                    {
                        new NamedInfoCol(AosAttribute.DefendChance, WeaponHCIDCITable),
                        new NamedInfoCol(AosArmorAttribute.ReactiveParalyze, 1),
                        new NamedInfoCol(AosArmorAttribute.SoulCharge, ShieldSoulChargeTable)
                    },
                    new[] // jewels
                    {
                        new NamedInfoCol(AosAttribute.DefendChance, WeaponHCIDCITable),
                        new NamedInfoCol(SAAbsorptionAttribute.CastingFocus, ArmorCastingFocusTable)
                    }
                };
        }
    }
}
