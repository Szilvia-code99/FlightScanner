using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    flightId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    airlineName = table.Column<string>(nullable: true),
                    origin = table.Column<string>(nullable: true),
                    destination = table.Column<string>(nullable: true),
                    departureTime = table.Column<DateTime>(nullable: false),
                    arrivalTime = table.Column<DateTime>(nullable: false),
                    totalSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.flightId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
