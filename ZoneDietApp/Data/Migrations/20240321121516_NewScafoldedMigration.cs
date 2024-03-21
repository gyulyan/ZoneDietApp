using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class NewScafoldedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TypeQuantity",
                table: "RecipeProducts",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Number of blocks of the product",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Weight of the product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TypeQuantity",
                table: "RecipeProducts",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Weight of the product",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Number of blocks of the product");
        }
    }
}
