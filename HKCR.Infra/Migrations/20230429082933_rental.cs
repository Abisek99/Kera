using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerDiscount = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffEmail = table.Column<string>(type: "text", nullable: false),
                    StaffPassword = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalID = table.Column<Guid>(type: "uuid", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RentalStatus = table.Column<string>(type: "text", nullable: false),
                    DamageStatus = table.Column<string>(type: "text", nullable: false),
                    CarID = table.Column<Guid>(type: "uuid", nullable: false),
                    StaffID = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rental_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rental_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Rental_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f4bd149-1395-4c18-b78f-abcf3608fec0", "AQAAAAEAACcQAAAAENHqoHvTi9t/3ea+6ANfWz827XSBeQ9TvgEHwjQxg++7YX3YH7qNKRvxK6/eFHxIRg==", "1a7bab34-b74e-4ace-a690-9d61dada3a38" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CarID",
                table: "Rental",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerID",
                table: "Rental",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_StaffID",
                table: "Rental",
                column: "StaffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc6e0c71-14d7-40f2-ad58-7efe7a687724", "AQAAAAEAACcQAAAAEPw76Y8O6IJuN2KjVjOTFDkf/13bdLfyhDPtQpp/t9O0bqopRkbs87Fdt2NmsnSK4g==", "95066e27-0275-41a9-b833-d8ae2dab29f4" });
        }
    }
}
