using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    internal class Trap : GameObject
    {
        public Trap() : base(new Invisible(), new NotMovable(), new Solid())
        {
        }
    }
}