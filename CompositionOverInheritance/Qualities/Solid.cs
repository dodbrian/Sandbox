using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    class Solid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Bang!");
        }
    }
}