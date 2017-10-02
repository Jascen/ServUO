// Completely Automated Staff Team
//By Tresdni - www.uo-d.com (UO Dissension)
using Server.Gumps;
using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("a staff member's corpse")]
    public class StaffBot : BaseCreature
    {
        private DateTime HelpBegin = DateTime.Now;

        private bool m_Gated;

        private bool m_Talked;

        private string[] staffbotgreet = new string[] // Greeting the staff bot gives, just once :)
        {
            "Hello, I'm a Staff Bot, how may I assist you?"
        };

        [Constructable]
        public StaffBot() : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Title = "[GM]";
            CantWalk = true;
            Hue = Utility.RandomSkinHue();
            SpeechHue = Utility.RandomDyedHue();
            NameHue = 11;
            Blessed = true;

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
            }

            Skills.Cap = 9000;

            SetSkill(SkillName.Fencing, 100.0);
            SetSkill(SkillName.Macing, 100.0);
            SetSkill(SkillName.Swords, 100.0);
            SetSkill(SkillName.Tactics, 100.0);
            SetSkill(SkillName.Parry, 100.0);
            SetSkill(SkillName.Archery, 100.0);
            SetSkill(SkillName.Chivalry, 100.0);
            SetSkill(SkillName.Anatomy, 100.0);
            SetSkill(SkillName.Healing, 100.0);

            StaffRobe rob = new StaffRobe();
            rob.AccessLevel = AccessLevel.Player;
            rob.Hue = 1157;
            rob.LootType = LootType.Blessed;
            AddItem(rob);
        }

        public StaffBot(Serial serial) : base(serial)
        {
        }

        public TimeSpan HelpTime
        {
            get { return TimeSpan.FromMinutes(5); }
        } //5 minutes help time - You can set this to whatever you want.  They delete themselves.

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override bool HandlesOnSpeech(Mobile from)
        {
            if (from.InRange(Location, 5))
                return true;

            return base.HandlesOnSpeech(from);
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            Mobile m = from;
            PlayerMobile mobile = m as PlayerMobile;

            from.SendMessage("I appreciate the offer, but I do this job out of the love for the game.");  //As they should!  Free shard means free!
            return false;
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (((HelpBegin + HelpTime) <= DateTime.Now))
            {
                Delete();
            }

            if (m_Talked == false)
            {
                if (m.InRange(this, 4))
                {
                    m_Talked = true;
                    SayRandom(staffbotgreet, this);
                    m.SendMessage("Please use the key words list to get the help that you need.  This staff team member will disappear after five minutes.");
                }
            }
        }

        public override void OnSpeech(SpeechEventArgs args) //Let's handle the interactions between the player and staff member - based on key words.
        {
            string said = args.Speech.ToLower();
            if (said == StaffKeyWords.Donation.ToString().ToLower())
            {
                //Say(string.Format("If it's donation information your seeking {0}, you should go to www.yoursite.com and click donate.  It has all the info you need.", args.Mobile.Name));
                Say(string.Format("Thank you, but we are not currently accepting donations.", args.Mobile.Name));
            }
            else if (said == StaffKeyWords.FactionKick.ToString())
            {
                Say(string.Format("It takes 3 days to leave a faction {0}.  You can start the process by visiting your factions stone.", args.Mobile.Name));
            }
            else if (said == StaffKeyWords.Gauntlet.ToString().ToLower())
            {
                args.Mobile.LaunchBrowser("http://www.uoguide.com/Doom_Gauntlet#Gauntlet");
            }
            else if (said == StaffKeyWords.Harassment.ToString().ToLower())
            {
                Say(string.Format("Please remember to include screenshots in this email {0}.", args.Mobile.Name)); //change your harassment email.
                args.Mobile.LaunchBrowser("mailto:VeritasUltimaOnline@gmail.com");
            }
            else if (said == StaffKeyWords.Hiring.ToString().ToLower())
            {
                Say(string.Format("We are not currently hiring, {0}.  Thank you for asking.", args.Mobile.Name)); //Or maybe you are?
            }
            else if (said == StaffKeyWords.Owner.ToString().ToLower())
            {
                Say(string.Format("The one whom has given me the opportunity to help you is named Tsai.  I'm sure you've seen him on our forums {0}!", args.Mobile.Name));
            }
            else if (said == StaffKeyWords.RealPerson.ToString().ToLower())
            {
                Say(string.Format("So you don't think I'm doing a good job {0}?  Here, send the real guys and gals an email and let them know.", args.Mobile.Name));
                args.Mobile.LaunchBrowser("mailto:VeritasUltimaOnline@gmail.com");
            }
            else if (said == StaffKeyWords.Report.ToString().ToLower())
            {
                Say(string.Format("Did you find someone breaking the rules {0}?  Please send us an email!", args.Mobile.Name)); //change this email to whatever you want.
                args.Mobile.LaunchBrowser("mailto:VeritasUltimaOnline@gmail.com");
            }
            else if (said == StaffKeyWords.Spellweaving.ToString().ToLower())
            {
                Say(string.Format("You must complete a quest in Heartwood before you can use Spellweaving {0}.  Make sure to clear all other quests before you do so, else it may break on you.", args.Mobile.Name));
                args.Mobile.LaunchBrowser("http://www.uoguide.com/Spellweaving");
            }
            else if (said == StaffKeyWords.Stuck.ToString().ToLower())
            {
                if (m_Gated == false)
                {
                    m_Gated = true;
                    StuckGate sg = new StuckGate();
                    sg.Location = args.Mobile.Location;
                    sg.Map = args.Mobile.Map;
                    Say(string.Format("I had a feeling you couldn't make it out of here on your own {0}.", args.Mobile.Name));
                    return;
                }

                Say(string.Format("I've already sent you a gate out of here {0}.  My mana won't regenerate for another hour.", args.Mobile.Name));
            }
            else if (said == StaffKeyWords.Suggestion.ToString().ToLower())
            {
                args.Mobile.SendGump(new Suggestion());
                Say(string.Format("We would really appreciate your input {0}.", args.Mobile.Name));
            }
            else if (said == StaffKeyWords.TreasuresOfTokuno.ToString().ToLower())
            {
                args.Mobile.LaunchBrowser("http://www.uoguide.com/Treasures_of_Tokuno");
            }
            else if (said == StaffKeyWords.VetRewards.ToString().ToLower())
            {
                Say(string.Format("On Veritas, you get a veteran reward choice every 30 days {0}", args.Mobile.Name));
                args.Mobile.LaunchBrowser("http://www.uoguide.com/Veteran_Rewards");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
        }
    }
}