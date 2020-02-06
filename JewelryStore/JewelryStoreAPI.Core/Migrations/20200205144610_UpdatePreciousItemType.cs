using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class UpdatePreciousItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreciousItemTypes_Name",
                table: "PreciousItemTypes");

            migrationBuilder.CreateIndex(
                name: "IX_PreciousItemTypes_Name_MetalType",
                table: "PreciousItemTypes",
                columns: new[] { "Name", "MetalType" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreciousItemTypes_Name_MetalType",
                table: "PreciousItemTypes");

            migrationBuilder.CreateIndex(
                name: "IX_PreciousItemTypes_Name",
                table: "PreciousItemTypes",
                column: "Name",
                unique: true);
        }
    }
}
