using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 6, 57, 556, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 6, 58, 556, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 6, 59, 556, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 0, 556, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 1, 556, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 2, 556, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 3, 556, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 4, 556, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 5, 556, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2022, 2, 2, 10, 7, 6, 556, DateTimeKind.Local).AddTicks(8084));
        }
    }
}
