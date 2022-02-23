using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_13_Traffic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CarPolicies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CarUtilities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CompanyCarPolicies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "TripRoutes",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "VehicleCarUtilities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Trips",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Catalog");
        }
    }
}
