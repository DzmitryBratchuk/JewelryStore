using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JewelryStoreAPI.Core.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Bijouteries_BijouterieId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PreciousMetalStuffs_PreciousMetalStuffId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Wristwatchs_WristwatchId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Bijouteries");

            migrationBuilder.DropTable(
                name: "PreciousMetalStuffs");

            migrationBuilder.DropTable(
                name: "Wristwatchs");

            migrationBuilder.DropIndex(
                name: "IX_Products_BijouterieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PreciousMetalStuffId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WristwatchId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BijouterieId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreciousMetalStuffId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WristwatchId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BasketID",
                table: "Orders",
                newName: "BasketId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BijouterieTypeId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetalTypeId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreciousMetalMaterialTypeId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JewelryType",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CaseColorId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DialColorId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiameterMM",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrapColorId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderTime",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "BijouterieTypeName",
                table: "BijouterieTypes",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColorName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MetalTypeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreciousMetalMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PreciousMetalMaterialTypeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciousMetalMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BijouterieTypeId",
                table: "Products",
                column: "BijouterieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MetalTypeId",
                table: "Products",
                column: "MetalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PreciousMetalMaterialTypeId",
                table: "Products",
                column: "PreciousMetalMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CaseColorId",
                table: "Products",
                column: "CaseColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DialColorId",
                table: "Products",
                column: "DialColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StrapColorId",
                table: "Products",
                column: "StrapColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ColorName",
                table: "Colors",
                column: "ColorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetalTypes_MetalTypeName",
                table: "MetalTypes",
                column: "MetalTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreciousMetalMaterialTypes_PreciousMetalMaterialTypeName",
                table: "PreciousMetalMaterialTypes",
                column: "PreciousMetalMaterialTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_To_Users",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_To_Baskets",
                table: "Orders",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bijouteries_To_BijouterieTypes",
                table: "Products",
                column: "BijouterieTypeId",
                principalTable: "BijouterieTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreciousMetalMaterials_To_MetalTypeTypes",
                table: "Products",
                column: "MetalTypeId",
                principalTable: "MetalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreciousMetalMaterials_To_PreciousMetalMaterialTypes",
                table: "Products",
                column: "PreciousMetalMaterialTypeId",
                principalTable: "PreciousMetalMaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_To_Brands",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_To_Countries",
                table: "Products",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchesWithCaseColors_To_CaseColors",
                table: "Products",
                column: "CaseColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchesWithDialColors_To_DialColors",
                table: "Products",
                column: "DialColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchesWithStrapColors_To_StrapColors",
                table: "Products",
                column: "StrapColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_To_Roles",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_To_Users",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_To_Baskets",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Bijouteries_To_BijouterieTypes",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PreciousMetalMaterials_To_MetalTypeTypes",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PreciousMetalMaterials_To_PreciousMetalMaterialTypes",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_To_Brands",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_To_Countries",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchesWithCaseColors_To_CaseColors",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchesWithDialColors_To_DialColors",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchesWithStrapColors_To_StrapColors",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_To_Roles",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "MetalTypes");

            migrationBuilder.DropTable(
                name: "PreciousMetalMaterialTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_BijouterieTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MetalTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PreciousMetalMaterialTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CountryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CaseColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DialColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StrapColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BijouterieTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetalTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreciousMetalMaterialTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "JewelryType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CaseColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DialColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiameterMM",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StrapColorId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Orders",
                newName: "BasketID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BijouterieId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreciousMetalStuffId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WristwatchId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<string>(
                name: "BijouterieTypeName",
                table: "BijouterieTypes",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Bijouteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    BijouterieTypeId = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bijouteries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bijouteries_To_BijouterieTypes",
                        column: x => x.BijouterieTypeId,
                        principalTable: "BijouterieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreciousMetalStuffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    MetalType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PreciousMetalStuffType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciousMetalStuffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wristwatchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    CaseColor = table.Column<int>(type: "integer", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    DialColor = table.Column<int>(type: "integer", nullable: false),
                    DiameterMM = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StrapColor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wristwatchs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BijouterieId",
                table: "Products",
                column: "BijouterieId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PreciousMetalStuffId",
                table: "Products",
                column: "PreciousMetalStuffId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WristwatchId",
                table: "Products",
                column: "WristwatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketID",
                table: "Orders",
                column: "BasketID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bijouteries_BijouterieTypeId",
                table: "Bijouteries",
                column: "BijouterieTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Bijouteries_BijouterieId",
                table: "Products",
                column: "BijouterieId",
                principalTable: "Bijouteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PreciousMetalStuffs_PreciousMetalStuffId",
                table: "Products",
                column: "PreciousMetalStuffId",
                principalTable: "PreciousMetalStuffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Wristwatchs_WristwatchId",
                table: "Products",
                column: "WristwatchId",
                principalTable: "Wristwatchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
