using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //db.Database.Migrate();
                db.Database.OpenConnection();
                db.Database.EnsureCreated();

                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    var tenantId = db.Entry(blog).Property("TenantId").CurrentValue;
                    Console.WriteLine($"Url: {blog.Url}, Nullable: {blog.NullableGuid}, Normal: {blog.NormalGuid}, TenantId: {tenantId}");
                }
            }
        }
    }
}
