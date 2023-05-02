using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class dfhbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_Rental_RentalId",
                table: "DamageRequest");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "DamageRequest",
                newName: "RentId");

            migrationBuilder.RenameIndex(
                name: "IX_DamageRequest_RentalId",
                table: "DamageRequest",
                newName: "IX_DamageRequest_RentId");

            migrationBuilder.AlterColumn<int>(
                name: "RepairBill",
                table: "DamageRequest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DamageStatus",
                table: "DamageRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DamageDescription",
                table: "DamageRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DamageDate",
                table: "DamageRequest",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "DamagedBy",
                table: "DamageRequest",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96428d91-ed38-47d8-9ec6-d7032de793fa", "AQAAAAEAACcQAAAAEMTSBhw3UaaDUzxzUoJl8oWmrL66VptbOeorWgPfGdkGMSpaV9S/ltPYsh3Dxqxn3Q==", "3121e354-1fbb-4d05-b0b2-7a1b955db87e" });

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_Rent_RentId",
                table: "DamageRequest",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "RentId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_Rent_RentId",
                table: "DamageRequest");

            migrationBuilder.DropColumn(
                name: "DamagedBy",
                table: "DamageRequest");

            migrationBuilder.RenameColumn(
                name: "RentId",
                table: "DamageRequest",
                newName: "RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_DamageRequest_RentId",
                table: "DamageRequest",
                newName: "IX_DamageRequest_RentalId");

            migrationBuilder.AlterColumn<int>(
                name: "RepairBill",
                table: "DamageRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DamageStatus",
                table: "DamageRequest",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DamageDescription",
                table: "DamageRequest",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DamageDate",
                table: "DamageRequest",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afb05821-2d37-407f-ace0-8f69b5b4593f", "AQAAAAEAACcQAAAAEORO/y401hYZoxrg9AC+MlVMdLazk5dacdY0tqkvA8k2jL6gbbf5HpzfrNfPSFwcgA==", "56c4e10f-201b-4b4d-b435-800f1e451e5c" });

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_Rental_RentalId",
                table: "DamageRequest",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
