using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "Vehicle",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ArrivalTime", "Color", "Make", "Model", "RegNr", "Type", "WheelCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 31, 13, 31, 9, 318, DateTimeKind.Local).AddTicks(5443), 0, "Boeing", "737", "AIR001", 0, 6 },
                    { 2, new DateTime(2022, 1, 31, 13, 31, 10, 318, DateTimeKind.Local).AddTicks(5477), 1, "SAAB", "JAS 39", "AIR00S", 0, 4 },
                    { 3, new DateTime(2022, 1, 31, 13, 31, 11, 318, DateTimeKind.Local).AddTicks(5481), 2, "Bertram", "35 Flybridge", "WET001", 1, 0 },
                    { 4, new DateTime(2022, 1, 31, 13, 31, 12, 318, DateTimeKind.Local).AddTicks(5483), 3, "Viking Line", "Cinderella", "WET00B", 1, 0 },
                    { 5, new DateTime(2022, 1, 31, 13, 31, 13, 318, DateTimeKind.Local).AddTicks(5485), 4, "Bridgestone", "U-AP 002", "LNG420", 2, 6 },
                    { 6, new DateTime(2022, 1, 31, 13, 31, 14, 318, DateTimeKind.Local).AddTicks(5487), 5, "Goodyear", "CDOBQ", "LNG404", 2, 4 },
                    { 7, new DateTime(2022, 1, 31, 13, 31, 15, 318, DateTimeKind.Local).AddTicks(5490), 6, "Toyota", "RAV4", "FST00S", 3, 4 },
                    { 8, new DateTime(2022, 1, 31, 13, 31, 16, 318, DateTimeKind.Local).AddTicks(5492), 7, "Jeep", "Wrangler", "FST00T", 3, 4 },
                    { 9, new DateTime(2022, 1, 31, 13, 31, 17, 318, DateTimeKind.Local).AddTicks(5494), 8, "Yamaha", "YZF R15 V4", "SOL006", 4, 2 },
                    { 10, new DateTime(2022, 1, 31, 13, 31, 18, 318, DateTimeKind.Local).AddTicks(5496), 9, "Triumph", "Speed Twin", "SOL00P", 4, 2 }
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

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Make",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
