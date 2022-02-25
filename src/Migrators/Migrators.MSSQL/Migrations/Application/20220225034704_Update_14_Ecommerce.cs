using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_14_Ecommerce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CommuneId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                schema: "Catalog",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ListPrice",
                schema: "Catalog",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                schema: "Catalog",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProvinceId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "Catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "Catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                schema: "Catalog",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Catalog",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                schema: "Catalog",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Catalog",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Catalog",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

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
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCarUtilities_CarUtilityId",
                schema: "Catalog",
                table: "VehicleCarUtilities",
                column: "CarUtilityId");

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
                name: "IX_ProductReviews_ProductId",
                schema: "Catalog",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaveds_ProductId",
                schema: "Catalog",
                table: "ProductSaveds",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCarPolicies_CarPolicies_CarPolicyId",
                schema: "Catalog",
                table: "CompanyCarPolicies",
                column: "CarPolicyId",
                principalSchema: "Catalog",
                principalTable: "CarPolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCarPolicies_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyCarPolicies",
                column: "CompanyId",
                principalSchema: "Catalog",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Areas_CommuneId",
                schema: "Catalog",
                table: "Products",
                column: "CommuneId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Areas_DistrictId",
                schema: "Catalog",
                table: "Products",
                column: "DistrictId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Areas_ProvinceId",
                schema: "Catalog",
                table: "Products",
                column: "ProvinceId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "Catalog",
                table: "Products",
                column: "BrandId",
                principalSchema: "Catalog",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                schema: "Catalog",
                table: "Products",
                column: "CompanyId",
                principalSchema: "Catalog",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_EcommerceCategories_PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products",
                column: "PrimaryEcommerceCategoryId",
                principalSchema: "Catalog",
                principalTable: "EcommerceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCarUtilities_CarUtilities_CarUtilityId",
                schema: "Catalog",
                table: "VehicleCarUtilities",
                column: "CarUtilityId",
                principalSchema: "Catalog",
                principalTable: "CarUtilities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCarPolicies_CarPolicies_CarPolicyId",
                schema: "Catalog",
                table: "CompanyCarPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCarPolicies_Companies_CompanyId",
                schema: "Catalog",
                table: "CompanyCarPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Areas_CommuneId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Areas_DistrictId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Areas_ProvinceId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_EcommerceCategories_PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCarUtilities_CarUtilities_CarUtilityId",
                schema: "Catalog",
                table: "VehicleCarUtilities");

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
                name: "EcommerceCategoryAttributes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EcommerceCategoryProducts",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductReviews",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductSaveds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "EcommerceCategories",
                schema: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCarUtilities_CarUtilityId",
                schema: "Catalog",
                table: "VehicleCarUtilities");

            migrationBuilder.DropIndex(
                name: "IX_Products_CommuneId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DistrictId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProvinceId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCarPolicies_CarPolicyId",
                schema: "Catalog",
                table: "CompanyCarPolicies");

            migrationBuilder.DropIndex(
                name: "IX_CompanyCarPolicies_CompanyId",
                schema: "Catalog",
                table: "CompanyCarPolicies");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CommuneId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FromDate",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Images",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PrimaryEcommerceCategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKU",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ToDate",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VideoURL",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Catalog",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Catalog",
                table: "Brands");

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                schema: "Catalog",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "Catalog",
                table: "Products",
                column: "BrandId",
                principalSchema: "Catalog",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
