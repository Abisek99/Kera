using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class ag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocID", "DocImage", "DocType" },
                values: new object[] { new Guid("72eb3a74-5ff1-48b0-8b66-f08de1177332"), "Not Available", "License" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "DocId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87e41bfa-8472-46f0-ad9b-1af40a966800", new Guid("72eb3a74-5ff1-48b0-8b66-f08de1177332"), "AQAAAAEAACcQAAAAEBB/uEgJe+DwK/7o/LqoJFVh7QmvITS1QuZicil8967aCeR1oGwMKlYT2oQTRljfbg==", "1acef37a-18e9-44e7-bbe4-5360a5a4b440" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Document",
                keyColumn: "DocID",
                keyValue: new Guid("72eb3a74-5ff1-48b0-8b66-f08de1177332"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "DocId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7905f1e9-e8d0-4193-ad3d-80fd422ef8fe", null, "AQAAAAEAACcQAAAAEGEUeV7ADTDwe+TniQx8ZUN7RCwVPZNW487+bXAgLTSr/ONAWK2g+SuHV0kib0JgZw==", "72f40a86-59c0-4728-a352-a24ffe90333d" });
        }
    }
}
