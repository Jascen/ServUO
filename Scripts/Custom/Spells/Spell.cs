using Server.Items;
using Server.Mobiles;
using Server.Spells.Mysticism;
using Server.Spells.Second;
using System;

namespace Server.Spells
{
    public partial class Spell
    {
        public virtual int CastRecoveryBase { get { return 8; } }
        public virtual TimeSpan GetCastDelay()
        {
            if (m_Scroll is SpellStone)
            {
                return TimeSpan.Zero;
            }

            if (m_Scroll is BaseWand)
            {
                return Core.ML ? CastDelayBase : TimeSpan.Zero; // TODO: Should FC apply to wands?
            }

            // Faster casting cap of 2 (if not using the protection spell)
            // Faster casting cap of 0 (if using the protection spell)
            // Paladin spells are subject to a faster casting cap of 4
            // Paladins with magery of 70.0 or above are subject to a faster casting cap of 2
            int fcMax = 4;

            // Chivalry capped at 2 if skill > 70
            if (CastSkill == SkillName.Necromancy || CastSkill == SkillName.Chivalry && (m_Caster.Skills[SkillName.Magery].Value >= 70.0 || m_Caster.Skills[SkillName.Mysticism].Value >= 70.0))
            {
                fcMax = 2;
            }

            int fc = AosAttributes.GetValue(m_Caster, AosAttribute.CastSpeed);
            if (fc > fcMax)
            {
                fc = fcMax;
            }

            if (ProtectionSpell.Registry.ContainsKey(m_Caster) || EodonianPotion.IsUnderEffects(m_Caster, PotionEffect.Urali))
            {
                fc = Math.Min(fcMax - 2, fc - 2);
            }

            TimeSpan baseDelay = CastDelayBase;
            TimeSpan fcDelay = TimeSpan.FromSeconds(-(CastDelayFastScalar * fc * CastDelaySecondsPerTick));
            TimeSpan delay = baseDelay + fcDelay;
            if (delay < CastDelayMinimum)
            {
                delay = CastDelayMinimum;
            }

            #region Mondain's Legacy

            if (DreadHorn.IsUnderInfluence(m_Caster))
            {
                delay.Add(delay);
            }

            #endregion Mondain's Legacy

            //return TimeSpan.FromSeconds( (double)delay / CastDelayPerSecond );
            return delay;
        }
    }
}