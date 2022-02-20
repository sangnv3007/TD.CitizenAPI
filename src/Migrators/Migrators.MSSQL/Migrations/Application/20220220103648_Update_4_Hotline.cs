using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_4_Hotline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotlines_HotlineCategories_HotLineCategoryId",
                schema: "Catalog",
                table: "Hotlines");

            migrationBuilder.RenameColumn(
                name: "HotLineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                newName: "HotlineCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotlines_HotLineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                newName: "IX_Hotlines_HotlineCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Catalog",
                table: "MarketCategories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotlines_HotlineCategories_HotlineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                column: "HotlineCategoryId",
                principalSchema: "Catalog",
                principalTable: "HotlineCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotlines_HotlineCategories_HotlineCategoryId",
                schema: "Catalog",
                table: "Hotlines");

            migrationBuilder.RenameColumn(
                name: "HotlineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                newName: "HotLineCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Hotlines_HotlineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                newName: "IX_Hotlines_HotLineCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "Catalog",
                table: "MarketCategories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotlines_HotlineCategories_HotLineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                column: "HotLineCategoryId",
                principalSchema: "Catalog",
                principalTable: "HotlineCategories",
                principalColumn: "Id");
        }
    }
}
