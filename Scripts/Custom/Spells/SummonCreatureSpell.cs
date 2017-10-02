using Server.Mobiles;
using System;

namespace Server.Spells.Fifth
{
    public partial class SummonCreatureSpell
    {
        private static readonly Type[] m_Types = new Type[]
        {
            typeof(RidableLlama),
            typeof(DesertOstard),
            typeof(ForestOstard),
            typeof(FrenziedOstard),
            typeof(Horse),
            typeof(Ridgeback),
            typeof(SavageRidgeback),
        };
    }
}