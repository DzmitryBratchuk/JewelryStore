using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class passwordInBytes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: false);
        }
    }
}
