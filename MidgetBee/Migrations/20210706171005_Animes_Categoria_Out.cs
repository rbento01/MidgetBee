using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations
{
    public partial class Animes_Categoria_Out : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesCategoria");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "4a76f627-8772-40c5-b17f-054a64b77d7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "f119f4f9-85be-4b77-966e-e2aee33ab32d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimesCategoria",
                columns: table => new
                {
                    idAnimesCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimesFK = table.Column<int>(type: "int", nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesCategoria", x => x.idAnimesCategoria);
                    table.ForeignKey(
                        name: "FK_AnimesCategoria_Animes_AnimesFK",
                        column: x => x.AnimesFK,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesCategoria_Categorias_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimesCategoria",
                columns: new[] { "idAnimesCategoria", "AnimesFK", "CategoriaFK" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 35, 18, 8 },
                    { 36, 18, 9 },
                    { 37, 19, 9 },
                    { 38, 19, 10 },
                    { 39, 20, 10 },
                    { 40, 20, 1 },
                    { 41, 20, 2 },
                    { 42, 21, 1 },
                    { 43, 21, 2 },
                    { 44, 22, 2 },
                    { 45, 22, 3 },
                    { 46, 23, 3 },
                    { 47, 23, 4 },
                    { 48, 24, 4 },
                    { 49, 24, 5 },
                    { 50, 25, 5 },
                    { 51, 25, 6 },
                    { 52, 26, 6 },
                    { 53, 26, 7 },
                    { 54, 27, 7 },
                    { 55, 27, 8 },
                    { 56, 28, 8 },
                    { 57, 28, 9 },
                    { 58, 29, 9 },
                    { 59, 29, 10 },
                    { 60, 30, 10 },
                    { 61, 30, 1 },
                    { 34, 17, 8 },
                    { 33, 17, 7 },
                    { 32, 16, 7 },
                    { 16, 8, 9 },
                    { 4, 2, 3 },
                    { 5, 3, 3 },
                    { 6, 3, 4 },
                    { 7, 4, 4 },
                    { 8, 4, 5 },
                    { 9, 5, 5 },
                    { 10, 5, 6 },
                    { 11, 6, 6 },
                    { 12, 6, 7 },
                    { 13, 7, 7 }
                });

            migrationBuilder.InsertData(
                table: "AnimesCategoria",
                columns: new[] { "idAnimesCategoria", "AnimesFK", "CategoriaFK" },
                values: new object[,]
                {
                    { 14, 7, 8 },
                    { 15, 8, 8 },
                    { 31, 16, 6 },
                    { 17, 9, 9 },
                    { 18, 9, 10 },
                    { 19, 10, 10 },
                    { 20, 10, 1 },
                    { 21, 11, 1 },
                    { 22, 11, 2 },
                    { 23, 12, 2 },
                    { 24, 12, 3 },
                    { 25, 13, 3 },
                    { 26, 13, 4 },
                    { 27, 14, 4 },
                    { 28, 14, 5 },
                    { 29, 15, 5 },
                    { 30, 15, 6 },
                    { 3, 2, 2 },
                    { 2, 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "66e89ecc-c4de-4a9f-86a7-9244b90b67a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "7d1ac2e1-67a9-498f-bd77-bc6926a17f54");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCategoria_AnimesFK",
                table: "AnimesCategoria",
                column: "AnimesFK");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCategoria_CategoriaFK",
                table: "AnimesCategoria",
                column: "CategoriaFK");
        }
    }
}
