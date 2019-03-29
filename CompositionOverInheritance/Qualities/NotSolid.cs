using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    internal class NotSolid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Splash!");
        }
    }
}