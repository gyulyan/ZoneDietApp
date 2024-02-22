using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class UpdatedDB220224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Recipes_RecipeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProducts_ZoneChoiceColors_ZoneChoiceColorId",
                table: "RecipeProducts");

            migrationBuilder.DropIndex(
                name: "IX_RecipeProducts_ZoneChoiceColorId",
                table: "RecipeProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_RecipeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ZoneChoiceColorId",
                table: "RecipeProducts");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_RecipeId",
                table: "RecipeProducts",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProducts_Recipes_RecipeId",
                table: "RecipeProducts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProducts_Recipes_RecipeId",
                table: "RecipeProducts");

            migrationBuilder.DropIndex(
                name: "IX_RecipeProducts_RecipeId",
                table: "RecipeProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeProducts");

            migrationBuilder.AddColumn<int>(
                name: "ZoneChoiceColorId",
                table: "RecipeProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_ZoneChoiceColorId",
                table: "RecipeProducts",
                column: "ZoneChoiceColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeId",
                table: "Products",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Recipes_RecipeId",
                table: "Products",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProducts_ZoneChoiceColors_ZoneChoiceColorId",
                table: "RecipeProducts",
                column: "ZoneChoiceColorId",
                principalTable: "ZoneChoiceColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
