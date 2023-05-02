using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class sh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    RentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DamageStatus = table.Column<string>(type: "text", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RentalStatus = table.Column<string>(type: "text", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RentalId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApprovedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rent_AspNetUsers_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rent_Rental_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rental",
                        principalColumn: "RentalId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "718cf03f-b3a8-4286-a7ff-2178704cee38", "AQAAAAEAACcQAAAAEEv4m5ajqNB72j2AgCGFwsC/jZYoBvj4RHcPNJTpqb/mU3CAKCC9lGVDKBZYCM5aTA==", "06e531bd-4bb6-4941-94cc-47abd2a79192" });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_ApprovedBy",
                table: "Rent",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_RentalId",
                table: "Rent",
                column: "RentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b75f40fb-8c0b-45fc-98c3-aa63cd9f79f9", "AQAAAAEAACcQAAAAEJ+08kbvTPjRNsUjNnpJ8TfE1iJviqIQzqqKlIP5EjyunuzColnb5uuriGiKyufLBg==", "22652afa-2b03-4b1f-a648-e93a656419cf" });
        }
    }
}
