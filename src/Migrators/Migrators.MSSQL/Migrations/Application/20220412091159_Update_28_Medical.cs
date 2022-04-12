using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_28_Medical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalHotlines",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    OtherDetail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Latitude = table.Column<decimal>(type: "Decimal(8,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "Decimal(9,6)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHotlines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHotlines",
                schema: "Catalog");
        }
    }
}
