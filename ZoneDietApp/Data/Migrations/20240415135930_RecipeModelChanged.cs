using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class RecipeModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_RecipeProductTypeId",
                table: "RecipeProducts");

            migrationBuilder.DropIndex(
                name: "IX_RecipeProducts_RecipeProductTypeId",
                table: "RecipeProducts");

            migrationBuilder.DropColumn(
                name: "RecipeProductTypeId",
                table: "RecipeProducts");

            migrationBuilder.DropColumn(
                name: "TypeQuantity",
                table: "RecipeProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeProductTypeId",
                table: "RecipeProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TypeQuantity",
                table: "RecipeProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Number of blocks of the product");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_RecipeProductTypeId",
                table: "RecipeProducts",
                column: "RecipeProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_RecipeProductTypeId",
                table: "RecipeProducts",
                column: "RecipeProductTypeId",
                principalTable: "ProductTypeOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
