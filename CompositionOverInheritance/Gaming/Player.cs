using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    internal class Player : GameObject
    {
        public Player() : base(new Visible(), new Movable(), new Solid())
        {
        }
    }
}