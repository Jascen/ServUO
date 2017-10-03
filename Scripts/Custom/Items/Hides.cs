namespace Server.Items
{
    public partial class Hides
    {
        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (this.Deleted || !from.CanSee(this))
                return false;

            base.ScissorHelper(from, new Leather(), 1);

            return true;
        }
    }
}
