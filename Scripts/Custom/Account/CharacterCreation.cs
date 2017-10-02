using Server.Accounting;
using Server.Engines.XmlSpawner2;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System;
using Server.Custom.Items.Young;

namespace Server.Misc
{
    public partial class CharacterCreation
    {
        private static void AddBackpack(Mobile m)
        {
            Container pack = m.Backpack;

            if (pack == null)
            {
                pack = new Backpack();
                pack.Movable = false;

                m.AddItem(pack);
            }

            PackItem(new Gold(1000)); // Starting gold can be customized here
        }

        private static void EventSink_CharacterCreated(CharacterCreatedEventArgs args)
        {
            if (!VerifyProfession(args.Profession))
                args.Profession = 0;

            NetState state = args.State;

            if (state == null)
                return;

            Mobile newChar = CreateMobile(args.Account as Account);

            if (newChar == null)
            {
                Utility.PushColor(ConsoleColor.Red);
                Console.WriteLine("Login: {0}: Character creation failed, account full", state);
                Utility.PopColor();
                return;
            }

            args.Mobile = newChar;
            m_Mobile = newChar;

            newChar.Player = true;
            newChar.AccessLevel = args.Account.AccessLevel;
            newChar.Female = args.Female;
            //newChar.Body = newChar.Female ? 0x191 : 0x190;

            if (Core.Expansion >= args.Race.RequiredExpansion)
                newChar.Race = args.Race;	//Sets body
            else
                newChar.Race = Race.DefaultRace;

            //newChar.Hue = Utility.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;
            newChar.Hue = newChar.Race.ClipSkinHue(args.Hue & 0x3FFF) | 0x8000;

            newChar.Hunger = 20;

            bool young = false;

            if (newChar is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)newChar;
                pm.AutoRenewInsurance = true;
                double skillcap = Config.Get("PlayerCaps.SkillCap", 1000.0d) / 10;
                if (skillcap != 100.0)
                {
                    for (int i = 0; i < Enum.GetNames(typeof(SkillName)).Length; ++i)
                        pm.Skills[i].Cap = skillcap;
                }
                pm.Profession = args.Profession;

                if (pm.IsPlayer() && ((Account)pm.Account).Young && !Siege.SiegeShard)
                    young = pm.Young = true;
            }

            SetName(newChar, args.Name);

            AddBackpack(newChar);

            SetStats(newChar, state, args.Str, args.Dex, args.Int);
            SetSkills(newChar, args.Skills, args.Profession);

            Race race = newChar.Race;

            if (race.ValidateHair(newChar, args.HairID))
            {
                newChar.HairItemID = args.HairID;
                newChar.HairHue = race.ClipHairHue(args.HairHue & 0x3FFF);
            }

            if (race.ValidateFacialHair(newChar, args.BeardID))
            {
                newChar.FacialHairItemID = args.BeardID;
                newChar.FacialHairHue = race.ClipHairHue(args.BeardHue & 0x3FFF);
            }

            int faceID = args.FaceID;

            if (faceID > 0 && race.ValidateFace(newChar.Female, faceID))
            {
                newChar.FaceItemID = faceID;
                newChar.FaceHue = args.FaceHue;
            }
            else
            {
                newChar.FaceItemID = race.RandomFace(newChar.Female);
                newChar.FaceHue = newChar.Hue;
            }

            if (args.Profession <= 3)
            {
                AddShirt(newChar, args.ShirtHue);
                AddPants(newChar, args.PantsHue);
                AddShoes(newChar);
            }

            if (TestCenter.Enabled)
                TestCenter.FillBankbox(newChar);

            if (young)
            {
                NewPlayerTicket ticket = new NewPlayerTicket();
                ticket.Owner = newChar;
                newChar.BankBox.DropItem(ticket);
            }

            CityInfo city = args.City;
            Map map = Siege.SiegeShard && city.Map == Map.Trammel ? Map.Felucca : city.Map;

            newChar.MoveToWorld(city.Location, map);

            Utility.PushColor(ConsoleColor.Green);
            Console.WriteLine("Login: {0}: New character being created (account={1})", state, args.Account.Username);
            Utility.PopColor();
            Utility.PushColor(ConsoleColor.DarkGreen);
            Console.WriteLine(" - Character: {0} (serial={1})", newChar.Name, newChar.Serial);
            Console.WriteLine(" - Started: {0} {1} in {2}", city.City, city.Location, city.Map.ToString());
            Utility.PopColor();

            new WelcomeTimer(newChar).Start();

            if (XmlSpawner.PointsEnabled)
                XmlAttach.AttachTo(newChar, new XmlPoints());
            if (XmlSpawner.FactionsEnabled)
                XmlAttach.AttachTo(newChar, new XmlMobFactions());
        }

