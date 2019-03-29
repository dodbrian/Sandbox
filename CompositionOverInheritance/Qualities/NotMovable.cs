using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    internal class NotMovable : IUpdatable
    {
        public void Update()
        {
            Console.WriteLine("I'm staying put");
        }
    }
}