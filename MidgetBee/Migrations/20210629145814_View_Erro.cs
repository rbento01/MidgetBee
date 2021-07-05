using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class View_Erro : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "013abf85-a55d-48b2-956c-09ce0086fb97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "e6b87330-d34e-4b92-bbc8-1cacbb8defde");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "1662d547-a9f4-403a-be4a-8b46e536afe7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "447a48e5-72c5-40c8-b47d-a50058f367a2");
        }
    }
}
