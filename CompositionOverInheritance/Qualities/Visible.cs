using System;
using CompositionOverInheritance.Interfaces;

namespace CompositionOverInheritance.Qualities
{
    public class Visible : IVisible
    {
        public void Draw()
        {
            Console.WriteLine("I'm showing myself");
        }
    }
}