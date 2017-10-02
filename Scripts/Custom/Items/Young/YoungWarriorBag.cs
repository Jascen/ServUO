using Server.Items;

namespace Server.Custom.Items.Young
{
    public class YoungWarriorBag : Bag
    {
        [Constructable]
        public YoungWarriorBag()
            : this(1)
        {
            Movable = true;
            Hue = 0x481;
        }

        [Constructable]
        public YoungWarriorBag(int amount)
        {
            DropItem(new YoungDagger());
            DropItem(new YoungKatana());
            DropItem(new YoungTessen());
            DropItem(new YoungShield());
        }

        public YoungWarriorBag(Serial serial)
            : base(serial)
        {
        }

        public override string DefaultName
        {
            get
            {
                return "A Young Warrior's Bag";
            }
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