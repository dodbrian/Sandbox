using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreProjectionTest.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subareas_Areas_AreaId",
                table: "Subareas");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "Subareas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2ac3c4f6-bc48-4c46-9cf3-941278f8750f"), "Area1" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"), "Area2" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a9618afd-daa7-48fb-99e3-1d632a72778a"), "Area3" });

            migrationBuilder.InsertData(
                table: "Subareas",
                columns: new[] { "Id", "AreaId", "Name" },
                values: new object[,]
                {
                    { new Guid("e3d57630-8cc2-4c56-b472-ac48c3e7f0d7"), new Guid("2ac3c4f6-bc48-4c46-9cf3-941278f8750f"), "Subarea1" },
                    { new Guid("f4c63692-acea-4978-a270-f560878f5a58"), new Guid("2ac3c4f6-bc48-4c46-9cf3-941278f8750f"), "Subarea2" },
                    { new Guid("78bc9112-4aa3-418f-9181-4fc4628c7630"), new Guid("2ac3c4f6-bc48-4c46-9cf3-941278f8750f"), "Subarea3" },
                    { new Guid("2da08f02-e6ee-436e-9776-4d48a73e6c21"), new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"), "Subarea4" },
                    { new Guid("4616a938-2add-4a51-9aca-6bbd3c9dd815"), new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"), "Subarea5" },
                    { new Guid("980b5807-b519-4038-9a04-8a0a96b60be2"), new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"), "Subarea6" },
                    { new Guid("8d07713f-2033-4bcf-959e-e8cbfaacd63e"), new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"), "Subarea7" },
                    { new Guid("0ce400d2-3dff-41d4-8241-7461b7f81905"), new Guid("a9618afd-daa7-48fb-99e3-1d632a72778a"), "Subarea8" },
                    { new Guid("585eecc6-c3b0-416a-a8a5-6a9240b2debe"), new Guid("a9618afd-daa7-48fb-99e3-1d632a72778a"), "Subarea9" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Subareas_Areas_AreaId",
                table: "Subareas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subareas_Areas_AreaId",
                table: "Subareas");

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("0ce400d2-3dff-41d4-8241-7461b7f81905"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("2da08f02-e6ee-436e-9776-4d48a73e6c21"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("4616a938-2add-4a51-9aca-6bbd3c9dd815"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("585eecc6-c3b0-416a-a8a5-6a9240b2debe"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("78bc9112-4aa3-418f-9181-4fc4628c7630"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("8d07713f-2033-4bcf-959e-e8cbfaacd63e"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("980b5807-b519-4038-9a04-8a0a96b60be2"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("e3d57630-8cc2-4c56-b472-ac48c3e7f0d7"));

            migrationBuilder.DeleteData(
                table: "Subareas",
                keyColumn: "Id",
                keyValue: new Guid("f4c63692-acea-4978-a270-f560878f5a58"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("01b3bc52-a95c-4f68-aff0-75c19e0059c0"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("2ac3c4f6-bc48-4c46-9cf3-941278f8750f"));

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: new Guid("a9618afd-daa7-48fb-99e3-1d632a72778a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "Subareas",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Subareas_Areas_AreaId",
                table: "Subareas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
