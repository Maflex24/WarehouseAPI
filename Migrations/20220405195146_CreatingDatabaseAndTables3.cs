using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseAPI.Migrations
{
    public partial class CreatingDatabaseAndTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_InvoiceAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceAddressId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceAddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceAddressId",
                table: "Orders",
                column: "InvoiceAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_InvoiceAddressId",
                table: "Orders",
                column: "InvoiceAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
