using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class NewBijouterieTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BijouterieType",
                table: "Bijouteries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bijouteries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BijouterieTypeId",
                table: "Bijouteries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BijouterieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BijouterieTypeName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BijouterieTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijouteries_BijouterieTypeId",
                table: "Bijouteries",
                column: "BijouterieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BijouterieTypes_BijouterieTypeName",
                table: "BijouterieTypes",
                column: "BijouterieTypeName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bijouteries_To_BijouterieTypes",
                table: "Bijouteries",
                column: "BijouterieTypeId",
                principalTable: "BijouterieTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijouteries_To_BijouterieTypes",
                table: "Bijouteries");

            migrationBuilder.DropTable(
                name: "BijouterieTypes");

            migrationBuilder.DropIndex(
                name: "IX_Bijouteries_BijouterieTypeId",
                table: "Bijouteries");

            migrationBuilder.DropColumn(
                name: "BijouterieTypeId",
                table: "Bijouteries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bijouteries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "BijouterieType",
                table: "Bijouteries",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
