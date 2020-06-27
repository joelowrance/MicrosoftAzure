using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsIsland.Catalog.Infrastructure.Migrations
{
    public partial class createcarscatalog : Migration
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
                    PricePerWeek = table.Column<decimal>(nullable: false),
                    PricePerMonth = table.Column<decimal>(nullable: false),
                    AvailableForRent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvailableForRent", "Brand", "Model", "PricePerDay", "PricePerMonth", "PricePerWeek" },
                values: new object[,]
                {
                    { new Guid("ca617122-b8d1-4f1d-97e7-07fb6fc15a1a"), true, "BMW", "320", 200m, 2000m, 900m },
                    { new Guid("6c174c4b-d9fe-4030-945c-2f17816414a2"), true, "Audi", "A1", 120m, 1600m, 700m },
                    { new Guid("fc0a3062-3383-4bfa-8a47-7abb6dac7782"), true, "Mercedes", "E200", 250m, 2600m, 1100m },
                    { new Guid("edb3fdcb-8a08-46df-94c3-695310ad807c"), true, "Ford", "Focus", 90m, 1000m, 400m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
