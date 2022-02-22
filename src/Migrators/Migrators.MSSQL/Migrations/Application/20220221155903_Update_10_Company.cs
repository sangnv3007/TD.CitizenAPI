using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_10_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyIndustries_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyIndustries_Industries_IndustryId",
                schema: "Catalog",
                table: "CompanyIndustries");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyIndustries_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "CompanyId",
                principalSchema: "Catalog",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyIndustries_Industries_IndustryId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "IndustryId",
                principalSchema: "Catalog",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyIndustries_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyIndustries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyIndustries_Industries_IndustryId",
                schema: "Catalog",
                table: "CompanyIndustries");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyIndustries_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "CompanyId",
                principalSchema: "Catalog",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyIndustries_Industries_IndustryId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "IndustryId",
                principalSchema: "Catalog",
                principalTable: "Industries",
                principalColumn: "Id");
        }
    }
}
