using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZoneDietApp.Data.Migrations
{
    public partial class RecipeProductChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_TypeId",
                table: "RecipeProducts");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "RecipeProducts",
                newName: "RecipeProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeProducts_TypeId",
                table: "RecipeProducts",
                newName: "IX_RecipeProducts_RecipeProductTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "dateTime",
                table: "RecipeComments",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Date of publishing",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "RecipeComments",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "Subject of the comment",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeComments",
                type: "int",
                nullable: false,
                comment: "Recipe identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecipeComments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User's name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "RecipeComments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Message of the comment",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RecipeComments",
                type: "int",
                nullable: false,
                comment: "Comment identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_RecipeProductTypeId",
                table: "RecipeProducts",
                column: "RecipeProductTypeId",
                principalTable: "ProductTypeOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_RecipeProductTypeId",
                table: "RecipeProducts");

            migrationBuilder.RenameColumn(
                name: "RecipeProductTypeId",
                table: "RecipeProducts",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeProducts_RecipeProductTypeId",
                table: "RecipeProducts",
                newName: "IX_RecipeProducts_TypeId");

            migrationBuilder.AlterColumn<string>(
                name: "dateTime",
                table: "RecipeComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Date of publishing");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "RecipeComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "Subject of the comment");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Recipe identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RecipeComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User's name");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "RecipeComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Message of the comment");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RecipeComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Comment identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProducts_ProductTypeOptions_TypeId",
                table: "RecipeProducts",
                column: "TypeId",
                principalTable: "ProductTypeOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
