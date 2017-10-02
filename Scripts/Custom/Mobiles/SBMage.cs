using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public partial class SBMage
    {
        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(Spellbook), 18, 10, 0xEFA, 0));

                if (Core.AOS)
                {
                    Add(new GenericBuyInfo(typeof(NecromancerSpellbook), 115, 10, 0x2253, 0));
                }

                Add(new GenericBuyInfo(typeof(ScribesPen), 8, 10, 0xFBF, 0));

                Add(new GenericBuyInfo(typeof(BlankScroll), 5, 20, 0x0E34, 0));

                Add(new GenericBuyInfo("1041072", typeof(MagicWizardsHat), 11, 10, 0x1718, Utility.RandomDyedHue()));

                Add(new GenericBuyInfo(typeof(RecallRune), 15, 10, 0x1F14, 0));

                Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 10, 0xF0B, 0));
                Add(new GenericBuyInfo(typeof(AgilityPotion), 15, 10, 0xF08, 0));
                Add(new GenericBuyInfo(typeof(NightSightPotion), 15, 10, 0xF06, 0));
                Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 10, 0xF0C, 0));
                Add(new GenericBuyInfo(typeof(StrengthPotion), 15, 10, 0xF09, 0));
                Add(new GenericBuyInfo(typeof(LesserPoisonPotion), 15, 10, 0xF0A, 0));
                Add(new GenericBuyInfo(typeof(LesserCurePotion), 15, 10, 0xF07, 0));
                Add(new GenericBuyInfo(typeof(LesserExplosionPotion), 21, 10, 0xF0D, 0));

                Add(new GenericBuyInfo(typeof(BagOfReagents), 1500, 20, 0xE76, 0));
                Add(new GenericBuyInfo(typeof(BlackPearl), 5, 50, 0xF7A, 0));
                Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
                Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(SpidersSilk), 3, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 3, 20, 0xF8C, 0));

                if (Core.AOS)
                {
                    Add(new GenericBuyInfo(typeof(BatWing), 3, 20, 0xF78, 0));
                    Add(new GenericBuyInfo(typeof(DaemonBlood), 6, 20, 0xF7D, 0));
                    Add(new GenericBuyInfo(typeof(PigIron), 5, 20, 0xF8A, 0));
                    Add(new GenericBuyInfo(typeof(NoxCrystal), 6, 20, 0xF8E, 0));
                    Add(new GenericBuyInfo(typeof(GraveDust), 3, 20, 0xF8F, 0));
                }

                Type[] mageryScrollTypes = Loot.RegularScrollTypes;
                // List for Indexes
                List<KeyValuePair<string, int>> mageryScrolls = DefaultMageryScrolls();
                for (int circle = 1; circle <= 8; circle++)
                {
                    var spellIndices = GetUniqueRandomScrolls(circle, 1);
                    foreach (int spellIndex in spellIndices)
                    {
                        Add(new GenericBuyInfo(mageryScrollTypes[spellIndex], 48 * circle, 1, mageryScrolls[spellIndex].Value, 0));
                    }
                }
            }

            private List<KeyValuePair<string, int>> DefaultMageryScrolls()
            {
                List<KeyValuePair<string, int>> mageryScrolls = new List<KeyValuePair<string, int>>(); // Scrolls List
                // First Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("ClumsyScroll", 0x1F2E));
                mageryScrolls.Add(new KeyValuePair<string, int>("CreateFoodScroll", 0x1F2F));
                mageryScrolls.Add(new KeyValuePair<string, int>("FeeblemindScroll", 0x1F30));
                mageryScrolls.Add(new KeyValuePair<string, int>("HealScroll", 0x1F31));
                mageryScrolls.Add(new KeyValuePair<string, int>("MagicArrowScroll", 0x1F32));
                mageryScrolls.Add(new KeyValuePair<string, int>("NightSightScroll", 0x1F33));
                mageryScrolls.Add(new KeyValuePair<string, int>("ReactiveArmorScroll", 0x1F2D));
                mageryScrolls.Add(new KeyValuePair<string, int>("WeakenScroll", 0x1F34));

                // Second Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("AgilityScroll", 0x1F35));
                mageryScrolls.Add(new KeyValuePair<string, int>("CunningScroll", 0x1F36));
                mageryScrolls.Add(new KeyValuePair<string, int>("CureScroll", 0x1F37));
                mageryScrolls.Add(new KeyValuePair<string, int>("HarmScroll", 0x1F38));
                mageryScrolls.Add(new KeyValuePair<string, int>("MagicTrapScroll", 0x1F39));
                mageryScrolls.Add(new KeyValuePair<string, int>("MagicUnTrapScroll", 0x1F3A));
                mageryScrolls.Add(new KeyValuePair<string, int>("ProtectionScroll", 0x1F3B));
                mageryScrolls.Add(new KeyValuePair<string, int>("StrengthScroll", 0x1F3C));

                // Third Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("BlessScroll", 0x1F3D));
                mageryScrolls.Add(new KeyValuePair<string, int>("FireballScroll", 0x1F3E));
                mageryScrolls.Add(new KeyValuePair<string, int>("MagicLockScroll", 0x1F3F));
                mageryScrolls.Add(new KeyValuePair<string, int>("PoisonScroll", 0x1F40));
                mageryScrolls.Add(new KeyValuePair<string, int>("TelekinisisScroll", 0x1F41));
                mageryScrolls.Add(new KeyValuePair<string, int>("TeleportScroll", 0x1F42));
                mageryScrolls.Add(new KeyValuePair<string, int>("UnlockScroll", 0x1F43));
                mageryScrolls.Add(new KeyValuePair<string, int>("WallOfStoneScroll", 0x1F44));

                // Fourth Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("ArchcureScroll", 0x1F45));
                mageryScrolls.Add(new KeyValuePair<string, int>("ArchProtectionScroll", 0x1F46));
                mageryScrolls.Add(new KeyValuePair<string, int>("CurseScroll", 0x1F47));
                mageryScrolls.Add(new KeyValuePair<string, int>("FireFieldScroll", 0x1F48));
                mageryScrolls.Add(new KeyValuePair<string, int>("GreaterHealScroll", 0x1F49));
                mageryScrolls.Add(new KeyValuePair<string, int>("LightningScroll", 0x1F4A));
                mageryScrolls.Add(new KeyValuePair<string, int>("ManaDrainScroll", 0x1F4B));
                mageryScrolls.Add(new KeyValuePair<string, int>("RecallScroll", 0x1F4C));

                // Fifth Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("BladeSpiritsScroll", 0x1F4D));
                mageryScrolls.Add(new KeyValuePair<string, int>("DispelFieldScroll", 0x1F4E));
                mageryScrolls.Add(new KeyValuePair<string, int>("IncognitoScroll", 0x1F4F));
                mageryScrolls.Add(new KeyValuePair<string, int>("MagicReflectScroll", 0x1F50));
                mageryScrolls.Add(new KeyValuePair<string, int>("MindBlastScroll", 0x1F51));
                mageryScrolls.Add(new KeyValuePair<string, int>("ParalyzeScroll", 0x1F52));
                mageryScrolls.Add(new KeyValuePair<string, int>("PoisonFieldScroll", 0x1F53));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonCreatureScroll", 0x1F54));

                // Sixth Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("DispelScroll", 0x1F55));
                mageryScrolls.Add(new KeyValuePair<string, int>("EnergyBoltScroll", 0x1F56));
                mageryScrolls.Add(new KeyValuePair<string, int>("ExplosionScroll", 0x1F57));
                mageryScrolls.Add(new KeyValuePair<string, int>("InvisibilityScroll", 0x1F58));
                mageryScrolls.Add(new KeyValuePair<string, int>("MarkScroll", 0x1F59));
                mageryScrolls.Add(new KeyValuePair<string, int>("MassCurseScroll", 0x1F5A));
                mageryScrolls.Add(new KeyValuePair<string, int>("ParalyzeFieldSpell", 0x1F5B));
                mageryScrolls.Add(new KeyValuePair<string, int>("RevealScroll", 0x1F5C));

                // Seventh Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("ChainLightningScroll", 0x1F5D));
                mageryScrolls.Add(new KeyValuePair<string, int>("EnergyFieldScroll", 0x1F5E));
                mageryScrolls.Add(new KeyValuePair<string, int>("FlamestrikeScroll", 0x1F5F));
                mageryScrolls.Add(new KeyValuePair<string, int>("GateTravelScroll", 0x1F60));
                mageryScrolls.Add(new KeyValuePair<string, int>("ManaVampireScroll", 0x1F61));
                mageryScrolls.Add(new KeyValuePair<string, int>("MassDispelScroll", 0x1F62));
                mageryScrolls.Add(new KeyValuePair<string, int>("MeteorStormScroll", 0x1F63));
                mageryScrolls.Add(new KeyValuePair<string, int>("PolymorphScroll", 0x1F64));

                // Eighth Circle Scrolls
                mageryScrolls.Add(new KeyValuePair<string, int>("EarthquakeScroll", 0x1F65));
                mageryScrolls.Add(new KeyValuePair<string, int>("EnergyVortexScroll", 0x1F66));
                mageryScrolls.Add(new KeyValuePair<string, int>("ResurrectionScroll", 0x1F67));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonAirElementalScroll", 0x1F68));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonDaemonScroll", 0x1F69));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonEarthElementalScroll", 0x1F6A));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonFireElementalScroll", 0x1F6B));
                mageryScrolls.Add(new KeyValuePair<string, int>("SummonWaterElementalScroll", 0x1F6C));

                mageryScrolls.Sort((x, y) => x.Value.CompareTo(y.Value)); // Order by ItemID

                return mageryScrolls;
            }

            private List<int> GetUniqueRandomScrolls(int circle, int quantity)
            {
                List<int> selectedSpellIndexes = new List<int>();
                Random rnd = new Random((int)DateTime.Now.Ticks);

                int bottomSpellIndex, topSpellIndex;
                // All Circles
                if (circle == 0)
                {
                    bottomSpellIndex = 0;
                    topSpellIndex = 63;
                }
                else
                {
                    bottomSpellIndex = (circle - 1) * 8;
                    topSpellIndex = bottomSpellIndex + 7;
                }

                for (int i = 1; i <= quantity; i++)
                {
                    int currentSpellIndex = rnd.Next(bottomSpellIndex, topSpellIndex);
                    while (selectedSpellIndexes.Contains(currentSpellIndex))
                    {
                        currentSpellIndex = rnd.Next(bottomSpellIndex, topSpellIndex);
                    }

                    selectedSpellIndexes.Add(currentSpellIndex);
                }

                return selectedSpellIndexes;
            }
        }
    }
}