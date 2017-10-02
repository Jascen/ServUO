using Server.Gumps;
using Server.Misc;  //Added for Automated Staff Team
using Server.Mobiles;
using System;

namespace Server.Engines.Help
{
    public partial class HelpGump : Gump
    {
        public static TimeSpan CanHelpAgain
        {
            get { return TimeSpan.FromMinutes(60); }
        }

        private static void EventSink_HelpRequest(HelpRequestEventArgs e)
        {
            PlayerMobile pm = (PlayerMobile) e.Mobile;

            if (AutoStaffTeam.Enabled) //If automated staff team enabled, begin the new gump process.
            {
                if (pm.LastTimePaged + CanHelpAgain <= DateTime.Now || pm.AccessLevel > AccessLevel.Player)
                {
                    if (e.Mobile.HasGump(typeof(StaffKeyWordsGump)))
                    {
                        e.Mobile.CloseGump(typeof(StaffKeyWordsGump));
                        e.Mobile.SendMessage("Please close the key words gump before calling a staff member.");
                        return;
                    }
                    StaffBot sb = new StaffBot();
                    sb.MoveToWorld(e.Mobile.Location, e.Mobile.Map);
                    e.Mobile.SendGump(new StaffKeyWordsGump(e.Mobile));
                    pm.LastTimePaged = DateTime.Now;
                    return;
                }
                e.Mobile.SendMessage("You may only page a staff member once every hour.  If you need assistance now, please send an email to VeritasUO@gmail.com.");
                return;
            }

            foreach (Gump g in e.Mobile.NetState.Gumps)
            {
                if (g is HelpGump)
                    return;
            }

            if (!PageQueue.CheckAllowedToPage(e.Mobile))
                return;

            if (PageQueue.Contains(e.Mobile))
                e.Mobile.SendMenu(new ContainedMenu(e.Mobile));
            else
                e.Mobile.SendGump(new HelpGump(e.Mobile));
        }
    }
}