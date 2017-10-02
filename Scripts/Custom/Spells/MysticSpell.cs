using System;

namespace Server.Spells.Mysticism
{
    public abstract partial class MysticSpell
    {
        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(0.5 + CastDelaySecondsPerTick * (int)Circle + 0.05 * (5 - (int)Circle)); } }
    }
}