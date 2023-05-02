using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class sga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_Rent_RentId",
                table: "DamageRequest");

            migrationBuilder.DropIndex(
                name: "IX_DamageRequest_RentId",
                table: "DamageRequest");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "DamageRequest");

            migrationBuilder.AlterColumn<string>(
                name: "AddUserId",
                table: "DamageRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "RentalId",
                table: "DamageRequest",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7b03cfb-ddf6-47c5-877a-e1824963cb66", "AQAAAAEAACcQAAAAEDAfZujuz3bJo7Y5k92sg3CttTK3/4ICZMudQ5L1jJN7cV9vqwDS0UcnNBJSsvgIXA==", "b081699f-5e5e-41bb-a58c-09ed208385c6" });

            migrationBuilder.CreateIndex(
                name: "IX_DamageRequest_RentalId",
                table: "DamageRequest",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_Rental_RentalId",
                table: "DamageRequest",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_Rental_RentalId",
                table: "DamageRequest");

            migrationBuilder.DropIndex(
                name: "IX_DamageRequest_RentalId",
                table: "DamageRequest");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "DamageRequest");

            migrationBuilder.AlterColumn<string>(
                name: "AddUserId",
                table: "DamageRequest",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RentId",
                table: "DamageRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96428d91-ed38-47d8-9ec6-d7032de793fa", "AQAAAAEAACcQAAAAEMTSBhw3UaaDUzxzUoJl8oWmrL66VptbOeorWgPfGdkGMSpaV9S/ltPYsh3Dxqxn3Q==", "3121e354-1fbb-4d05-b0b2-7a1b955db87e" });

            migrationBuilder.CreateIndex(
                name: "IX_DamageRequest_RentId",
                table: "DamageRequest",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_Rent_RentId",
                table: "DamageRequest",
                column: "RentId",
                principalTable: "Rent",
                principalColumn: "RentId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
