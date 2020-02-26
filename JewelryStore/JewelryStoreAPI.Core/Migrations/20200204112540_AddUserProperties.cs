using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class AddUserProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PasswordHash",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");
        }
    }
}
