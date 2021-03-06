﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConsoleApp.SQLite.Migrations
{
    [DbContext(typeof(BloggingContext))]
    internal class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("ConsoleApp.SQLite.Blog", b =>
            {
                b.Property<int>("BlogId")
                    .ValueGeneratedOnAdd();

                b.Property<Guid>("NormalGuid");

                b.Property<Guid?>("NullableGuid")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(new Guid("09a2630b-f7eb-4985-ab39-8a8ae104aebe"));

                b.Property<Guid?>("TenantId")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(new Guid("09a2630b-f7eb-4985-ab39-8a8ae104aebe"));

                b.Property<string>("Url");

                b.HasKey("BlogId");

                b.ToTable("Blogs");

                b.HasData(
                    new
                    {
                        BlogId = 555, NormalGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                        Url = "asdhgfsdhgasd"
                    }
                );
            });

            modelBuilder.Entity("ConsoleApp.SQLite.Post", b =>
            {
                b.Property<int>("PostId")
                    .ValueGeneratedOnAdd();

                b.Property<int>("BlogId");

                b.Property<string>("Content");

                b.Property<string>("Title");

                b.HasKey("PostId");

                b.HasIndex("BlogId");

                b.ToTable("Posts");
            });

            modelBuilder.Entity("ConsoleApp.SQLite.Post", b =>
            {
                b.HasOne("ConsoleApp.SQLite.Blog", "Blog")
                    .WithMany("Posts")
                    .HasForeignKey("BlogId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}