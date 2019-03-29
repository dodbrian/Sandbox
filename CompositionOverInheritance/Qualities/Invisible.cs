using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    internal class Invisible : IVisible
    {
        public void Draw()
        {
            Console.WriteLine("I won't appear");
        }
    }
}