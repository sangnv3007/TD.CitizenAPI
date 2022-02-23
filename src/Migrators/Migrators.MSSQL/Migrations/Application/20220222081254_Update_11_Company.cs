using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_11_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVFile",
                schema: "Catalog",
                table: "JobApplieds");

            migrationBuilder.AddColumn<Guid>(
                name: "JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Catalog",
                table: "JobApplieds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplieds_JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds",
                column: "JobApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplieds_JobApplications_JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds",
                column: "JobApplicationId",
                principalSchema: "Catalog",
                principalTable: "JobApplications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplieds_JobApplications_JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds");

            migrationBuilder.DropIndex(
                name: "IX_JobApplieds_JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Catalog",
                table: "JobApplieds");

            migrationBuilder.AddColumn<string>(
                name: "CVFile",
                schema: "Catalog",
                table: "JobApplieds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
