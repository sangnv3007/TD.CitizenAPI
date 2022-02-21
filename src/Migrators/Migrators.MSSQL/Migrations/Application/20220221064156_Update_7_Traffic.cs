using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class Update_7_Traffic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Places_PlaceArrivalId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Places_PlaceDepartureId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.RenameColumn(
                name: "PlaceDepartureId",
                schema: "Catalog",
                table: "Carpools",
                newName: "DepartureProvinceId");

            migrationBuilder.RenameColumn(
                name: "PlaceArrivalId",
                schema: "Catalog",
                table: "Carpools",
                newName: "DepartureDistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Carpools_PlaceDepartureId",
                schema: "Catalog",
                table: "Carpools",
                newName: "IX_Carpools_DepartureProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Carpools_PlaceArrivalId",
                schema: "Catalog",
                table: "Carpools",
                newName: "IX_Carpools_DepartureDistrictId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTimeText",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<Guid>(
                name: "ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArrivalLatitude",
                schema: "Catalog",
                table: "Carpools",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArrivalLongitude",
                schema: "Catalog",
                table: "Carpools",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalPlaceName",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DepartureLatitude",
                schema: "Catalog",
                table: "Carpools",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DepartureLongitude",
                schema: "Catalog",
                table: "Carpools",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeparturePlaceName",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalCommuneId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalDistrictId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools",
                column: "ArrivalProvinceId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureCommuneId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_DepartureDistrictId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureDistrictId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Areas_DepartureProvinceId",
                schema: "Catalog",
                table: "Carpools",
                column: "DepartureProvinceId",
                principalSchema: "Catalog",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_DepartureDistrictId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropForeignKey(
                name: "FK_Carpools_Areas_DepartureProvinceId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropIndex(
                name: "IX_Carpools_ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropIndex(
                name: "IX_Carpools_ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropIndex(
                name: "IX_Carpools_ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropIndex(
                name: "IX_Carpools_DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalDistrictId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalLatitude",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalLongitude",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalPlaceName",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "ArrivalProvinceId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "DepartureCommuneId",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "DepartureLatitude",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "DepartureLongitude",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.DropColumn(
                name: "DeparturePlaceName",
                schema: "Catalog",
                table: "Carpools");

            migrationBuilder.RenameColumn(
                name: "DepartureProvinceId",
                schema: "Catalog",
                table: "Carpools",
                newName: "PlaceDepartureId");

            migrationBuilder.RenameColumn(
                name: "DepartureDistrictId",
                schema: "Catalog",
                table: "Carpools",
                newName: "PlaceArrivalId");

            migrationBuilder.RenameIndex(
                name: "IX_Carpools_DepartureProvinceId",
                schema: "Catalog",
                table: "Carpools",
                newName: "IX_Carpools_PlaceDepartureId");

            migrationBuilder.RenameIndex(
                name: "IX_Carpools_DepartureDistrictId",
                schema: "Catalog",
                table: "Carpools",
                newName: "IX_Carpools_PlaceArrivalId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTimeText",
                schema: "Catalog",
                table: "Carpools",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Places_PlaceArrivalId",
                schema: "Catalog",
                table: "Carpools",
                column: "PlaceArrivalId",
                principalSchema: "Catalog",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carpools_Places_PlaceDepartureId",
                schema: "Catalog",
                table: "Carpools",
                column: "PlaceDepartureId",
                principalSchema: "Catalog",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
