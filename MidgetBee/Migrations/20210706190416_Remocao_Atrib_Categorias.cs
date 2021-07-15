using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class Remocao_Atrib_Categorias : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Animes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "e6cf3c13-7df2-4762-a2fc-ca9311aad68e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "c522434a-b5ee-4b60-a490-96ba31bbbf59");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 1,
                column: "Categoria",
                value: "Adventure, Fantasy, Comedy, Martial Arts");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 2,
                column: "Categoria",
                value: "Adventure, Fantasy, Comedy, Martial Arts");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 3,
                column: "Categoria",
                value: "Adventure, Fantasy, Comedy, Martial Arts");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 4,
                column: "Categoria",
                value: "Adventure, ‎Supernatural");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 5,
                column: "Categoria",
                value: "Adventure, Fantasy, Comedy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 6,
                column: "Categoria",
                value: "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 7,
                column: "Categoria",
                value: "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 8,
                column: "Categoria",
                value: "Action, Dark Fantasy, Post-Apocalyptic");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 9,
                column: "Categoria",
                value: "Adventure, Fantasy, Superhero");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 10,
                column: "Categoria",
                value: "Adventure Fiction, Supernatural Fiction, Dark Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 11,
                column: "Categoria",
                value: "Action, Demons, Historical, Shounen, Supernatural");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 12,
                column: "Categoria",
                value: "Psychological Thriller, Science Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 13,
                column: "Categoria",
                value: "Adventure, Harem, Drama, Magic, Ecchi, Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 14,
                column: "Categoria",
                value: "Mystery, Suspense, Psychological Suspense");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 15,
                column: "Categoria",
                value: "Adventure Fiction, Martial Arts, Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 16,
                column: "Categoria",
                value: "Adventure Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 17,
                column: "Categoria",
                value: "Comedy, Sports");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 18,
                column: "Categoria",
                value: "Action, Mecha, Adventure, Suspense, Military Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 19,
                column: "Categoria",
                value: "Fantasy, Adventure Fiction");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 20,
                column: "Categoria",
                value: "Adventure, Fantasy, Comedy, Action");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 21,
                column: "Categoria",
                value: "Adventure, Post-Apocalyptic, Science Fiction, Comedy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 22,
                column: "Categoria",
                value: "Adventure, Comedy, Drama, Action, Science Fiction, Suspense");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 23,
                column: "Categoria",
                value: "Harem, Romantic Comedy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 24,
                column: "Categoria",
                value: "Romance, Science Fiction, Mecha");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 25,
                column: "Categoria",
                value: "Dark Fantasy, Suspense, Horror, Thriller, Gore, Supernatural, Action");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 26,
                column: "Categoria",
                value: "Action, Adventure, Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 27,
                column: "Categoria",
                value: "Action, Military, Adventure, Comedy, Drama, Magic, Fantasy, Shounen");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 28,
                column: "Categoria",
                value: "Game, Adventure, Comedy, Supernatural, Ecchi, Fantasy");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 29,
                column: "Categoria",
                value: "Action, Adventure, Drama, Historical, Seinen");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 30,
                column: "Categoria",
                value: "Ecchi, School, Shounen");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "371f3f60-ff3b-4c2e-9b58-a64b6b96b132");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "235dc80d-a43e-4c05-9765-fa3514714871");
        }
    }
}
