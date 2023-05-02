using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class jfvhfu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_Customer_CustomerId",
                table: "DamageRequest");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_DamageRequest_CustomerId",
                table: "DamageRequest");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "DamageRequest");

            migrationBuilder.AddColumn<string>(
                name: "AddUserId",
                table: "DamageRequest",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afb05821-2d37-407f-ace0-8f69b5b4593f", "AQAAAAEAACcQAAAAEORO/y401hYZoxrg9AC+MlVMdLazk5dacdY0tqkvA8k2jL6gbbf5HpzfrNfPSFwcgA==", "56c4e10f-201b-4b4d-b435-800f1e451e5c" });

            migrationBuilder.CreateIndex(
                name: "IX_DamageRequest_AddUserId",
                table: "DamageRequest",
                column: "AddUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_AspNetUsers_AddUserId",
                table: "DamageRequest",
                column: "AddUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_AspNetUsers_AddUserId",
                table: "DamageRequest");

            migrationBuilder.DropIndex(
                name: "IX_DamageRequest_AddUserId",
                table: "DamageRequest");

            migrationBuilder.DropColumn(
                name: "AddUserId",
                table: "DamageRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "DamageRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerDiscount = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "718cf03f-b3a8-4286-a7ff-2178704cee38", "AQAAAAEAACcQAAAAEEv4m5ajqNB72j2AgCGFwsC/jZYoBvj4RHcPNJTpqb/mU3CAKCC9lGVDKBZYCM5aTA==", "06e531bd-4bb6-4941-94cc-47abd2a79192" });

            migrationBuilder.CreateIndex(
                name: "IX_DamageRequest_CustomerId",
                table: "DamageRequest",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_Customer_CustomerId",
                table: "DamageRequest",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
