using Microsoft.EntityFrameworkCore;

namespace Sandbox
{
    public class SandboxContext : DbContext
    {
        public SandboxContext() : base(new DbContextOptions<SandboxContext>()) { }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("Host=localhost;Database=mydatabase;Username=postgres;Password=devpassword");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Parent>()
                .HasMany(x => x.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
