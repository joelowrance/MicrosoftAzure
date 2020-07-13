using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsIsland.Catalog.Infrastructure.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    PricePerDay = table.Column<decimal>(nullable: false),
                    AvailableForRent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailableForRent", "Brand", "Model", "PricePerDay" },
                values: new object[,]
                {
                    { new Guid("44bdfdb4-604d-4ef3-b923-75bd240c630f"), true, "BMW", "320", 200m },
                    { new Guid("fd6b2ec5-4751-49c1-a006-73d63cd6310a"), true, "Audi", "A1", 120m },
                    { new Guid("21655889-d6bf-4d4a-86c9-faebc42da1a3"), true, "Mercedes", "E200", 250m },
                    { new Guid("e5d54404-ea0f-47bc-8ed9-795ac9eb1114"), true, "Ford", "Focus", 90m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
