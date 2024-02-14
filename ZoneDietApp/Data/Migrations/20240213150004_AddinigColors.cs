using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class AddinigColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoneChoiceColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneChoiceColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ZoneChoiceColorId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypeOptions_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProductTypeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ZoneChoiceColors_ZoneChoiceColorId",
                        column: x => x.ZoneChoiceColorId,
                        principalTable: "ZoneChoiceColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductTypeOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Смесени продукти");

            migrationBuilder.InsertData(
                table: "ZoneChoiceColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Зелен" },
                    { 2, "Оранжев" },
                    { 3, "Червен" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "TypeId", "Weight", "ZoneChoiceColorId" },
                values: new object[,]
                {
                    { 1, "Заешко месо", 3, "0.028", 1 },
                    { 2, "Алабаш", 1, "0.300", 1 },
                    { 3, "Авокадо", 2, "0.010", 1 },
                    { 4, "Кисело мляко", 4, "0.220", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ZoneChoiceColorId",
                table: "Products",
                column: "ZoneChoiceColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ZoneChoiceColors");

            migrationBuilder.UpdateData(
                table: "ProductTypeOptions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Комбиниран");
        }
    }
}
