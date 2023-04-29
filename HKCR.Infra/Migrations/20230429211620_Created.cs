using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ModifiedBy",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Cars",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Cars",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Cars",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Cars",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cars",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Cars",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Cars",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b59974e2-3bc3-4b61-b203-9b092f251ddc", "AQAAAAEAACcQAAAAEDj6CKqq1IBxD7aFYiSPixcfZbcOwYiN7iY2p6HfWGoDL8k7AUeFpKwkWJQNakVfrA==", "ae329f7f-316b-4644-a417-1514466493c0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModifiedBy",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c29f7a-10c3-43d6-a243-8af4861b53bc", "AQAAAAEAACcQAAAAEGOoZNGPr8CgZrCQ152AJM1TmuGrzv+uIwat1BGZi/dfc17spZQmdETuScWNdcWG0g==", "5167b498-1534-4d00-a99b-8c057f413727" });
        }
    }
}
