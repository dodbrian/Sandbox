using CompositionOverInheritance.Interfaces;
using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    class Cloud : GameObject
    {
        public Cloud() : base(new Visible(), new Movable(), new NotSolid()) { }
    }
}