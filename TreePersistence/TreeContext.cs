using System;
using Microsoft.EntityFrameworkCore;

namespace TreePersistence
{
    internal class TreeContext : DbContext
    {
        private readonly Guid _rootNodeId = Guid.NewGuid();
        private readonly Guid _level2NodeId = Guid.NewGuid();

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
                    Id = _rootNodeId,
                    Name = "Root node",
                },
                new TreeNode
                {
                    Id = _level2NodeId,
                    Name = "Level 2 node 1",
                    ParentId = _rootNodeId,
                },
                new TreeNode
                {
                    Id = Guid.NewGuid(),
                    ParentId = _level2NodeId,
                    Name = "Level 3 node 1",
                },
                new TreeNode
                {
                    Id = Guid.NewGuid(),
                    ParentId = _rootNodeId,
                    Name = "Level 2 node 2",
                });
        }
    }
}
