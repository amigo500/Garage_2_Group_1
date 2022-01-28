using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ArrivalTime", "Color", "Make", "Model", "RegNr", "Type", "WheelCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 28, 14, 57, 45, 860, DateTimeKind.Local).AddTicks(1934), 0, "Toyota", "2H4EZ", "ABC123", 0, 4 },
                    { 2, new DateTime(2022, 1, 28, 14, 57, 45, 860, DateTimeKind.Local).AddTicks(1966), 0, "Honda", "PCD3Y", "ABC12D", 0, 4 },
                    { 3, new DateTime(2022, 1, 28, 14, 57, 45, 860, DateTimeKind.Local).AddTicks(1969), 0, "Ford", "68R99", "AIR001", 0, 4 },
                    { 4, new DateTime(2022, 1, 28, 14, 57, 45, 860, DateTimeKind.Local).AddTicks(1971), 0, "Jeep", "CDOBQ", "WET696", 0, 4 },
                    { 5, new DateTime(2022, 1, 28, 14, 57, 45, 860, DateTimeKind.Local).AddTicks(1973), 0, "BMW", "GMKJM", "BAN420", 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
