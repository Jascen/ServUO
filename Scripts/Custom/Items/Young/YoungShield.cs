using System.Linq;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Items.Young
{
    public class YoungShield : Buckler
    {
        [Constructable]
        public YoungShield()
        {
            Attributes.RegenHits = 10;
            SetSelfRepair = 5;
            Hue = 0x481;
            Weight = 0;
            LootType = LootType.Blessed;
        }

        public YoungShield(Serial serial)
            : base(serial)
        {
        }

        public override int AosStrReq
        {
            get
            {
                return 10;
            }
        }

        public override int BaseColdResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BaseEnergyResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BaseFireResistance
        {
            get
            {
                return 0;
            }
        }

        public override int BasePhysicalResistance
        {
            get
            {
                return 20;
            }
        }

        public override int BasePoisonResistance
        {
            get
            {
                return 0;
            }
        }

        public override string DefaultName
        {
            get
            {
                return "A Young Warrior's Shield";
            }
        }

        public override int InitMaxHits
        {
            get { return 255; }
        }

        public override int InitMinHits
        {
            get { return 255; }
        }

        public override bool CanEquip(Mobile from)
        {
            var player = from as PlayerMobile;
            if (player == null) return base.CanEquip(from);

            if (player.GameTime.TotalHours > 40)
            {
                player.SendMessage("Your character is too old to use this.");
                return false;
            }

            if (from.Skills.Parry.Value >= 100)
            {
                player.SendMessage("Your character is already a master with this skill.");
                return false;
            }

            return base.CanEquip(from);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
}