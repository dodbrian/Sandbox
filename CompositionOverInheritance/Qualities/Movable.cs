using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    class Movable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("Moving forward");
        }
    }
}