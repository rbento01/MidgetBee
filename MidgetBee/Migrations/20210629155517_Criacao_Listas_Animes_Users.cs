using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class Criacao_Listas_Animes_Users : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
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

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AnimesUtilizadores");

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
    }
}
