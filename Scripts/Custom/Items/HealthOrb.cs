/*
 *
 Scripted by Vinz Clortho (vinz.auberon@stranky.org)
 For Auberon shard (http://auberon.stranky.org/)
 (C) 2016
 */

using Server.Mobiles;
using System;
using System.Collections;

namespace Server.Items
{
    public class HealthOrb : SelfDeletingItem
    {
        [Constructable]
        public HealthOrb() : base(14265, "health orb", 50)  //Duration 50 sec
        {
            Movable = false;
            Hue = 33;
            Name = "health orb"; //We must specify Name again, because in SelfDeletingItem is little bug

            Timer.DelayCall(TimeSpan.FromSeconds(30.0), new TimerCallback(Morph)); //Morph to another ItemID 20 seconds before expiring
        }

        private void Morph()
        {
            if (this.Deleted)
                return;

            ItemID = 14270;
            Effects.PlaySound(Location, Map, 553);
        }

        public override bool HandlesOnMovement { get { return true; } }

        public override void OnMovement(Mobile from, Point3D oldLocation)
        {
            if (from.Player && from.AccessLevel == AccessLevel.Player && !from.Hidden && from.Alive && !from.Blessed && from.GetDistanceToSqrt(this) <= 1)
                Heal(from);

            base.OnMovement(from, oldLocation);
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Player || from.AccessLevel > AccessLevel.Player || from.Hidden || !from.Alive || from.Blessed)
                return;

            if (!from.InRange(this.GetWorldLocation(), 1))
                from.SendLocalizedMessage(502138);
            else
                Heal(from);
        }

        public virtual void Heal(Mobile from)
        {
            if (this.Deleted || from == null) //from = player who triggered heal (not used yet)
                return;

            ArrayList targets = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(3))
            {
                if (m == null || m.Deleted)
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned))
                {
                    if (!m.IsDeadBondedPet && m.Alive && !m.Blessed && m.InLOS(this))
                        targets.Add(m);
                }
                else if (m.Player && !m.Blessed && m.AccessLevel == AccessLevel.Player && m.Alive && m.InLOS(this))
                    targets.Add(m);
            }

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];

                if (m == null || m.Deleted)
                    continue;

                m.RevealingAction();
                //Effects.SendMovingEffect(this, m, 0x36D4, 5, 0, false, false);

                if (m.Poison != null)
                {
                    m.Poison = null;
                    m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
                    m.PlaySound(0x1E0);
                }
                else
                {
                    //m.Heal(AOS.Scale(m.HitsMax, BasePotion.Scale(m, 20))); //Heal for 20+EnhancePotions% HitsMax
                    m.Heal(20);
                    m.Mana += 20;
                    m.Stam += 20;
                    m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
                    m.PlaySound(0x1F2);
                }
            }

            this.Delete();
        }

        public override void OnDelete()
        {
            Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x374A, 9, 32, 5024);
            Effects.PlaySound(Location, Map, 0x5C9);
            base.OnDelete();
        }

        public HealthOrb(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            this.Delete();
        }

        //You can use this in BaseCreature, PlayerMobile or specific on monster in On Damage(...), OnBeforeDeath() etc.
        public static void DropHealthOrb(Mobile harmed)
        {
            if (harmed == null) return;

            // Default chance to drop is 3%
            var player = harmed as PlayerMobile;
            var chance = player != null ? player.Young ? 0.1 : 0.03 : 0.03;
            if (Utility.RandomDouble() > chance) return;

            bool validLocation = false;
            Point3D loc = harmed.Location;

            for (int j = 0; !validLocation && j < 10; ++j)
            {
                int x = harmed.X + Utility.Random(4);
                int y = harmed.Y + Utility.Random(4);
                int z = harmed.Map.GetAverageZ(x, y);

                if (validLocation = (harmed.Map.CanFit(x, y, harmed.Z, 6, false, false) && harmed.InLOS(new Point3D(x, y, harmed.Z))))
                    loc = new Point3D(x, y, harmed.Z);
                else if (validLocation = (harmed.Map.CanFit(x, y, z, 6, false, false) && harmed.InLOS(new Point3D(x, y, z))))
                    loc = new Point3D(x, y, z);
            }

            if (!validLocation)
                return;

            //HealthOrb orb = new HealthOrb();
            new HealthOrb().MoveToWorld(loc, harmed.Map);
        }
    }
}