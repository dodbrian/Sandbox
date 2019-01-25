using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    class NotMovable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("I'm staying put");
        }
    }
}