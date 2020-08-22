using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopping.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<string>(maxLength: 20, nullable: false),
                    CategoeyName = table.Column<string>(maxLength: 200, nullable: false),
                    BasePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryRowId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(maxLength: 200, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CategoryRowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductRowId);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryRowId",
                        column: x => x.CategoryRowId,
                        principalTable: "categories",
                        principalColumn: "CategoryRowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryRowId",
                table: "products",
                column: "CategoryRowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
