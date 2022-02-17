using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    SSN = table.Column<long>(type: "bigint", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.SSN);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    RegNr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false),
                    UserSSN = table.Column<long>(type: "bigint", nullable: false),
                    VehicleTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.RegNr);
                    table.ForeignKey(
                        name: "FK_Vehicle_User_UserSSN",
                        column: x => x.UserSSN,
                        principalTable: "User",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegNr = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSlot_Vehicle_VehicleRegNr",
                        column: x => x.VehicleRegNr,
                        principalTable: "Vehicle",
                        principalColumn: "RegNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "Airplane", 3 },
                    { 2, "Boat", 3 },
                    { 3, "Bus", 2 },
                    { 4, "Car", 1 },
                    { 5, "Motorcycle", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlot_VehicleRegNr",
                table: "ParkingSlot",
                column: "VehicleRegNr");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_UserSSN",
                table: "Vehicle",
                column: "UserSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeID",
                table: "Vehicle",
                column: "VehicleTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSlot");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
