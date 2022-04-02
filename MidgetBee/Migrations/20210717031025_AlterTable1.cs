using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations
{
    public partial class AlterTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 2,
                column: "Data",
                value: "15th of February, 2007 until 23th of March, 2017");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "3bca4d4d-3297-41f4-9dcc-31a1a13f26d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "522dd41f-b1c7-46bf-b54e-ec79d675d8d4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 2,
                column: "Data",
                value: "15th of February, 2007 until 23 of March, 2017");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "b872cecf-2590-43f9-abcf-77ee0fe32d3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "b405a1b6-d47d-4c73-9f3b-9c031c61c2d6");
        }
    }
}
