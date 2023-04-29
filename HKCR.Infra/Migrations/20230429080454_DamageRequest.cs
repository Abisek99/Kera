using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HKCR.Infra.Migrations
{
    public partial class DamageRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5323753-855b-4cf8-bf37-2fd1862a8bc8", "AQAAAAEAACcQAAAAENkaAB6XqMJJM35q4nZbMBi6v/C2ajncRdtRAzRowNRET0/UiOKXPW4rbJ6N4kMYRQ==", "75ab8e4f-a023-41b2-ac90-1414f1fbc089" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7eaccb5-484b-4ea5-b341-afcd8bcfb3aa", "AQAAAAEAACcQAAAAEMYm56BUqOPvMck+I5+tZyz7SEvCNaiNssTDcS6UViCuFiqjGQcihLH6uKnXf9c1YQ==", "97e724ee-02e9-4956-8a1c-b1799a511556" });
        }
    }
}