        private static void SetSkills(Mobile m, SkillNameValue[] skills, int prof)
        {
            switch (prof)
            {
                case 1: // Warrior
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Anatomy, 30),
                        new SkillNameValue(SkillName.Healing, 45),
                        new SkillNameValue(SkillName.Swords, 35),
                        new SkillNameValue(SkillName.Tactics, 50)
                        };

                        break;
                    }
                case 2: // Magician
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.EvalInt, 30),
                        new SkillNameValue(SkillName.Wrestling, 30),
                        new SkillNameValue(SkillName.Magery, 50),
                        new SkillNameValue(SkillName.Meditation, 50)
                        };

                        break;
                    }
                case 3: // Blacksmith
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Mining, 30),
                        new SkillNameValue(SkillName.ArmsLore, 30),
                        new SkillNameValue(SkillName.Blacksmith, 50),
                        new SkillNameValue(SkillName.Tinkering, 50)
                        };

                        break;
                    }
                case 4: // Necromancer
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Necromancy, 50),
                        new SkillNameValue(SkillName.Focus, 30),
                        new SkillNameValue(SkillName.SpiritSpeak, 30),
                        new SkillNameValue(SkillName.Swords, 30),
                        new SkillNameValue(SkillName.Tactics, 20)
                        };

                        break;
                    }
                case 5: // Paladin
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Chivalry, 51),
                        new SkillNameValue(SkillName.Swords, 49),
                        new SkillNameValue(SkillName.Focus, 30),
                        new SkillNameValue(SkillName.Tactics, 30)
                        };

                        break;
                    }
                case 6: //Samurai
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Bushido, 50),
                        new SkillNameValue(SkillName.Swords, 50),
                        new SkillNameValue(SkillName.Anatomy, 30),
                        new SkillNameValue(SkillName.Healing, 30)
                        };
                        break;
                    }
                case 7: //Ninja
                    {
                        skills = new SkillNameValue[]
                        {
                        new SkillNameValue(SkillName.Ninjitsu, 50),
                        new SkillNameValue(SkillName.Hiding, 50),
                        new SkillNameValue(SkillName.Fencing, 30),
                        new SkillNameValue(SkillName.Stealth, 30)
                        };
                        break;
                    }
                default:
                    {
                        if (!ValidSkills(skills))
                            return;

                        break;
                    }
            }
            
            switch (prof)
            {
                case 1: // Warrior
                case 5: // Paladin
                case 6: // Samurai
                case 7: // Ninja
                    BaseWarrior();
                    break;

                default:
                    BaseCaster();
                    break;
            }
            
            for (int i = 0; i < skills.Length; ++i)
            {
                SkillNameValue snv = skills[i];

                if (snv.Value > 0 && (snv.Name != SkillName.Stealth || prof == 7) && snv.Name != SkillName.RemoveTrap && snv.Name != SkillName.Spellweaving)
                {
                    Skill skill = m.Skills[snv.Name];

                    if (skill != null)
                    {
                        skill.BaseFixedPoint = snv.Value * 10;

                        //if (addSkillItems)
                        //    AddSkillItems(snv.Name, m);
                    }
                }
            }
        }

        private static void BaseWarrior()
        {
            Spellbook ninjaBook = new BookOfNinjitsu();
            ninjaBook.LootType = LootType.Blessed;
            PackItem(ninjaBook);

            Spellbook paladinBook = new BookOfChivalry((ulong)0x3FF);
            paladinBook.LootType = LootType.Blessed;
            PackItem(paladinBook);

            EquipItem(new Robe(Utility.RandomMetalHue()));
            EquipItem(new ThighBoots(0x8FD));
            BaseItems();
        }

        private static void BaseCaster()
        {
            PackItem(new BagOfReagents(50));
            Spellbook mageBook = new Spellbook((ulong)0x382A8C38);
            mageBook.LootType = LootType.Blessed;
            PackItem(mageBook);

            PackItem(new BagOfNecroReagents(50));
            Spellbook necroBook = new NecromancerSpellbook((ulong)0x8981); // animate dead, evil omen, pain spike, summon familiar, wraith form
            necroBook.LootType = LootType.Blessed;
            PackItem(necroBook);

            EquipItem(new Robe(Utility.RandomOrangeHue()));
            EquipItem(new Sandals(0x8FD));
            BaseItems();
        }

        private static void BaseItems()
        {
            PackInstrument();
            PackItem(new Bandage(500));

            // Regardless of what they've chosen, give them the custom items.
            PackItem(new YoungWarriorBag());
            PackItem(new YoungStaff());

            // Don't let them be naked!
            EquipItem(NecroHue(new LeatherChest()));
            EquipItem(NecroHue(new LeatherArms()));
            EquipItem(NecroHue(new LeatherGloves()));
            EquipItem(NecroHue(new LeatherGorget()));
            EquipItem(NecroHue(new LeatherLegs()));
        }
    }
}