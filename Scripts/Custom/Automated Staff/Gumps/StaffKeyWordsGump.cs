//Completely Automated Staff Team - By Tresdni - Please leave this header :)  I worked hard on this system!

using System.Collections.Generic;
using Server.Network;

namespace Server.Gumps
{
    public enum StaffKeyWords
    {
        Donation,
        FactionKick,
        Gauntlet,
        Harassment,
        Hiring,
        Owner,
        RealPerson,
        Report,
        Spellweaving,
        Stuck,
        Suggestion,
        TreasuresOfTokuno,
        VetRewards,
    }

    public class StaffKeyWordsGump : Gump
    {
        public StaffKeyWordsGump(Mobile from) : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);
            AddBackground(18, 2, 241, 518, 9300);
            AddLabel(54, 24, 0x66C, @"Staff Member Key Words");  //Add your own keywords to go with cases in the StaffBot.cs!  It's unlimited as to what these guys can do!  Get creative! (This is only partially what mine do atm.)
            var keywords = new List<StaffKeyWords>
            {
                StaffKeyWords.Donation,
                StaffKeyWords.FactionKick,
                StaffKeyWords.Gauntlet,
                StaffKeyWords.Harassment,
                StaffKeyWords.Hiring,
                StaffKeyWords.Owner,
                StaffKeyWords.RealPerson,
                StaffKeyWords.Report,
                StaffKeyWords.Spellweaving,
                StaffKeyWords.Stuck,
                StaffKeyWords.Suggestion,
                StaffKeyWords.TreasuresOfTokuno,
                StaffKeyWords.VetRewards,
            };
            AddHtml(58, 61, 151, 437, @" <br /><br />" + string.Join("<br />", keywords), true, true);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}