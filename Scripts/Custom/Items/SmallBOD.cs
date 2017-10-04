using Server.Items;
using System;

namespace Server.Engines.BulkOrders
{
    public partial class SmallBOD
    {
        public void EndCombine(Mobile from, object o)
        {
            if (o is Item && ((Item)o).IsChildOf(from.Backpack))
            {
                Type objectType = o.GetType();
                Item item = o as Item;

                if (this.m_AmountCur >= this.m_AmountMax)
                {
                    from.SendLocalizedMessage(1045166); // The maximum amount of requested items have already been combined to this deed.
                }
                else if (this.m_Type == null || (objectType != this.m_Type && !objectType.IsSubclassOf(this.m_Type)) /*|| (!(o is BaseWeapon) && !(o is BaseArmor) && !(o is BaseClothing))*/)
                {
                    from.SendLocalizedMessage(1045169); // The item is not in the request.
                }
                else
                {
                    BulkMaterialType material = BulkMaterialType.None;

                    if (o is IResource)
                        material = GetMaterial(((IResource)o).Resource);

                    if (m_Material != BulkMaterialType.None && material != this.m_Material)
                    {
                        from.SendLocalizedMessage(1157310); // The item is not made from the requested resource.
                    }
                    else
                    {
                        bool isExceptional = false;

                        if (o is IQuality)
                            isExceptional = (((IQuality)o).Quality == ItemQuality.Exceptional);

                        if (this.m_RequireExceptional && !isExceptional)
                        {
                            from.SendLocalizedMessage(1045167); // The item must be exceptional.
                        }
                        else
                        {
                            if (item.Amount > 1)
                            {
                                if (AmountCur + item.Amount > AmountMax)
                                {
                                    from.SendLocalizedMessage(1157222); // You have provided more than which has been requested by this deed.
                                    return;
                                }
                                else
                                {
                                    AmountCur += item.Amount;
                                    item.Delete();
                                }
                            }
                            else
                            {
                                item.Delete();
                                ++this.AmountCur;
                            }

                            from.SendLocalizedMessage(1045170); // The item has been combined with the deed.

                            from.SendGump(new SmallBODGump(from, this));

                            if (this.m_AmountCur < this.m_AmountMax)
                                this.BeginCombine(from);
                        }
                    }
                }
            }
            else
            {
                from.SendLocalizedMessage(1045158); // You must have the item in your backpack to target it.
            }
        }
    }
}
