using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class aeg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bb5f951-a70a-468c-a65d-38907a3a4a7b", "AQAAAAEAACcQAAAAEKZvOOYPEXZcwsD/23dlW3dKJyRIbvAvtiF9GUnRsO6f/nM84n4D1Eh/sSsNkD5n/A==", "a4d57c83-d4a7-4b8a-b277-da8efd9af1af" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a35cb9-8fcc-4a1b-8134-fa0a538fea4e", "AQAAAAEAACcQAAAAEG7dfiTb1Arok8sU/yAAJUSv5SNQSJxoCAqt4T9ljld3DwKrWerrakXikxou/rlXVg==", "f5f8b335-daeb-445e-9bbb-65ae1761b984" });
        }
    }
}
