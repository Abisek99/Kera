using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Car_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarImage",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "067acbf7-1764-46b8-8a60-b1f5f878f5b7", "ADMIN@HAJUR.COM", "HAJUR KO ADMIN", "AQAAAAEAACcQAAAAEOtDieP8h4I179vZ4JLIv26w3rACSuGfVW5GSGxwujsXekJUFakPfXB8KL4TMsPLlA==", "b76ade3e-7ed5-444a-a453-7d215d6539d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImage",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60bed42a-94d9-4157-a350-8c2a2aae05fd", null, "ADMIN@HAJUR.COM", "AQAAAAEAACcQAAAAEHBnC2ukoMSLrfnuCeKSlCIEdf2WxHZvC/H3bSQX7fvfe5AlNm8J2nhW9ahO1OQCyw==", "53feeaa3-ebdc-4a2b-9b19-b250bfeab53f" });
        }
    }
}
