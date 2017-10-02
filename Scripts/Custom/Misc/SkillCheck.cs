using Server.Accounting;
using Server.Mobiles;
using Server.Spells.SkillMasteries;
using System;

namespace Server.Misc
{
    public partial class SkillCheck
    {
        public static bool CheckSkill(Mobile from, Skill skill, object amObj, double chance)
        {
            if (from.Skills.Cap == 0)
                return false;

            var fastGain = false;
            switch ((SkillName)skill.SkillID)
            {
                case SkillName.EvalInt:
                case SkillName.Healing:
                case SkillName.Magery:
                case SkillName.Tactics:
                case SkillName.Musicianship:
                case SkillName.Discordance:
                case SkillName.Provocation:
                case SkillName.Peacemaking:
                case SkillName.Archery:
                case SkillName.Veterinary:
                case SkillName.Swords:
                case SkillName.Macing:
                case SkillName.Fencing:
                case SkillName.Wrestling:
                case SkillName.Meditation:
                case SkillName.Chivalry:
                case SkillName.Spellweaving:
                case SkillName.Mysticism:
                case SkillName.Throwing:
                case SkillName.Anatomy:
                    fastGain = true;
                    break;
            }

            var gc = 0d;
            var success = fastGain;
            if (!fastGain)
            {
                success = (chance >= Utility.RandomDouble());
                gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                gc += (skill.Cap - skill.Base) / skill.Cap;
                gc /= 1.4;

                gc += (1.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                gc /= 1.4;

                gc *= skill.Info.GainFactor;

                if (gc < 0.01)
                    gc = 0.01;

                if (from is BaseCreature && ((BaseCreature)from).Controlled)
                    gc *= 2;
            }

            if (AllowGain(from, skill, amObj))
            {
                if (from.Alive && (gc >= Utility.RandomDouble() || skill.Base < 10.0 || CheckGGS(from, skill) || fastGain))
                {
                    Gain(from, skill);
                    if (from.SkillsTotal >= 4500 || skill.Base >= 80.0)
                    {
                        Account acc = from.Account as Account;
                        if (acc != null)
                            acc.RemoveYoungStatus(1019036);
                    }
                }
            }

            return success;
        }

        public static void Gain(Mobile from, Skill skill)
        {
            if (from.Region.IsPartOf<Regions.Jail>())
                return;

            if (from is BaseCreature && ((BaseCreature)from).IsDeadPet)
                return;

            if (skill.SkillName == SkillName.Focus && from is BaseCreature)
                return;

            if (skill.Base < skill.Cap && skill.Lock == SkillLock.Up)
            {
                int toGain = 1;
                Skills skills = from.Skills;

                if (from is PlayerMobile && Siege.SiegeShard)
                {
                    int minsPerGain = Siege.MinutesPerGain(from, skill);

                    if (minsPerGain > 0)
                    {
                        if (Siege.CheckSkillGain((PlayerMobile)from, minsPerGain, skill))
                        {
                            if (from is PlayerMobile)
                            {
                                CheckReduceSkill((PlayerMobile)from, skills, toGain, skill);
                            }

                            if (skills.Total + toGain <= skills.Cap)
                            {
                                skill.BaseFixedPoint += toGain;
                            }
                        }

                        return;
                    }
                }

                if (skill.Base <= 10.0)
                    toGain = Utility.Random(4) + 1;
                else if (skill.Base <= 50.0)
                    toGain = Utility.RandomMinMax(0, 4) + 1;

                #region Mondain's Legacy

                if (from is PlayerMobile && Server.Engines.Quests.QuestHelper.EnhancedSkill((PlayerMobile)from, skill))
                {
                    toGain *= Utility.RandomMinMax(2, 4);
                }

                #endregion Mondain's Legacy

                #region Scroll of Alacrity

                if (from is PlayerMobile && skill.SkillName == ((PlayerMobile)from).AcceleratedSkill && ((PlayerMobile)from).AcceleratedStart > DateTime.UtcNow)
                {
                    ((PlayerMobile)from).SendLocalizedMessage(1077956); // You are infused with intense energy. You are under the effects of an accelerated skillgain scroll.
                    toGain = Utility.RandomMinMax(2, 5);
                }

                #endregion Scroll of Alacrity

                #region Skill Masteries

                else if (from is BaseCreature && (((BaseCreature)from).Controlled || ((BaseCreature)from).Summoned))
                {
                    Mobile master = ((BaseCreature)from).GetMaster();

                    if (master != null)
                    {
                        WhisperingSpell spell = SkillMasterySpell.GetSpell(master, typeof(WhisperingSpell)) as WhisperingSpell;

                        if (spell != null && master.InRange(from.Location, spell.PartyRange) && master.Map == from.Map && spell.EnhancedGainChance >= Utility.Random(100))
                        {
                            toGain = Utility.RandomMinMax(2, 5);
                        }
                    }
                }

                #endregion Skill Masteries

                if (from is PlayerMobile)
                {
                    CheckReduceSkill((PlayerMobile)from, skills, toGain, skill);
                }

                if (!from.Player || (skills.Total + toGain) <= skills.Cap)
                {
                    skill.BaseFixedPoint += toGain;

                    if (from is PlayerMobile)
                        UpdateGGS(from, skill);
                }
            }

            #region Mondain's Legacy

            if (from is PlayerMobile)
                Server.Engines.Quests.QuestHelper.CheckSkill((PlayerMobile)from, skill);

            #endregion Mondain's Legacy

            if (skill.Lock == SkillLock.Up && (!Siege.SiegeShard || !(from is PlayerMobile) || Siege.CanGainStat((PlayerMobile)from)))
            {
                SkillInfo info = skill.Info;

                // Old gain mechanic
                if (!Core.ML)
                {
                    if (from.StrLock == StatLockType.Up && (info.StrGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Str);
                    else if (from.DexLock == StatLockType.Up && (info.DexGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Dex);
                    else if (from.IntLock == StatLockType.Up && (info.IntGain / 33.3) > Utility.RandomDouble())
                        GainStat(from, Stat.Int);
                }
                else
                {
                    TryStatGain(info, from);
                }
            }
        }
    }
}