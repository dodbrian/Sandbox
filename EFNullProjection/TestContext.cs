using Microsoft.EntityFrameworkCore;

namespace EFNullProjection;

public class TestContext : DbContext
{
    public DbSet<Label> Labels { get; set; }
    public DbSet<Craft> Crafts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=:memory:").EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var labelGuid = Guid.NewGuid();

        modelBuilder.Entity<Label>()
            .HasData(
                new Label
                {
                    Id = labelGuid,
                    Name = "Test Item 1"
                });

        modelBuilder.Entity<Craft>()
            .HasData(
                new Craft
                {
                    Id = Guid.NewGuid(),
                    Name = "Craft 1",
                    // LabelId = labelGuid
                });
    }
}
