using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Auditing");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AgriculturalEngineeringCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_AgriculturalEngineeringCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
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
                    table.PrimaryKey("PK_AlertCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertOrganizations",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
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
                    table.PrimaryKey("PK_AlertOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaInfors",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Introduce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acreage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Population = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Images = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
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
                    table.PrimaryKey("PK_AreaInfors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    NameWithType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PathWithType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisibleOnFront = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsFilterable = table.Column<bool>(type: "bit", nullable: false),
                    IsSearchable = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    IsSellerEditable = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontendInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                schema: "Auditing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarPolicies",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CarPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarUtilities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CarUtilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

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
                name: "Diseases",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EcommerceCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    IncludeInMenu = table.Column<bool>(type: "bit", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_EcommerceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcommerceCategories_EcommerceCategories_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Catalog",
                        principalTable: "EcommerceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EKYCAttachments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EKYCAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseForumCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EnterpriseForumCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodFactories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Files = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_FoodFactories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodWarnings",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FoodWarnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePageInfors",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePad = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_HomePageInfors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotlineCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_HotlineCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobAges",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_JobAges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobNames",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_JobNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborMarketInformations",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewQuantity = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LaborMarketInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawDatas",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AgencyIssued = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LawDatas", x => x.Id);
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
                name: "MarketCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_MarketCategories", x => x.Id);
                });

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
                name: "Notifications",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AppType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectInvestCategories",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProjectInvestCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectInvestForms",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProjectInvestForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrincipalPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeaGames",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ViewQuantity = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SeaGames", x => x.Id);
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
                name: "TourGuides",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PlaceOfIssue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ForeignLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelHandbooks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewQuantity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_TravelHandbooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfDestination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommuneId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjectId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SeatCount = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriculturalEngineerings",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    AgriculturalEngineeringCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ViewQuantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                    table.PrimaryKey("PK_AgriculturalEngineerings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriculturalEngineerings_AgriculturalEngineeringCategories_AgriculturalEngineeringCategoryId",
                        column: x => x.AgriculturalEngineeringCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "AgriculturalEngineeringCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlertInformations",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    File = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AlertCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AlertOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AlertInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertInformations_AlertCategories_AlertCategoryId",
                        column: x => x.AlertCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "AlertCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AlertInformations_AlertOrganizations_AlertOrganizationId",
                        column: x => x.AlertOrganizationId,
                        principalSchema: "Catalog",
                        principalTable: "AlertOrganizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AreaInforValues",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AreaInforId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AreaInforValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaInforValues_AreaInfors_AreaInforId",
                        column: x => x.AreaInforId,
                        principalSchema: "Catalog",
                        principalTable: "AreaInfors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InternationalName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Representative = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProfileVideo = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusinessSector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySize = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceTypes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CoverImage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PlaceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceTypes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Catalog",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EcommerceCategoryAttributes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcommerceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EcommerceCategoryAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcommerceCategoryAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcommerceCategoryAttributes_EcommerceCategories_EcommerceCategoryId",
                        column: x => x.EcommerceCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "EcommerceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseForumTopics",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterpriseForumCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_EnterpriseForumTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnterpriseForumTopics_EnterpriseForumCategories_EnterpriseForumCategoryId",
                        column: x => x.EnterpriseForumCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "EnterpriseForumCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hotlines",
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
                    HotlineCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Hotlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotlines_HotlineCategories_HotlineCategoryId",
                        column: x => x.HotlineCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "HotlineCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CVFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MinExpectedSalary = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsSearchAllowed = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalSchema: "Catalog",
                        principalTable: "Degrees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "Catalog",
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_JobNames_JobNameId",
                        column: x => x.JobNameId,
                        principalSchema: "Catalog",
                        principalTable: "JobNames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPositions_CurrentPositionId",
                        column: x => x.CurrentPositionId,
                        principalSchema: "Catalog",
                        principalTable: "JobPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPositions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Catalog",
                        principalTable: "JobPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "Catalog",
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MarketProducts",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarketCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Packaging = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayUnit = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DisplayFactor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_MarketProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProducts_MarketCategories_MarketCategoryId",
                        column: x => x.MarketCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "MarketCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectInvestInformations",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Investor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewQuantity = table.Column<int>(type: "int", nullable: true),
                    ProjectInvestCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectInvestFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ProjectInvestInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectInvestInformations_ProjectInvestCategories_ProjectInvestCategoryId",
                        column: x => x.ProjectInvestCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "ProjectInvestCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectInvestInformations_ProjectInvestForms_ProjectInvestFormId",
                        column: x => x.ProjectInvestFormId,
                        principalSchema: "Catalog",
                        principalTable: "ProjectInvestForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carpools",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeparturePlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureLatitude = table.Column<double>(type: "float", nullable: true),
                    DepartureLongitude = table.Column<double>(type: "float", nullable: true),
                    DepartureProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureCommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalLatitude = table.Column<double>(type: "float", nullable: true),
                    ArrivalLongitude = table.Column<double>(type: "float", nullable: true),
                    ArrivalProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalCommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DepartureTimeText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Carpools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_ArrivalCommuneId",
                        column: x => x.ArrivalCommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_ArrivalDistrictId",
                        column: x => x.ArrivalDistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_ArrivalProvinceId",
                        column: x => x.ArrivalProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_DepartureCommuneId",
                        column: x => x.DepartureCommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_DepartureDistrictId",
                        column: x => x.DepartureDistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_Areas_DepartureProvinceId",
                        column: x => x.DepartureProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carpools_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "Catalog",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyCarPolicies",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CompanyCarPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCarPolicies_CarPolicies_CarPolicyId",
                        column: x => x.CarPolicyId,
                        principalSchema: "Catalog",
                        principalTable: "CarPolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyCarPolicies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Catalog",
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyIndustries",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CompanyIndustries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyIndustries_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Catalog",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "Catalog",
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    ListPrice = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PrimaryEcommerceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Catalog",
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Catalog",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_EcommerceCategories_PrimaryEcommerceCategoryId",
                        column: x => x.PrimaryEcommerceCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "EcommerceCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recruitments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobAgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OtherRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeRequirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeApplyExpired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfJob = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactAdress = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Recruitments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruitments_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Catalog",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalSchema: "Catalog",
                        principalTable: "Degrees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalSchema: "Catalog",
                        principalTable: "Experiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_JobAges_JobAgeId",
                        column: x => x.JobAgeId,
                        principalSchema: "Catalog",
                        principalTable: "JobAges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_JobNames_JobNameId",
                        column: x => x.JobNameId,
                        principalSchema: "Catalog",
                        principalTable: "JobNames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalSchema: "Catalog",
                        principalTable: "JobPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "Catalog",
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recruitments_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalSchema: "Catalog",
                        principalTable: "Salaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatLimit = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    SeatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Catalog",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "Catalog",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AddressDetail = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExtraInfo = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PhoneContact = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "Decimal(8,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "Decimal(9,6)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Places_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Places_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Places_PlaceTypes_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalSchema: "Catalog",
                        principalTable: "PlaceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseForumComments",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterpriseForumTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_EnterpriseForumComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnterpriseForumComments_EnterpriseForumTopics_EnterpriseForumTopicId",
                        column: x => x.EnterpriseForumTopicId,
                        principalSchema: "Catalog",
                        principalTable: "EnterpriseForumTopics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributeBooleans",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeBooleans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeBooleans_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeBooleans_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeDatetimes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeDatetimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeDatetimes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeDatetimes_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeDecimals",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeDecimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeDecimals_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeDecimals_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeInts",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeInts_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeInts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTexts",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTexts_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeTexts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeVarchars",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AttributeVarchars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeVarchars_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Catalog",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeVarchars_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcommerceCategoryProducts",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EcommerceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_EcommerceCategoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcommerceCategoryProducts_EcommerceCategories_EcommerceCategoryId",
                        column: x => x.EcommerceCategoryId,
                        principalSchema: "Catalog",
                        principalTable: "EcommerceCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EcommerceCategoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSaveds",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ProductSaveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSaveds_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplieds",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    JobApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecruitmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_JobApplieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplieds_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalSchema: "Catalog",
                        principalTable: "JobApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplieds_Recruitments_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalSchema: "Catalog",
                        principalTable: "Recruitments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSaveds",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RecruitmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_JobSaveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSaveds_Recruitments_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalSchema: "Catalog",
                        principalTable: "Recruitments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentBenefits",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BenefitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_RecruitmentBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentBenefits_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalSchema: "Catalog",
                        principalTable: "Benefits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecruitmentBenefits_Recruitments_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalSchema: "Catalog",
                        principalTable: "Recruitments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeparturePlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureLatitude = table.Column<double>(type: "float", nullable: true),
                    DepartureLongitude = table.Column<double>(type: "float", nullable: true),
                    DepartureProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartureCommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalLatitude = table.Column<double>(type: "float", nullable: true),
                    ArrivalLongitude = table.Column<double>(type: "float", nullable: true),
                    ArrivalProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalDistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalCommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    TimeStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Areas_ArrivalCommuneId",
                        column: x => x.ArrivalCommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Areas_ArrivalDistrictId",
                        column: x => x.ArrivalDistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Areas_ArrivalProvinceId",
                        column: x => x.ArrivalProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Areas_DepartureCommuneId",
                        column: x => x.DepartureCommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Areas_DepartureDistrictId",
                        column: x => x.DepartureDistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Areas_DepartureProvinceId",
                        column: x => x.DepartureProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Catalog",
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleCarUtilities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarUtilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_VehicleCarUtilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleCarUtilities_CarUtilities_CarUtilityId",
                        column: x => x.CarUtilityId,
                        principalSchema: "Catalog",
                        principalTable: "CarUtilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleCarUtilities_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Catalog",
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TripRoutes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_TripRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripRoutes_Areas_CommuneId",
                        column: x => x.CommuneId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripRoutes_Areas_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripRoutes_Areas_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "Catalog",
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripRoutes_Trips_TripId",
                        column: x => x.TripId,
                        principalSchema: "Catalog",
                        principalTable: "Trips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriculturalEngineerings_AgriculturalEngineeringCategoryId",
                schema: "Catalog",
                table: "AgriculturalEngineerings",
                column: "AgriculturalEngineeringCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertInformations_AlertCategoryId",
                schema: "Catalog",
                table: "AlertInformations",
                column: "AlertCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertInformations_AlertOrganizationId",
                schema: "Catalog",
                table: "AlertInformations",
                column: "AlertOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaInforValues_AreaInforId",
                schema: "Catalog",
                table: "AreaInforValues",
                column: "AreaInforId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeBooleans_AttributeId",
                schema: "Catalog",
                table: "AttributeBooleans",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeBooleans_ProductId",
                schema: "Catalog",
                table: "AttributeBooleans",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDatetimes_AttributeId",
                schema: "Catalog",
                table: "AttributeDatetimes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDatetimes_ProductId",
                schema: "Catalog",
                table: "AttributeDatetimes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDecimals_AttributeId",
                schema: "Catalog",
                table: "AttributeDecimals",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeDecimals_ProductId",
                schema: "Catalog",
                table: "AttributeDecimals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeInts_AttributeId",
                schema: "Catalog",
                table: "AttributeInts",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeInts_ProductId",
                schema: "Catalog",
                table: "AttributeInts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTexts_AttributeId",
                schema: "Catalog",
                table: "AttributeTexts",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTexts_ProductId",
                schema: "Catalog",
                table: "AttributeTexts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                schema: "Catalog",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeVarchars_AttributeId",
                schema: "Catalog",
                table: "AttributeVarchars",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeVarchars_ProductId",
                schema: "Catalog",
                table: "AttributeVarchars",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalCommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureCommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_DepartureDistrictId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_DepartureProvinceId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Carpools_VehicleTypeId",
                schema: "Catalog",
                table: "Carpools",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CommuneId",
                schema: "Catalog",
                table: "Companies",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DistrictId",
                schema: "Catalog",
                table: "Companies",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProvinceId",
                schema: "Catalog",
                table: "Companies",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCarPolicies_CarPolicyId",
                schema: "Catalog",
                table: "CompanyCarPolicies",
                column: "CarPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCarPolicies_CompanyId",
                schema: "Catalog",
                table: "CompanyCarPolicies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustries_CompanyId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustries_IndustryId",
                schema: "Catalog",
                table: "CompanyIndustries",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceCategories_ParentId",
                schema: "Catalog",
                table: "EcommerceCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceCategoryAttributes_AttributeId",
                schema: "Catalog",
                table: "EcommerceCategoryAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceCategoryAttributes_EcommerceCategoryId",
                schema: "Catalog",
                table: "EcommerceCategoryAttributes",
                column: "EcommerceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceCategoryProducts_EcommerceCategoryId",
                schema: "Catalog",
                table: "EcommerceCategoryProducts",
                column: "EcommerceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceCategoryProducts_ProductId",
                schema: "Catalog",
                table: "EcommerceCategoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseForumComments_EnterpriseForumTopicId",
                schema: "Catalog",
                table: "EnterpriseForumComments",
                column: "EnterpriseForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseForumTopics_EnterpriseForumCategoryId",
                schema: "Catalog",
                table: "EnterpriseForumTopics",
                column: "EnterpriseForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotlines_HotlineCategoryId",
                schema: "Catalog",
                table: "Hotlines",
                column: "HotlineCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CurrentPositionId",
                schema: "Catalog",
                table: "JobApplications",
                column: "CurrentPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_DegreeId",
                schema: "Catalog",
                table: "JobApplications",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ExperienceId",
                schema: "Catalog",
                table: "JobApplications",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobNameId",
                schema: "Catalog",
                table: "JobApplications",
                column: "JobNameId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobTypeId",
                schema: "Catalog",
                table: "JobApplications",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_PositionId",
                schema: "Catalog",
                table: "JobApplications",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplieds_JobApplicationId",
                schema: "Catalog",
                table: "JobApplieds",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplieds_RecruitmentId",
                schema: "Catalog",
                table: "JobApplieds",
                column: "RecruitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSaveds_RecruitmentId",
                schema: "Catalog",
                table: "JobSaveds",
                column: "RecruitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProducts_MarketCategoryId",
                schema: "Catalog",
                table: "MarketProducts",
                column: "MarketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CommuneId",
                schema: "Catalog",
                table: "Places",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_DistrictId",
                schema: "Catalog",
                table: "Places",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_PlaceTypeId",
                schema: "Catalog",
                table: "Places",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_ProvinceId",
                schema: "Catalog",
                table: "Places",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTypes_CategoryId",
                schema: "Catalog",
                table: "PlaceTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                schema: "Catalog",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                schema: "Catalog",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommuneId",
                schema: "Catalog",
                table: "Products",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                schema: "Catalog",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DistrictId",
                schema: "Catalog",
                table: "Products",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products",
                column: "PrimaryEcommerceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProvinceId",
                schema: "Catalog",
                table: "Products",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaveds_ProductId",
                schema: "Catalog",
                table: "ProductSaveds",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInvestInformations_ProjectInvestCategoryId",
                schema: "Catalog",
                table: "ProjectInvestInformations",
                column: "ProjectInvestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInvestInformations_ProjectInvestFormId",
                schema: "Catalog",
                table: "ProjectInvestInformations",
                column: "ProjectInvestFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentBenefits_BenefitId",
                schema: "Catalog",
                table: "RecruitmentBenefits",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentBenefits_RecruitmentId",
                schema: "Catalog",
                table: "RecruitmentBenefits",
                column: "RecruitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_CommuneId",
                schema: "Catalog",
                table: "Recruitments",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_CompanyId",
                schema: "Catalog",
                table: "Recruitments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_DegreeId",
                schema: "Catalog",
                table: "Recruitments",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_DistrictId",
                schema: "Catalog",
                table: "Recruitments",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_ExperienceId",
                schema: "Catalog",
                table: "Recruitments",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_JobAgeId",
                schema: "Catalog",
                table: "Recruitments",
                column: "JobAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_JobNameId",
                schema: "Catalog",
                table: "Recruitments",
                column: "JobNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_JobPositionId",
                schema: "Catalog",
                table: "Recruitments",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_JobTypeId",
                schema: "Catalog",
                table: "Recruitments",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_ProvinceId",
                schema: "Catalog",
                table: "Recruitments",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitments_SalaryId",
                schema: "Catalog",
                table: "Recruitments",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                columns: new[] { "NormalizedName", "TenantId" },
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_TripRoutes_CommuneId",
                schema: "Catalog",
                table: "TripRoutes",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRoutes_DistrictId",
                schema: "Catalog",
                table: "TripRoutes",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRoutes_ProvinceId",
                schema: "Catalog",
                table: "TripRoutes",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRoutes_TripId",
                schema: "Catalog",
                table: "TripRoutes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalCommuneId",
                schema: "Catalog",
                table: "Trips",
                column: "ArrivalCommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalDistrictId",
                schema: "Catalog",
                table: "Trips",
                column: "ArrivalDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalProvinceId",
                schema: "Catalog",
                table: "Trips",
                column: "ArrivalProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureCommuneId",
                schema: "Catalog",
                table: "Trips",
                column: "DepartureCommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureDistrictId",
                schema: "Catalog",
                table: "Trips",
                column: "DepartureDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureProvinceId",
                schema: "Catalog",
                table: "Trips",
                column: "DepartureProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleId",
                schema: "Catalog",
                table: "Trips",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_LoginProvider_ProviderKey_TenantId",
                schema: "Identity",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                columns: new[] { "NormalizedUserName", "TenantId" },
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCarUtilities_CarUtilityId",
                schema: "Catalog",
                table: "VehicleCarUtilities",
                column: "CarUtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCarUtilities_VehicleId",
                schema: "Catalog",
                table: "VehicleCarUtilities",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyId",
                schema: "Catalog",
                table: "Vehicles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                schema: "Catalog",
                table: "Vehicles",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriculturalEngineerings",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AlertInformations",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AreaInforValues",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeBooleans",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeDatetimes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeDecimals",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeInts",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeTexts",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeValues",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AttributeVarchars",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AuditTrails",
                schema: "Auditing");

            migrationBuilder.DropTable(
                name: "Carpools",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CompanyCarPolicies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CompanyIndustries",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Diseases",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Drugs",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EcommerceCategoryAttributes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EcommerceCategoryProducts",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EKYCAttachments",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EnterpriseForumComments",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Feedbacks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "FoodFactories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "FoodWarnings",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "HomePageInfors",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Hotlines",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobApplieds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobSaveds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LaborMarketInformations",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LawDatas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "MarketProducts",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "MedicalHotlines",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Places",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductReviews",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductSaveds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProjectInvestInformations",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "RecruitmentBenefits",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Schools",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SeaGames",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ThueNhas",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "TourGuides",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "TravelHandbooks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "TripRoutes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "VehicleCarUtilities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AgriculturalEngineeringCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AlertCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AlertOrganizations",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AreaInfors",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CarPolicies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Industries",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EnterpriseForumTopics",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "HotlineCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobApplications",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "MarketCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "PlaceTypes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProjectInvestCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProjectInvestForms",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Benefits",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Recruitments",
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

            migrationBuilder.DropTable(
                name: "Trips",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CarUtilities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EnterpriseForumCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EcommerceCategories",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Degrees",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobAges",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobNames",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobPositions",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Salaries",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "Catalog");
        }
    }
}
