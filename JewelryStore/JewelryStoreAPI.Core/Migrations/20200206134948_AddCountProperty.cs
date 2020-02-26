using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class AddCountProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "ProductOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "ProductBaskets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "ProductBaskets");
        }
    }
}
