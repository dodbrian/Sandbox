using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    internal class Solid : ICollidable
    {
        public void Collide()
        {
            Console.WriteLine("Bang!");
        }
    }
}