using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    internal class Movable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("Moving forward");
        }
    }
}