using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61929cea-639a-46de-a8f7-ed2395086dfa", "AQAAAAEAACcQAAAAENUG2IS6nAr/2Lp1aYTPynPL36XpakCMvrHakFiEg96YPkoWEDZvCyDD1MtAzbim1A==", "2e7450d6-7deb-43e8-ab5e-334ccf4603cc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "000974c4-e599-4849-bb47-59cbfc38b8bb", "AQAAAAEAACcQAAAAEIw0Zz6Ltu/aoZfWD4mz4gkcftnUNKh8+4pDKU+YHdenBMPSqyGVg+mexe4yuKb6Zw==", "9e1a3ad6-192c-48eb-8d1f-8c7cd9ff9358" });
        }
    }
}
