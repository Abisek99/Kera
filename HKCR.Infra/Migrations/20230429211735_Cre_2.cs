using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Cre_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000974c4-e599-4849-bb47-59cbfc38b8bb", "AQAAAAEAACcQAAAAEIw0Zz6Ltu/aoZfWD4mz4gkcftnUNKh8+4pDKU+YHdenBMPSqyGVg+mexe4yuKb6Zw==", "9e1a3ad6-192c-48eb-8d1f-8c7cd9ff9358" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b59974e2-3bc3-4b61-b203-9b092f251ddc", "AQAAAAEAACcQAAAAEDj6CKqq1IBxD7aFYiSPixcfZbcOwYiN7iY2p6HfWGoDL8k7AUeFpKwkWJQNakVfrA==", "ae329f7f-316b-4644-a417-1514466493c0" });
        }
    }
}
