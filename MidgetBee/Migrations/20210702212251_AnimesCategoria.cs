using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class AnimesCategoria : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "AnimesCategoria",
                columns: table => new {
                    idAnimesCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimesFK = table.Column<int>(type: "int", nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "99bf4f0d-1d8e-4f5e-b17e-637eacd40650");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "2e79e325-8cbf-41bc-9387-2bf5d00b074b");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "NomeCategoria" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Love" },
                    { 4, "Historical" },
                    { 5, "Adventure" },
                    { 6, "Shounen" },
                    { 7, "Supernatural" },
                    { 8, "Terror" },
                    { 9, "Drama" },
                    { 10, "Ecchi" }
                });

            migrationBuilder.InsertData(
                table: "AnimesCategoria",
                columns: new[] { "idAnimesCategoria", "AnimesFK", "CategoriaFK" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 10, 10, 10 },
                    { 29, 29, 9 },
                    { 19, 19, 9 },
                    { 9, 9, 9 },
                    { 28, 28, 8 },
                    { 18, 18, 8 },
                    { 8, 8, 8 },
                    { 27, 27, 7 },
                    { 17, 17, 7 },
                    { 7, 7, 7 },
                    { 26, 26, 6 },
                    { 16, 16, 6 },
                    { 6, 6, 6 },
                    { 25, 25, 5 },
                    { 15, 15, 5 },
                    { 5, 5, 5 },
                    { 24, 24, 4 },
                    { 14, 14, 4 },
                    { 4, 4, 4 },
                    { 23, 23, 3 },
                    { 13, 13, 3 },
                    { 3, 3, 3 },
                    { 22, 22, 2 },
                    { 12, 12, 2 },
                    { 2, 2, 2 },
                    { 21, 21, 1 },
                    { 11, 11, 1 },
                    { 20, 20, 10 },
                    { 30, 30, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCategoria_AnimesFK",
                table: "AnimesCategoria",
                column: "AnimesFK");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesCategoria_CategoriaFK",
                table: "AnimesCategoria",
                column: "CategoriaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AnimesCategoria");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 10);

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
        }
    }
}
