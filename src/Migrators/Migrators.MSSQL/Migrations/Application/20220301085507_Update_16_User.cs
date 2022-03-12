using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_16_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceCode",
                schema: "Identity",
                table: "Users",
                newName: "ProvinceId");

            migrationBuilder.RenameColumn(
                name: "DistrictCode",
                schema: "Identity",
                table: "Users",
                newName: "DistrictId");

            migrationBuilder.RenameColumn(
                name: "CommuneCode",
                schema: "Identity",
                table: "Users",
                newName: "CommuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                schema: "Identity",
                table: "Users",
                newName: "ProvinceCode");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                schema: "Identity",
                table: "Users",
                newName: "DistrictCode");

            migrationBuilder.RenameColumn(
                name: "CommuneId",
                schema: "Identity",
                table: "Users",
                newName: "CommuneCode");
        }
    }
}
