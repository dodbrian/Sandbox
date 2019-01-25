using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Gaming
{
    abstract class GameObject : IUpdatable, IVisible, ICollidable
    {
        private readonly IVisible _visible;
        private readonly IUpdatable _updatable;
        private readonly ICollidable _collidable;

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

        public void Draw()
        {
            _visible.Draw();
        }

        public void Update()
        {
            _updatable.Update();
        }
    }
}