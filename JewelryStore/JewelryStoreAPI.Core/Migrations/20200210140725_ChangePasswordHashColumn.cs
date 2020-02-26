using Microsoft.EntityFrameworkCore.Migrations;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class ChangePasswordHashColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PasswordHash",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
