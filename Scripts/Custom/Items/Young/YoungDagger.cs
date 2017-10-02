using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Items.Young
{
    public class YoungDagger : Dagger
    {
        [Constructable]
        public YoungDagger()
        {
            Attributes.RegenHits = 10;
            Hue = 0x481;
            Weight = 0;
            LootType = LootType.Blessed;
        }

        public YoungDagger(Serial serial)
            : base(serial)
        {
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
                return "A Young Warrior's Dagger";
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

            if (from.Skills.Fencing.Value >= 100)
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

        public override void OnHit(Mobile attacker, IDamageable defender, double damageBonus)
        {
            HealthOrb.DropHealthOrb(attacker);
            base.OnHit(attacker, defender, damageBonus);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }
    }
}