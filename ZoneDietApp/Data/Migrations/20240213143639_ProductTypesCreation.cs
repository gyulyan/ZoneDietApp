using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class ProductTypesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeOptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductTypeOptions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Въглехидрат" },
                    { 2, "Мазнини" },
                    { 3, "Протеин" },
                    { 4, "Комбиниран" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTypeOptions");
        }
    }
}
