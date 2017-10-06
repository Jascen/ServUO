using Server.Items;
using Server.Mobiles;

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

        public Item Mutate(Mobile from, int luckChance, Item item)
        {
            if (item != null)
            {
                if (item is BaseWeapon && 1 > Utility.Random(100))
                {
                    item.Delete();
                    item = new FireHorn();
                    return item;
                }

                if (item is BaseWeapon || item is BaseArmor || item is BaseJewel || item is BaseHat)
                {
                    if (Core.AOS)
                    {
                        // Try to generate a new random item based on the creature killed
                        if (RandomItemGenerator.Enabled && from is BaseCreature)
                        {
                            if (RandomItemGenerator.GenerateRandomItem(item, ((BaseCreature)from).LastKiller, (BaseCreature)from))
                                return item;
                        }

                        int bonusProps = GetBonusProperties();
                        int min = m_MinIntensity;
                        int max = m_MaxIntensity;

                        if (bonusProps < m_MaxProps && LootPack.CheckLuck(luckChance))
                        {
                            ++bonusProps;
                        }

                        int props = 1 + bonusProps;

                        // Make sure we're not spawning items with 6 properties.
                        if (props > m_MaxProps)
                        {
                            props = m_MaxProps;
                        }

                        // Use the older style random generation
                        if (item is BaseWeapon)
                        {
                            BaseRunicTool.ApplyAttributesTo((BaseWeapon)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        }
                        else if (item is BaseArmor)
                        {
                            BaseRunicTool.ApplyAttributesTo((BaseArmor)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        }
                        else if (item is BaseJewel)
                        {
                            BaseRunicTool.ApplyAttributesTo((BaseJewel)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        }
                        else if (item is BaseHat)
                        {
                            BaseRunicTool.ApplyAttributesTo((BaseHat)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        }
                    }
                    else // not aos
                    {
                        if (item is BaseWeapon)
                        {
                            BaseWeapon weapon = (BaseWeapon)item;

                            if (80 > Utility.Random(100))
                            {
                                weapon.AccuracyLevel = (WeaponAccuracyLevel)GetRandomOldBonus();
                            }

                            if (60 > Utility.Random(100))
                            {
                                weapon.DamageLevel = (WeaponDamageLevel)GetRandomOldBonus();
                            }

                            if (40 > Utility.Random(100))
                            {
                                weapon.DurabilityLevel = (WeaponDurabilityLevel)GetRandomOldBonus();
                            }

                            if (5 > Utility.Random(100))
                            {
                                weapon.Slayer = SlayerName.Silver;
                            }

                            if (from != null && weapon.AccuracyLevel == 0 && weapon.DamageLevel == 0 && weapon.DurabilityLevel == 0 &&
                                weapon.Slayer == SlayerName.None && 5 > Utility.Random(100))
                            {
                                weapon.Slayer = SlayerGroup.GetLootSlayerType(from.GetType());
                            }
                        }
                        else if (item is BaseArmor)
                        {
                            BaseArmor armor = (BaseArmor)item;

                            if (80 > Utility.Random(100))
                            {
                                armor.ProtectionLevel = (ArmorProtectionLevel)GetRandomOldBonus();
                            }

                            if (40 > Utility.Random(100))
                            {
                                armor.Durability = (ArmorDurabilityLevel)GetRandomOldBonus();
                            }
                        }
                    }
                }
                else if (item is BaseInstrument)
                {
                    SlayerName slayer = SlayerName.None;

                    if (Core.AOS)
                    {
                        slayer = BaseRunicTool.GetRandomSlayer();
                    }
                    else
                    {
                        slayer = SlayerGroup.GetLootSlayerType(from.GetType());
                    }

                    if (slayer == SlayerName.None)
                    {
                        item.Delete();
                        return null;
                    }

                    BaseInstrument instr = (BaseInstrument)item;

                    instr.Quality = ItemQuality.Normal;
                    instr.Slayer = slayer;
                }

                if (item.Stackable)
                {
                    item.Amount = m_Quantity.Roll();
                }
            }

            return item;
        }
    }
}
