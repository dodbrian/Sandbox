using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.SQLite.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Blogs",
                table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    NormalGuid = table.Column<Guid>(nullable: false),
                    NullableGuid = table.Column<Guid>(nullable: true,
                        defaultValue: new Guid("09a2630b-f7eb-4985-ab39-8a8ae104aebe")),
                    TenantId = table.Column<Guid>(nullable: true,
                        defaultValue: new Guid("09a2630b-f7eb-4985-ab39-8a8ae104aebe"))
                },
                constraints: table => { table.PrimaryKey("PK_Blogs", x => x.BlogId); });

            migrationBuilder.CreateTable(
                "Posts",
                table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        "FK_Posts_Blogs_BlogId",
                        x => x.BlogId,
                        "Blogs",
                        "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Posts_BlogId",
                "Posts",
                "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Posts");

            migrationBuilder.DropTable(
                "Blogs");
        }
    }
}