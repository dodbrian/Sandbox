using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TreePersistence
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            using var db = new TreeContext();

            db.Database.OpenConnection();
            db.Database.EnsureCreated();

            var nodes = db.TreeNodes
                .ToList()
                .Where(node => node.ParentId == null)
                .ToList();

            //Console.WriteLine(JsonSerializer.Serialize(nodes.First()));
        }
    }
}
