using CompositionOverInheritance.Gaming;

namespace CompositionOverInheritance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var player = new Player();
            player.Update();
            player.Collide();
            player.Draw();
        }
    }
}