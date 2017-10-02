// Auto Split Gold v1.1.0
// Author: Felladrin
// Started: 2013-07-12
// Updated: 2016-01-20

// Istallation:
// On Scripts/Items/Misc/Corpses/Corpse.cs find the method:
// CheckLift(Mobile from, Item item, ref LRReason reject)
// Then, above its last 'return' statement, add the following line:
// if (Felladrin.Automations.AutoSplitGold.Split(from, item)) return false;

using System;
using System.Linq;
using Server;
using Server.Commands;
using Server.Engines.PartySystem;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;

namespace Felladrin.Automations
{
    public static class AutoSplitGold
    {
        public static void Initialize()
        {
            CommandSystem.Register("SplitGold", AccessLevel.Player, new CommandEventHandler(SplitGold_OnCommand));
        }

        public static bool Split(Mobile from, Item item)
        {
            if (!(item is Gold) || from.Party == null || item.Amount < ((Party)from.Party).Members.Count) return false;

            var party = Party.Get(from);

            // Only split with players who also split.
            var playerSplit = party.Members.Count(m => ((PlayerMobile) m.Mobile).SplitGoldWithParty);
            int share = item.Amount / playerSplit;

            foreach (var info in party.Members)
            {
                var partyMember = info.Mobile as PlayerMobile;
                if (partyMember == null || partyMember.Backpack == null) continue;
                if (!partyMember.SplitGoldWithParty) continue;

                var receiverGold = partyMember.Backpack.FindItemByType<Gold>();

                if (receiverGold != null)
                    receiverGold.Amount += share;
                else
                    partyMember.Backpack.DropItem(new Gold(share));

                partyMember.PlaySound(item.GetDropSound());

                // Your share
                if (partyMember == from)
                {
                    from.SendMessage("You take some gold from the corpse and share with {1} party members: {0} for each.", share, playerSplit);
                    
                    int rest = item.Amount % party.Members.Count;

                    if (rest > 0)
                    {
                        var sharerGold = from.Backpack.FindItemByType<Gold>();

                        if (sharerGold != null)
                            sharerGold.Amount += rest;
                        else
                            from.Backpack.DropItem(new Gold(rest));

                        from.SendMessage("You keep the {0} gold left over.", rest);
                    }
                }
                else // Their share
                {
                    partyMember.SendMessage("{0} takes some gold from the corpse and shares with the party: {1} for each.", from.Name, share);

                    if (WeightOverloading.IsOverloaded(partyMember))
                    {
                        receiverGold.Amount -= share;

                        var sharerGold = from.Backpack.FindItemByType<Gold>();

                        if (sharerGold != null)
                            sharerGold.Amount += share;
                        else
                            from.Backpack.DropItem(new Gold(share));

                        partyMember.SendMessage("But {0} keeps your share, because you are overloaded.", (from.Female ? "she" : "he"));

                        from.SendMessage("You keep {0}'s share, who is overloaded.", partyMember.Name);
                    }
                }
            }

            item.Delete();

            return true;
        }

        [Usage("SplitGold")]
        [Description("Looted gold is split evenly with the party.")]
        private static void SplitGold_OnCommand(CommandEventArgs e)
        {
            var player = e.Mobile as PlayerMobile;
            if (player == null) return;

            if (player.SplitGoldWithParty)
            {
                player.SendMessage("You stop sharing gold with your party.");
                player.SplitGoldWithParty = false;
            }
            else
            {
                player.SendMessage("You have elected to split gold with your party.");
                player.SplitGoldWithParty = true;
            }
        }
    }
}

namespace Server.Items
{
    public partial class Corpse
    {
        public override bool CheckLift(Mobile from, Item item, ref LRReason reject)
        {
            if (!base.CheckLift(from, item, ref reject)) return false;
            if (Felladrin.Automations.AutoSplitGold.Split(from, item)) return false;

            return CanLoot(from, item);
        }
    }
}