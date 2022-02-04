using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class NewProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkingSlots",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 52, 844, DateTimeKind.Local).AddTicks(897), "0 1 2" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 53, 844, DateTimeKind.Local).AddTicks(934), "3 4 5" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 54, 844, DateTimeKind.Local).AddTicks(937), "6 7 8" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 55, 844, DateTimeKind.Local).AddTicks(942), "9 10 11" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 56, 844, DateTimeKind.Local).AddTicks(946), "12 13" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 57, 844, DateTimeKind.Local).AddTicks(949), "14 15" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 58, 844, DateTimeKind.Local).AddTicks(952), "16" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 59, 844, DateTimeKind.Local).AddTicks(956), "17" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 43, 0, 844, DateTimeKind.Local).AddTicks(958), "18" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalTime", "ParkingSlots" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 43, 1, 844, DateTimeKind.Local).AddTicks(961), "19" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingSlots",
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
