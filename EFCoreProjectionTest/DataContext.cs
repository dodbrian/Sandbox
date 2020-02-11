using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjectionTest
{
    public class DataContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }

        public DbSet<Subarea> Subareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DenisTest;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var areas = new Area[]
            {
                new Area
                {
                    Id = Guid.NewGuid(),
                    Name = "Area1"
                },
                new Area
                {
                    Id = Guid.NewGuid(),
                    Name = "Area2",
                },
                new Area
                {
                    Id = Guid.NewGuid(),
                    Name = "Area3",
                },
            };

            var subareas = new Subarea[]
            {
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea1", AreaId = areas[0].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea2", AreaId = areas[0].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea3", AreaId = areas[0].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea4", AreaId = areas[1].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea5", AreaId = areas[1].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea6", AreaId = areas[1].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea7", AreaId = areas[1].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea8", AreaId = areas[2].Id },
                new Subarea { Id = Guid.NewGuid(), Name = "Subarea9", AreaId = areas[2].Id },
            };

            //modelBuilder
            //    .Entity<Area>()
            //    .HasData(areas);

            //modelBuilder
            //    .Entity<Subarea>()
            //    .HasData(subareas);
        }
    }
}
