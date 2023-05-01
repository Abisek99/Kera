using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class changePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3cafba7d-4b79-41ac-98a6-c00abec98d96", "AQAAAAEAACcQAAAAEAWfvxRw04un/4sWMOnADNrLxi63H0wuMWJRS198Pc3TTNZRTpZZv7Ras9VwcIQg3A==", "71539791-342d-4b0e-9b9f-34eba2b7f25c", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2bb5f951-a70a-468c-a65d-38907a3a4a7b", "AQAAAAEAACcQAAAAEKZvOOYPEXZcwsD/23dlW3dKJyRIbvAvtiF9GUnRsO6f/nM84n4D1Eh/sSsNkD5n/A==", "a4d57c83-d4a7-4b8a-b277-da8efd9af1af", "Admin" });
        }
    }
}
