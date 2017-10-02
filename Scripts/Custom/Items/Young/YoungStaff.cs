using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Items.Young
{
    public class YoungStaff : QuarterStaff
    {
        [Constructable]
        public YoungStaff()
        {
            Attributes.RegenMana = 5;
            Attributes.LowerRegCost = 100;
            Attributes.SpellChanneling = 1;
            Hue = 0x481;
            Weight = 0;
            LootType = LootType.Blessed;
        }

        public YoungStaff(Serial serial)
            : base(serial)
        {
        }

        public override int AosMaxDamage
        {
            get
            {
                return 1;
            }
        }

        public override int AosMinDamage
        {
            get
            {
                return 1;
            }
        }

        public override int AosSpeed
        {
            get
            {
                return 48;
            }
        }

        public override int AosStrengthReq
        {
            get
            {
                return 10;
            }
        }

        public override string DefaultName
        {
            get
            {
                return "A Young Mage's Staff";
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
            if (player.GameTime.TotalHours < 40) return base.CanEquip(from);

            player.SendMessage("Your character is too old to use this.");
            return false;
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