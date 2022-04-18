using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_31_Medical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenThuoc = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DotPheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HieuLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDangKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoatChat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NongDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaDuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoChe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongGoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuChuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuoiTho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongTySx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongTySxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NuocSx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiSx = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongTyDk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NuocDk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiDk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaKeKhai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuongDanSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuongDanSuDungBn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhomThuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs",
                schema: "Catalog");
        }
    }
}
