using System;
using System.Threading.Tasks;

namespace Sandbox.Common
{
    public static class ColoredConsole
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ForegroundColor = currentColor;
        }

        public static async Task WriteLineAsync(string text, ConsoleColor color)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            await Console.Out.WriteLineAsync(text);

            Console.ForegroundColor = currentColor;
        }
    }
}
