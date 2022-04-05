using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseAPI.Migrations
{
    public partial class CreatingDatabaseAndTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShipmentAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentAddressId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentAddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentAddressId",
                table: "Orders",
                column: "ShipmentAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShipmentAddressId",
                table: "Orders",
                column: "ShipmentAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
