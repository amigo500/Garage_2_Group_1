using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2_Group_1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ArrivalTime", "Color", "Make", "Model", "RegNr", "Type", "WheelCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 2, 10, 6, 57, 556, DateTimeKind.Local).AddTicks(7859), 0, "Boeing", "737", "AIR001", 0, 6 },
                    { 2, new DateTime(2022, 2, 2, 10, 6, 58, 556, DateTimeKind.Local).AddTicks(7987), 1, "SAAB", "JAS 39", "AIR00S", 0, 4 },
                    { 3, new DateTime(2022, 2, 2, 10, 6, 59, 556, DateTimeKind.Local).AddTicks(8002), 2, "Bertram", "35 Flybridge", "WET001", 1, 0 },
                    { 4, new DateTime(2022, 2, 2, 10, 7, 0, 556, DateTimeKind.Local).AddTicks(8012), 3, "Viking Line", "Cinderella", "WET00B", 1, 0 },
                    { 5, new DateTime(2022, 2, 2, 10, 7, 1, 556, DateTimeKind.Local).AddTicks(8028), 4, "Bridgestone", "U-AP 002", "LNG420", 2, 6 },
                    { 6, new DateTime(2022, 2, 2, 10, 7, 2, 556, DateTimeKind.Local).AddTicks(8038), 5, "Goodyear", "CDOBQ", "LNG404", 2, 4 },
                    { 7, new DateTime(2022, 2, 2, 10, 7, 3, 556, DateTimeKind.Local).AddTicks(8048), 6, "Toyota", "RAV4", "FST00S", 3, 4 },
                    { 8, new DateTime(2022, 2, 2, 10, 7, 4, 556, DateTimeKind.Local).AddTicks(8064), 7, "Jeep", "Wrangler", "FST00T", 3, 4 },
                    { 9, new DateTime(2022, 2, 2, 10, 7, 5, 556, DateTimeKind.Local).AddTicks(8074), 8, "Yamaha", "YZF R15 V4", "SOL006", 4, 2 },
                    { 10, new DateTime(2022, 2, 2, 10, 7, 6, 556, DateTimeKind.Local).AddTicks(8084), 9, "Triumph", "Speed Twin", "SOL00P", 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
