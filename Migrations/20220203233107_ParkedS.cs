using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class ParkedS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ParkedSuccesfully",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 6, 428, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 7, 428, DateTimeKind.Local).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 8, 428, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 9, 428, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 10, 428, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 11, 428, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 12, 428, DateTimeKind.Local).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 13, 428, DateTimeKind.Local).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 14, 428, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 4, 0, 31, 15, 428, DateTimeKind.Local).AddTicks(5569));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkedSuccesfully",
                table: "Vehicle");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 33, 899, DateTimeKind.Local).AddTicks(1544));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 34, 899, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 35, 899, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 36, 899, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 37, 899, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 38, 899, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 39, 899, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 40, 899, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 41, 899, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 14, 42, 899, DateTimeKind.Local).AddTicks(1770));
        }
    }
}
