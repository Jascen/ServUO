using System;

namespace Server.Spells
{
    public partial class MagerySpell
    {
        public override TimeSpan CastDelayBase
        {
            get
            {
                return TimeSpan.FromSeconds((3 + (int)this.Circle) * this.CastDelaySecondsPerTick + 0.05 * (5 - (int)Circle));
            }
        }
    }
}