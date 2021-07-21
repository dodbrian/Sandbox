using System;
using System.Linq;

namespace Sandbox
{
    public static class SpecialFolders
    {
        public static void Display()
        {
            var specialFolders = Enum
                .GetValues(typeof(Environment.SpecialFolder))
                .OfType<Environment.SpecialFolder>()
                .Select(x => (name: x, path: Environment.GetFolderPath(x)))
                .Where(tuple => !string.IsNullOrEmpty(tuple.path))
                .ToList();

            specialFolders.ForEach(folder => Console.WriteLine($"{folder.name}\t{folder.path}"));
        }
    }
}