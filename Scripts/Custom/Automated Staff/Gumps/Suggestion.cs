//This had no header on it when I found it, but credit goes to whomever wrote the suggestion box script.  I yanked it to go with our bots.  Thank you!
using Server.Accounting;
using System;
using System.IO;

namespace Server.Gumps
{
    public class Suggestion : Gump
    {
        public Suggestion()
            : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(256, 207, 298, 287, 9200);
            AddLabel(309, 224, 0, @"Suggestion Box:");//Sugestion
            AddButton(377, 464, 247, 248, (int)Buttons.Button1, GumpButtonType.Reply, 0);
            AddButton(477, 464, 242, 248, (int)Buttons.Cancel, GumpButtonType.Reply, 0);
            AddAlphaRegion(280, 251, 251, 202);
            AddImage(450, 466, 5411);
            AddImage(347, 466, 5411);
            AddTextEntry(280, 252, 253, 202, 0, (int)Buttons.TextEntry1, @"");
        }

        public enum Buttons
        {
            Cancel,
            Button1,
            TextEntry1,
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            Account acct = (Account)from.Account;

            switch (info.ButtonID)
            {
                case (int)Buttons.Cancel:
                    {
                        from.SendMessage("You decide not to send a suggestion.");
                        break;
                    }

                case (int)Buttons.Button1:
                    string tudo = (string)info.GetTextEntry((int)Buttons.TextEntry1).Text;

                    Console.WriteLine("");
                    Console.WriteLine("{0} From Account {1} Sent a suggestion", from.Name, acct.Username);//from.Name of account send a suggestion
                    Console.WriteLine("");

                    if (!Directory.Exists("Suggestions")) //create directory
                        Directory.CreateDirectory("Suggestion");

                    using (StreamWriter op = new StreamWriter("Suggestion/suggestions.txt", true))  //Suggestions get saved to this file.
                    {
                        op.WriteLine("");
                        op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
                        op.WriteLine("Message: {0}", tudo);
                        op.WriteLine("");
                    }

                    from.SendMessage("Your suggestions mean a lot to us, thank you for the input!");//thanks to send your suggestion

                    break;
            }
        }
    }
}