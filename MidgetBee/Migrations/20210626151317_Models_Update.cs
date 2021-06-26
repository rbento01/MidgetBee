using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations
{
    public partial class Models_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimesUtilizadores");

            migrationBuilder.DropTable(
                name: "EpisodiosUtilizadores");

            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "d3b18522-6d59-44f5-83fb-e03da839bdcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "722cce40-9e2c-405a-9668-6507d8e39281");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimesUtilizadores",
                columns: table => new
                {
                    ListaDeAnimesIdAnime = table.Column<int>(type: "int", nullable: false),
                    ListaDeUsersIdUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new
                {
                    NumEpisodio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeFK = table.Column<int>(type: "int", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodios", x => x.NumEpisodio);
                    table.ForeignKey(
                        name: "FK_Episodios_Animes_AnimeFK",
                        column: x => x.AnimeFK,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodiosUtilizadores",
                columns: table => new
                {
                    ListaDeEpisodiosNumEpisodio = table.Column<int>(type: "int", nullable: false),
                    ListaDeUsersIdUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodiosUtilizadores", x => new { x.ListaDeEpisodiosNumEpisodio, x.ListaDeUsersIdUsers });
                    table.ForeignKey(
                        name: "FK_EpisodiosUtilizadores_Episodios_ListaDeEpisodiosNumEpisodio",
                        column: x => x.ListaDeEpisodiosNumEpisodio,
                        principalTable: "Episodios",
                        principalColumn: "NumEpisodio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodiosUtilizadores_Utilizadores_ListaDeUsersIdUsers",
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
                value: "3374fed2-fea8-456d-b5d1-dfab7e4f2bf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "16e8ec0d-709c-4634-80c7-48030c1237e3");

            migrationBuilder.CreateIndex(
                name: "IX_AnimesUtilizadores_ListaDeUsersIdUsers",
                table: "AnimesUtilizadores",
                column: "ListaDeUsersIdUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_AnimeFK",
                table: "Episodios",
                column: "AnimeFK");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodiosUtilizadores_ListaDeUsersIdUsers",
                table: "EpisodiosUtilizadores",
                column: "ListaDeUsersIdUsers");
        }
    }
}
