using CompositionOverInheritance.Interfaces;
using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    class Building : GameObject
    {
        public Building() : base(new Visible(), new NotMovable(), new Solid()) { }
    }
}