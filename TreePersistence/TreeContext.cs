using System;
using Microsoft.EntityFrameworkCore;

namespace TreePersistence
{
    class TreeContext : DbContext
    {
        private readonly Guid RootNodeId = Guid.NewGuid();
        private readonly Guid Level2NodeId = Guid.NewGuid();

        public DbSet<TreeNode> TreeNodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=:memory:");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<TreeNode>()
                .HasData(
                new TreeNode
                {
                    Id = RootNodeId,
                    Name = "Root node",
                },
                new TreeNode
                {
                    Id = Level2NodeId,
                    Name = "Level 2 node 1",
                    ParentId = RootNodeId,
                },
                new TreeNode
                {
                    Id = Guid.NewGuid(),
                    ParentId = Level2NodeId,
                    Name = "Level 3 node 1",
                },
                new TreeNode
                {
                    Id = Guid.NewGuid(),
                    ParentId = RootNodeId,
                    Name = "Level 2 node 2",
                });
        }
    }
}
