using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_33_ThueNha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DienTichNhas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_DienTichNhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNhas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_LoaiNhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucGiaThueNhas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_MucGiaThueNhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianThueNhas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_ThoiGianThueNhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThueNhas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiNhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGianThueNhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DienTichNhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MucGiaThueNhaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_ThueNhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThueNhas_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_DienTichNhas_DienTichNhaId",
                        column: x => x.DienTichNhaId,
                        principalSchema: "Catalog",
                        principalTable: "DienTichNhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_LoaiNhas_LoaiNhaId",
                        column: x => x.LoaiNhaId,
                        principalSchema: "Catalog",
                        principalTable: "LoaiNhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_MucGiaThueNhas_MucGiaThueNhaId",
                        column: x => x.MucGiaThueNhaId,
                        principalSchema: "Catalog",
                        principalTable: "MucGiaThueNhas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThueNhas_ThoiGianThueNhas_ThoiGianThueNhaId",
                        column: x => x.ThoiGianThueNhaId,
                        principalSchema: "Catalog",
                        principalTable: "ThoiGianThueNhas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_CommuneId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_DienTichNhaId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "DienTichNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_DistrictId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_LoaiNhaId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "LoaiNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_MucGiaThueNhaId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "MucGiaThueNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_ProvinceId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ThueNhas_ThoiGianThueNhaId",
                schema: "Catalog",
                table: "ThueNhas",
                column: "ThoiGianThueNhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThueNhas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "DienTichNhas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LoaiNhas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "MucGiaThueNhas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ThoiGianThueNhas",
                schema: "Catalog");
        }
    }
}
