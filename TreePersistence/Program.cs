using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TreePersistence
{
    class Program
    {
        static void Main(string[] args)
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
