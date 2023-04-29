using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Offers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferID = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferName = table.Column<string>(type: "text", nullable: false),
                    OfferType = table.Column<string>(type: "text", nullable: false),
                    OfferAmount = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "054ad507-2c76-41ae-857d-06fee1b9f299", "AQAAAAEAACcQAAAAEJUDt8kaW+4B87rmapOk8GL8/B5gcKjTjzuD3deIj2xHfcYpE6H6STmIutNnHkJuJg==", "e6a90133-ab77-40a3-b8f8-1c433d242d58" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee47c37d-719f-4d43-8e3e-7e3f4e51b360", "AQAAAAEAACcQAAAAEC663preaVe1VyLZsiZvabWPz1vvrauUIQml+1F7YqOrEHuxe4R38ncZPryXUtkheg==", "b367e123-b927-4987-bddf-f8b3ad28cbf8" });
        }
    }
}
