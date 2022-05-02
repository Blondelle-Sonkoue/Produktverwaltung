using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produktverwaltung.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bescreibung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PRODUKTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preis = table.Column<double>(type: "float", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUKTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUKTS_CATEGORIES_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORIES",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUKTS_CategoryId",
                table: "PRODUKTS",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUKTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");
        }
    }
}
