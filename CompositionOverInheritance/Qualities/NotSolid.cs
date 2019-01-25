using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    class NotSolid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Splash!");
        }
    }
}