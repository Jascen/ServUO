using Server.Mobiles;

namespace Server.Engines.BulkOrders
{
    public partial class BulkOrderSystem
    {
        public static Item CreateBulkOrder(Mobile m, BODType type, bool fromContextMenu)
        {
            PlayerMobile pm = m as PlayerMobile;

            if (pm == null)
                return null;

            if (pm.AccessLevel > AccessLevel.Player || fromContextMenu || 0.2 > Utility.RandomDouble())
            {
                SkillName sk = GetSkillForBOD(type);
                double theirSkill = pm.Skills[sk].Base;
                bool doLarge = theirSkill >= 70.1 && ((theirSkill - 70.0) / 300.0) > Utility.RandomDouble();

                switch (type)
                {
                    case BODType.Smith:
                        if (doLarge) return new LargeSmithBOD();
                        else return SmallSmithBOD.CreateRandomFor(pm);
                    case BODType.Tailor:
                        if (doLarge) return new LargeTailorBOD();
                        else return SmallTailorBOD.CreateRandomFor(pm);
                    case BODType.Alchemy:
                        if (doLarge) return new LargeAlchemyBOD();
                        else return SmallAlchemyBOD.CreateRandomFor(pm);
                    case BODType.Inscription:
                        if (doLarge) return new LargeInscriptionBOD();
                        else return SmallInscriptionBOD.CreateRandomFor(pm);
                    case BODType.Tinkering:
                        if (doLarge) return new LargeTinkerBOD();
                        else return SmallTinkerBOD.CreateRandomFor(pm);
                    case BODType.Cooking:
                        if (doLarge) return new LargeCookingBOD();
                        else return SmallCookingBOD.CreateRandomFor(pm);
                    case BODType.Fletching:
                        if (doLarge) return new LargeFletchingBOD();
                        else return SmallFletchingBOD.CreateRandomFor(pm);
                    case BODType.Carpentry:
                        if (doLarge) return new LargeCarpentryBOD();
                        else return SmallCarpentryBOD.CreateRandomFor(pm);
                }
            }

            return null;
        }
    }
}
