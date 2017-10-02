using Server.Items;
using System;

namespace Server
{
    public partial class Loot
    {
        private static readonly Type[] m_JewelryTypes = new[]
        {
            typeof(GoldRing), typeof(GoldBracelet), typeof(SilverRing), typeof(SilverBracelet),
            typeof(GoldEarrings), typeof(GoldNecklace), typeof(SilverEarrings), typeof(SilverNecklace)
        };
    }
}