using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations
{
    public partial class Autenticacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 2,
                column: "Autor",
                value: "Masashi Kishimoto");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 3,
                column: "Autor",
                value: "Masashi Kishimoto");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 4,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Tite Kubo", "https://www.crunchyroll.com/pt-pt/bleach" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 5,
                column: "Autor",
                value: "Eichiro Oda");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 6,
                columns: new[] { "Autor", "Fotografia", "Links" },
                values: new object[] { "Akira Toriyama", "Dragon_Ball_Z.jpg", "https://www.funimation.com/shows/dragon-ball-z/" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 7,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Akira Toriyama", "https://www.crunchyroll.com/pt-pt/dragon-ball-super" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 8,
                column: "Autor",
                value: "Hajime Isayama");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 9,
                column: "Autor",
                value: "Kōhei Horikoshi");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 10,
                column: "Autor",
                value: "Gege Akutami");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 11,
                columns: new[] { "Autor", "Categoria", "Data", "Fotografia", "Links", "Rating" },
                values: new object[] { "Koyoharu Gotouge", "Action, Demons, Historical, Shounen, Supernatural", "6 de abril de 2019", "Demon_Slayer.jpg", "https://www.crunchyroll.com/pt-pt/demon-slayer-kimetsu-no-yaiba", 8.5899999999999999 });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 12,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Mika Nomura", "https://www.crunchyroll.com/pt-pt/steinsgate" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 13,
                columns: new[] { "Autor", "Categoria", "Fotografia", "Links" },
                values: new object[] { "Rui Tsukiyo", "Adventure, Harem, Drama, Magic, Ecchi, Fantasy", "Redo_of_Healer.jpg", "https://9anime.to/watch/redo-of-healer.8rvv" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 14,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Tsugumi Ohba", "https://www.crunchyroll.com/pt-pt/death-note-drama" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 15,
                column: "Autor",
                value: "Yoshihiro Togashi");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 16,
                columns: new[] { "Autor", "Estudio", "Links" },
                values: new object[] { "Nakaba Suzuki", "A-1 Pictures", "https://www.funimation.com/shows/the-seven-deadly-sins/?qid=None" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 17,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Haruichi Furudate", "https://www.crunchyroll.com/pt-pt/haikyu" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 18,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Gorō Taniguchi", "https://www.crunchyroll.com/pt-pt/code-geass" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 19,
                column: "Autor",
                value: "Hiro Mashima");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 20,
                columns: new[] { "Autor", "Fotografia" },
                values: new object[] { "Yuki Tabata", "Black_Clover.jpg" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 21,
                column: "Autor",
                value: "Boichi");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 22,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Junichi Masuda", "https://www.crunchyroll.com/pt-pt/library/Pokemon" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 23,
                column: "Autor",
                value: "Negi Haruba");

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 24,
                columns: new[] { "Autor", "Estudio", "Links" },
                values: new object[] { "Code:000", "A -1 Pictures//Trigger//CloverWorks", "https://crunchyroll.com/pt-pt/series/GY8VEQ95Y/DARLING-in-the-FRANXX" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 25,
                columns: new[] { "Autor", "Links" },
                values: new object[] { "Sui Ishida", "https://www.crunchyroll.com/pt-pt/tokyo-ghoul" });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "IdAnime", "Autor", "Categoria", "Data", "Estudio", "Fotografia", "Links", "Nome", "QuantEpisodios", "Rating", "Sinopse" },
                values: new object[,]
                {
                    { 29, "Makoto Yukimura", "Action, Adventure, Drama, Historical, Seinen", "8 de julho, 2019 até ?", "Wit Studio", "VinSaga.jpg", "https://9anime.to/watch/vinland-saga.77zy", "Vinland Saga", "24", 8.7100000000000009, "Young Thorfinn grew up listening to the stories of old sailors that had traveled the ocean and reached the place of legend, Vinland. It's said to be warm and fertile, a place where there would be no need for fighting—not at all like the frozen village in Iceland where he was born, and certainly not like his current life as a mercenary. War is his home now. Though his father once told him, 'You have no enemies, nobody does.There is nobody who it's okay to hurt,' as he grew, Thorfinn knew that nothing was further from the truth. The war between England and the Danes grows worse with each passing year.Death has become commonplace, and the viking mercenaries are loving every moment of it.Allying with either side will cause a massive swing in the balance of power, and the vikings are happy to make names for themselves and take any spoils they earn along the way.Among the chaos, Thorfinn must take his revenge and kill Askeladd, the man who murdered his father.The only paradise for the vikings, it seems, is the era of war and death that rages on." },
                    { 28, "Yuu Kamiya", "Game, Adventure, Comedy, Supernatural, Ecchi, Fantasy", "9 de abril, 2014 até 25 de junho 2014", "Madhouse", "NGNL.png", "https://www.crunchyroll.com/pt-pt/no-game-no-life", "No Game No Life", "12", 8.1600000000000001, "No Game No Life is a surreal comedy that follows Sora and Shiro, shut-in NEET siblings and the online gamer duo behind the legendary username 'Blank.' They view the real world as just another lousy game; however, a strange e-mail challenging them to a chess match changes everything—the brother and sister are plunged into an otherworldly realm where they meet Tet, the God of Games. The mysterious god welcomes Sora and Shiro to Disboard, a world where all forms of conflict—from petty squabbles to the fate of whole countries—are settled not through war, but by way of high - stake games.This system works thanks to a fundamental rule wherein each party must wager something they deem to be of equal value to the other party's wager. In this strange land where the very idea of humanity is reduced to child's play, the indifferent genius gamer duo of Sora and Shiro have finally found a real reason to keep playing games: to unite the sixteen races of Disboard, defeat Tet, and become the gods of this new, gaming -is -everything world." },
                    { 27, "Hiromu Arakawa", "Action, Military, Adventure, Comedy, Drama, Magic, Fantasy, Shounen", "5 de abril, 2009 até 4 de julho, 2010", "Bones", "FMA.jpg", "https://www.crunchyroll.com/pt-pt/fullmetal-alchemist-brotherhood", "Fullmetal Alchimist Brotherhood", "64", 9.1699999999999999, "Alchemy is bound by this Law of Equivalent Exchange—something the young brothers Edward and Alphonse Elric only realize after attempting human transmutation: the one forbidden act of alchemy. They pay a terrible price for their transgression—Edward loses his left leg, Alphonse his physical body. It is only by the desperate sacrifice of Edward's right arm that he is able to affix Alphonse's soul to a suit of armor. Devastated and alone, it is the hope that they would both eventually return to their original bodies that gives Edward the inspiration to obtain metal limbs called 'automail' and become a state alchemist, the Fullmetal Alchemist. Three years of searching later, the brothers seek the Philosopher's Stone, a mythical relic that allows an alchemist to overcome the Law of Equivalent Exchange. Even with military allies Colonel Roy Mustang, Lieutenant Riza Hawkeye, and Lieutenant Colonel Maes Hughes on their side, the brothers find themselves caught up in a nationwide conspiracy that leads them not only to the true nature of the elusive Philosopher's Stone, but their country's murky history as well. In between finding a serial killer and racing against time, Edward and Alphonse must ask themselves if what they are doing will make them human again... or take away their humanity." },
                    { 30, "Yuto Tsukuda", "Ecchi, School, Shounen", "4 de abril de 2015 até 26 de setembro, 2020", "J.C.Staff", "FoodWars.jpg", "https://www.crunchyroll.com/pt-pt/food-wars-shokugeki-no-soma", "Shokugeki No Souma", "73", 8.2400000000000002, "Ever since he was a child, fifteen-year-old Souma Yukihira has helped his father by working as the sous chef in the restaurant his father runs and owns. Throughout the years, Souma developed a passion for entertaining his customers with his creative, skilled, and daring culinary creations. His dream is to someday own his family's restaurant as its head chef. Yet when his father suddenly decides to close the restaurant to test his cooking abilities in restaurants around the world, he sends Souma to Tootsuki Culinary Academy, an elite cooking school where only 10 percent of the students graduate.The institution is famous for its 'Shokugeki' or 'food wars,' where students face off in intense, high - stakes cooking showdowns. As Souma and his new schoolmates struggle to survive the extreme lifestyle of Tootsuki, more and greater challenges await him, putting his years of learning under his father to the test." },
                    { 26, "Sango Harukawa", "Action, Adventure, Fantasy", "7 de abril de 2016 até 8 de agosto, 2020", "Bones", "BSD.png", "https://www.crunchyroll.com/pt-pt/bungo-stray-dogs", "Bungou Stray Dogs", "49", 7.7999999999999998, "For weeks, Atsushi Nakajima's orphanage has been plagued by a mystical tiger that only he seems to be aware of. Suspected to be behind the strange incidents, the 18-year-old is abruptly kicked out of the orphanage and left hungry, homeless, and wandering through the city. While starving on a riverbank, Atsushi saves a rather eccentric man named Osamu Dazai from drowning.Whimsical suicide enthusiast and supernatural detective, Dazai has been investigating the same tiger that has been terrorizing the boy.Together with Dazai's partner Doppo Kunikida, they solve the mystery, but its resolution leaves Atsushi in a tight spot. As various odd events take place, Atsushi is coerced into joining their firm of supernatural investigators, taking on unusual cases the police cannot handle, alongside his numerous enigmatic co-workers.v" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 2,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 3,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 4,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "https://www.funimation.com/bleach/" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 5,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 6,
                columns: new[] { "Autor", "Fotografia", "Links" },
                values: new object[] { null, "Dragon_Ball_Z", "https://www.funimation.com/Dragon+Ball+Z/" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 7,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "https://beta.crunchyroll.com/pt-pt/series/GR19V7816/Dragon-Ball-Super" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 8,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 9,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 10,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 11,
                columns: new[] { "Autor", "Categoria", "Data", "Fotografia", "Links", "Rating" },
                values: new object[] { null, "", "6 de abril, 2019 até ?", "", "", 8.5999999999999996 });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 12,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "ARRANJAR LINK FUNIMATION" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 13,
                columns: new[] { "Autor", "Categoria", "Fotografia", "Links" },
                values: new object[] { null, "Redo_of_Healer.jpg", "", "NÃO DISPONIVEL" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 14,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "ARRANJAR LINK" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 15,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 16,
                columns: new[] { "Autor", "Estudio", "Links" },
                values: new object[] { null, "", "AINDA NÃO DISPONIVEL" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 17,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "NÃO DISPONIVEL" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 18,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "NÃO DISPONIVEL" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 19,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 20,
                columns: new[] { "Autor", "Fotografia" },
                values: new object[] { null, "Black_Clover" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 21,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 22,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "AINDA NÃO DISPONIVEL" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 23,
                column: "Autor",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 24,
                columns: new[] { "Autor", "Estudio", "Links" },
                values: new object[] { null, "A-1 Pictures//Trigger//CloverWorks", "https://beta.crunchyroll.com/pt-pt/series/GY8VEQ95Y/DARLING-in-the-FRANXX" });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "IdAnime",
                keyValue: 25,
                columns: new[] { "Autor", "Links" },
                values: new object[] { null, "Ainda não disponivel" });
        }
    }
}
