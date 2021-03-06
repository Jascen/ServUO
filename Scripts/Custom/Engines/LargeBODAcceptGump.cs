using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System;

namespace Server.Engines.BulkOrders
{
    public partial class LargeBODAcceptGump
    {
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1) // Ok
            {
                if (m_From.PlaceInBackpack(m_Deed))
                {
                    m_From.SendLocalizedMessage(1045152); // The bulk order deed has been placed in your backpack.
                }
                else
                {
                    m_From.SendLocalizedMessage(1045150); // There is not enough room in your backpack for the deed.
                    m_Deed.Delete();
                }
            }
            else
            {
                m_Deed.Delete();
                var player = m_From as PlayerMobile;
                if (player == null) return;
                
                if (m_Deed is LargeSmithBOD)
                {
                    player.NextSmithBulkOrder = TimeSpan.FromHours(1.0);
                }
                else if (m_Deed is LargeTailorBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeAlchemyBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeInscriptionBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeTinkerBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeCookingBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeFletchingBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
                else if (m_Deed is LargeCarpentryBOD)
                {
                    player.NextTailorBulkOrder = TimeSpan.FromHours(1);
                }
            }
        }
    }
}
