namespace Server
{
    public partial class LootPackEntry
    {
        public Item Construct(Mobile from, int luckChance, bool spawning)
        {
            if (m_AtSpawnTime != spawning)
            {
                return null;
            }

            int totalChance = 0;

            for (int i = 0; i < m_Items.Length; ++i)
            {
                totalChance += m_Items[i].Chance;
            }

            var inTokuno = Core.SE && IsInTokuno(from);
            var isMondain = Core.ML && (IsMondain(from) || (from.LastKiller != null ? from.LastKiller.Race : null) == Race.Elf);
            var isStygian = Core.SA && (IsStygian(from) || (from.LastKiller != null ? from.LastKiller.Race : null) == Race.Gargoyle);
            int rnd = Utility.Random(totalChance);
            for (int i = 0; i < m_Items.Length; ++i)
            {
                LootPackItem item = m_Items[i];
                if (rnd < item.Chance) return Mutate(from, luckChance, item.Construct(inTokuno, isMondain, isStygian));

                rnd -= item.Chance;
            }

            return null;
        }
    }
}