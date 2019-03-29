using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Gaming
{
    internal abstract class GameObject : IUpdatable, IVisible, ICollidable
    {
        private readonly ICollidable _collidable;
        private readonly IUpdatable _updatable;
        private readonly IVisible _visible;

        public GameObject(IVisible visible, IUpdatable updatable, ICollidable collidable)
        {
            _visible = visible;
            _updatable = updatable;
            _collidable = collidable;
        }

        public void Collide()
        {
            _collidable.Collide();
        }

        public void Update()
        {
            _updatable.Update();
        }

        public void Draw()
        {
            _visible.Draw();
        }
    }
}