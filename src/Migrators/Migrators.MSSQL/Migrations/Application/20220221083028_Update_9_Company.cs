using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_9_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyIndustries_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "Catalog",
                        principalTable: "Industries",
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
                name: "JobApplieds",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CVFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_JobApplieds", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyIndustries",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobApplications",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobApplieds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "JobSaveds",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "RecruitmentBenefits",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Industries",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Benefits",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Recruitments",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Companies",
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
        }
    }
}
