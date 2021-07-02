using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations
{
    public partial class Categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "AnimesCategorias",
                columns: table => new
                {
                    ListaDeAnimesIdAnime = table.Column<int>(type: "int", nullable: false),
                    ListaDeCategoriasIdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimesCategorias", x => new { x.ListaDeAnimesIdAnime, x.ListaDeCategoriasIdCategoria });
                    table.ForeignKey(
                        name: "FK_AnimesCategorias_Animes_ListaDeAnimesIdAnime",
                        column: x => x.ListaDeAnimesIdAnime,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesCategorias_Categorias_ListaDeCategoriasIdCategoria",
                        column: x => x.ListaDeCategoriasIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "a24f3230-5b41-4180-a9f5-4b25a78c6d9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "6f3fcfed-12f6-4753-b6be-943fe04d8d75");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCategorias_ListaDeCategoriasIdCategoria",
                table: "AnimesCategorias",
                column: "ListaDeCategoriasIdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "4f5ebceb-233c-4d7c-86a2-154c492b902a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "803c03c7-a7fb-4ccd-9e78-4d08b8b130f0");
        }
    }
}
