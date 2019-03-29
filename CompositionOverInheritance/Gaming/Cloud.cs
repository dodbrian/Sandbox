using CompositionOverInheritance.Qualities;

namespace CompositionOverInheritance.Gaming
{
    internal class Cloud : GameObject
    {
        public Cloud() : base(new Visible(), new Movable(), new NotSolid())
        {
        }
    }
}