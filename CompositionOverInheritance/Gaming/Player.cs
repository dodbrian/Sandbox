using CompositionOverInheritance.Interfaces;
using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    class Player : GameObject
    {
        public Player() : base(new Visible(), new Movable(), new Solid()) { }
    }
}