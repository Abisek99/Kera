using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarAvailability",
                table: "Cars",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7c29f7a-10c3-43d6-a243-8af4861b53bc", "AQAAAAEAACcQAAAAEGOoZNGPr8CgZrCQ152AJM1TmuGrzv+uIwat1BGZi/dfc17spZQmdETuScWNdcWG0g==", "5167b498-1534-4d00-a99b-8c057f413727" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CarAvailability",
                table: "Cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "862fa604-6c40-46e7-bd5a-190e507df1fd", "AQAAAAEAACcQAAAAELGNAwwWnSCZmT8WqWVA3oni4t7v3JwGS7l65fmGJH3PdUQMAcdbH6MT69iLKDS0Mw==", "cf30fc76-3997-4b17-9e19-8cce11a4dd40" });
        }
    }
}
