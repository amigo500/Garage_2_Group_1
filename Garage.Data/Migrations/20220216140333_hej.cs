using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage.Data.Migrations
{
    public partial class hej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlot_Vehicle_VehicleRegNr",
                table: "ParkingSlot");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleRegNr",
                table: "ParkingSlot",
                type: "nvarchar(6)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlot_Vehicle_VehicleRegNr",
                table: "ParkingSlot",
                column: "VehicleRegNr",
                principalTable: "Vehicle",
                principalColumn: "RegNr",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSlot_Vehicle_VehicleRegNr",
                table: "ParkingSlot");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleRegNr",
                table: "ParkingSlot",
                type: "nvarchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSlot_Vehicle_VehicleRegNr",
                table: "ParkingSlot",
                column: "VehicleRegNr",
                principalTable: "Vehicle",
                principalColumn: "RegNr");
        }
    }
}
