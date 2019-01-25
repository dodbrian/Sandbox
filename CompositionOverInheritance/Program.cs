using System;
using CompositionOverInheritance.Gaming;

namespace CompositionOverInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.Update();
            player.Collide();
            player.Draw();
        }
    }
}
