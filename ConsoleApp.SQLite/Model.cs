using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.SQLite
{
    public class BloggingContext : DbContext
    {
        private const string TenantColumn = "TenantId";

        private readonly Guid _defaultGuid = new Guid("09a2630b-f7eb-4985-ab39-8a8ae104aebe");
        private readonly Guid _otherGuid = new Guid("396ad64b-eb53-431a-93de-f9458131ba73");

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=:memory:");
            //optionsBuilder.UseSqlite("Data Source=blogbd.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>()
                .Property(blog => blog.NullableGuid).HasDefaultValue(_defaultGuid);

            modelBuilder.Entity<Blog>()
                //.HasQueryFilter(blog => EF.Property<Guid?>(blog, TenantColumn) == DefaultGuid)
                .Property<Guid?>(TenantColumn).HasDefaultValue(_defaultGuid);

            modelBuilder.Entity<Blog>()
                .HasData(new
                {
                    BlogId = 555,
                    Url = "asdhgfsdhgasd",
                    NormalGuid = new Guid("64bbdbec-11ce-4c53-85ee-b9781a77a12f")
                });
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public Guid NormalGuid { get; set; }

        public Guid? NullableGuid { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}