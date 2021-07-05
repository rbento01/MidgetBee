using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class Favoritos : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AnimesUtilizadores");

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new {
                    IdFavoritos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersFK = table.Column<int>(type: "int", nullable: false),
                    AnimeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavoritos);
                    table.ForeignKey(
                        name: "FK_Favoritos_Animes_AnimeFK",
                        column: x => x.AnimeFK,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Utilizadores_UsersFK",
                        column: x => x.UsersFK,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUsers",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_AnimeFK",
                table: "Favoritos",
                column: "AnimeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsersFK",
                table: "Favoritos",
                column: "UsersFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.CreateTable(
                name: "AnimesUtilizadores",
                columns: table => new {
                    ListaDeAnimesIdAnime = table.Column<int>(type: "int", nullable: false),
                    ListaDeUsersIdUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AnimesUtilizadores", x => new { x.ListaDeAnimesIdAnime, x.ListaDeUsersIdUsers });
                    table.ForeignKey(
                        name: "FK_AnimesUtilizadores_Animes_ListaDeAnimesIdAnime",
                        column: x => x.ListaDeAnimesIdAnime,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimesUtilizadores_Utilizadores_ListaDeUsersIdUsers",
                        column: x => x.ListaDeUsersIdUsers,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUsers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "89e37664-9d5d-427e-93fa-55cb1d015785");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "479955c2-1ab8-421b-9868-37c9f9ffefb8");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesUtilizadores_ListaDeUsersIdUsers",
                table: "AnimesUtilizadores",
                column: "ListaDeUsersIdUsers");
        }
    }
}
