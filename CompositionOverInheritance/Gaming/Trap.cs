using CompositionOverInheritance.Interfaces;
using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    class Trap : GameObject
    {
        public Trap() : base(new Invisible(), new NotMovable(), new Solid()) { }
    }
}