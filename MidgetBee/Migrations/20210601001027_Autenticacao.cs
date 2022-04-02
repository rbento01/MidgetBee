using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MidgetBee.Migrations {
    public partial class Autenticacao : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new {
                    IdAnime = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantEpisodios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Animes", x => x.IdAnime);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new {
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
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new {
                    IdUsers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Utilizadores", x => x.IdUsers);
                });

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new {
                    NumEpisodio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Episodios", x => x.NumEpisodio);
                    table.ForeignKey(
                        name: "FK_Episodios_Animes_AnimeFK",
                        column: x => x.AnimeFK,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
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
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
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
                columns: table => new {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
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
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
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
                columns: table => new {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new {
                    IdReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visibilidade = table.Column<bool>(type: "bit", nullable: false),
                    UsersFK = table.Column<int>(type: "int", nullable: false),
                    AnimeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Reviews", x => x.IdReview);
                    table.ForeignKey(
                        name: "FK_Reviews_Animes_AnimeFK",
                        column: x => x.AnimeFK,
                        principalTable: "Animes",
                        principalColumn: "IdAnime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Utilizadores_UsersFK",
                        column: x => x.UsersFK,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUsers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodiosUtilizadores",
                columns: table => new {
                    ListaDeEpisodiosNumEpisodio = table.Column<int>(type: "int", nullable: false),
                    ListaDeUsersIdUsers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
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

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "IdAnime", "Autor", "Categoria", "Data", "Estudio", "Fotografia", "Links", "Nome", "QuantEpisodios", "Rating", "Sinopse" },
                values: new object[,]
                {
                    { 1, "Masashi Kishimoto", "Adventure, Fantasy, Comedy, Martial Arts", "3 de outubro, 2002 até 8 de fevereiro, 2007", "Studio Pierrot", "Naruto.jpg", "https://beta.crunchyroll.com/pt-pt/series/GY9PJ5KWR/Naruto", "Naruto", "220", 7.9199999999999999, "Moments prior to Naruto Uzumaki's birth, a huge demon known as the Kyuubi, the Nine-Tailed Fox, attacked Konohagakure, the Hidden Leaf Village, and wreaked havoc. In order to put an end to the Kyuubi's rampage, the leader of the village, the Fourth Hokage, sacrificed his life and sealed the monstrous beast inside the newborn Naruto. Now, Naruto is a hyperactive and knuckle-headed ninja still living in Konohagakure. Shunned because of the Kyuubi inside him, Naruto struggles to find his place in the village, while his burning desire to become the Hokage of Konohagakure leads him not only to some great new friends, but also some deadly foes." },
                    { 28, "Yuu Kamiya", "Game, Adventure, Comedy, Supernatural, Ecchi, Fantasy", "9 de abril, 2014 até 25 de junho 2014", "Madhouse", "NGNL.png", "https://www.crunchyroll.com/pt-pt/no-game-no-life", "No Game No Life", "12", 8.1600000000000001, "No Game No Life is a surreal comedy that follows Sora and Shiro, shut-in NEET siblings and the online gamer duo behind the legendary username 'Blank.' They view the real world as just another lousy game; however, a strange e-mail challenging them to a chess match changes everything—the brother and sister are plunged into an otherworldly realm where they meet Tet, the God of Games. The mysterious god welcomes Sora and Shiro to Disboard, a world where all forms of conflict—from petty squabbles to the fate of whole countries—are settled not through war, but by way of high - stake games.This system works thanks to a fundamental rule wherein each party must wager something they deem to be of equal value to the other party's wager. In this strange land where the very idea of humanity is reduced to child's play, the indifferent genius gamer duo of Sora and Shiro have finally found a real reason to keep playing games: to unite the sixteen races of Disboard, defeat Tet, and become the gods of this new, gaming -is -everything world." },
                    { 27, "Hiromu Arakawa", "Action, Military, Adventure, Comedy, Drama, Magic, Fantasy, Shounen", "5 de abril, 2009 até 4 de julho, 2010", "Bones", "fma.jpg", "https://www.crunchyroll.com/pt-pt/fullmetal-alchemist-brotherhood", "Fullmetal Alchimist Brotherhood", "64", 9.1699999999999999, "Alchemy is bound by this Law of Equivalent Exchange—something the young brothers Edward and Alphonse Elric only realize after attempting human transmutation: the one forbidden act of alchemy. They pay a terrible price for their transgression—Edward loses his left leg, Alphonse his physical body. It is only by the desperate sacrifice of Edward's right arm that he is able to affix Alphonse's soul to a suit of armor. Devastated and alone, it is the hope that they would both eventually return to their original bodies that gives Edward the inspiration to obtain metal limbs called 'automail' and become a state alchemist, the Fullmetal Alchemist. Three years of searching later, the brothers seek the Philosopher's Stone, a mythical relic that allows an alchemist to overcome the Law of Equivalent Exchange. Even with military allies Colonel Roy Mustang, Lieutenant Riza Hawkeye, and Lieutenant Colonel Maes Hughes on their side, the brothers find themselves caught up in a nationwide conspiracy that leads them not only to the true nature of the elusive Philosopher's Stone, but their country's murky history as well. In between finding a serial killer and racing against time, Edward and Alphonse must ask themselves if what they are doing will make them human again... or take away their humanity." },
                    { 26, "Sango Harukawa", "Action, Adventure, Fantasy", "7 de abril de 2016 até 8 de agosto, 2020", "Bones", "BSD.png", "https://www.crunchyroll.com/pt-pt/bungo-stray-dogs", "Bungou Stray Dogs", "49", 7.7999999999999998, "For weeks, Atsushi Nakajima's orphanage has been plagued by a mystical tiger that only he seems to be aware of. Suspected to be behind the strange incidents, the 18-year-old is abruptly kicked out of the orphanage and left hungry, homeless, and wandering through the city. While starving on a riverbank, Atsushi saves a rather eccentric man named Osamu Dazai from drowning.Whimsical suicide enthusiast and supernatural detective, Dazai has been investigating the same tiger that has been terrorizing the boy.Together with Dazai's partner Doppo Kunikida, they solve the mystery, but its resolution leaves Atsushi in a tight spot. As various odd events take place, Atsushi is coerced into joining their firm of supernatural investigators, taking on unusual cases the police cannot handle, alongside his numerous enigmatic co-workers.v" },
                    { 25, "Sui Ishida", "Dark Fantasy, Suspense, Horror, Thriller, Gore, Supernatural, Action", "4 de julho, 2014 até 19 de junho, 2018", "Studio Pierrot", "Tokyo_Ghoul.jpg", "https://www.crunchyroll.com/pt-pt/tokyo-ghoul", "Tokyo Ghoul", "48", 7.0999999999999996, "Tokyo has become a cruel and merciless city—a place where vicious creatures called 'ghouls' exist alongside humans. The citizens of this once great metropolis live in constant fear of these bloodthirsty savages and their thirst for human flesh. However, the greatest threat these ghouls pose is their dangerous ability to masquerade as humans and blend in with society. Based on the best - selling supernatural horror manga by Sui Ishida, Tokyo Ghoul follows Ken Kaneki, a shy, bookish college student, who is instantly drawn to Rize Kamishiro, an avid reader like himself.However, Rize is not exactly who she seems, and this unfortunate meeting pushes Kaneki into the dark depths of the ghouls' inhuman world. In a twist of fate, Kaneki is saved by the enigmatic waitress Touka Kirishima, and thus begins his new, secret life as a half-ghoul/half-human who must find a way to integrate into both societies." },
                    { 24, "Code:000", "Romance, Science Fiction, Mecha", "13 de janeiro, 2018 até 7 de julho, 2018", "A -1 Pictures//Trigger//CloverWorks", "Darling_Franxx.jpg", "https://crunchyroll.com/pt-pt/series/GY8VEQ95Y/DARLING-in-the-FRANXX", "Darling In The FranXX", "24", 7.3099999999999996, "In the distant future, humanity has been driven to near-extinction by giant beasts known as Klaxosaurs, forcing the surviving humans to take refuge in massive fortress cities called Plantations. Children raised here are trained to pilot giant mechas known as FranXX—the only weapons known to be effective against the Klaxosaurs—in boy-girl pairs. Bred for the sole purpose of piloting these machines, these children know nothing of the outside world and are only able to prove their existence by defending their race. Hiro, an aspiring FranXX pilot, has lost his motivation and self - confidence after failing an aptitude test.Skipping out on his class' graduation ceremony, Hiro retreats to a forest lake, where he encounters a mysterious girl with two horns growing out of her head. She introduces herself by her codename Zero Two, which is known to belong to an infamous FranXX pilot known as the 'Partner Killer.' Before Hiro can digest the encounter, the Plantation is rocked by a sudden Klaxosaur attack. Zero Two engages the creature in her FranXX, but it is heavily damaged in the skirmish and crashes near Hiro. Finding her partner dead, Zero Two invites Hiro to pilot the mecha with her, and the duo easily defeats the Klaxosaur in the ensuing fight. With a new partner by his side, Hiro has been given a chance at redemption for his past failures, but at what cost?" },
                    { 23, "Negi Haruba", "Harem, Romantic Comedy", "8 de janeiro, 2021 até ?", "Bibury Animation Studios", "Quint_Quint.jpg", "https://beta.crunchyroll.com/pt-pt/series/GY4PD7Z06/The-Quintessential-Quintuplets", "The Quintessential Quintuplets", "?", 7.9000000000000004, "Through their tutor Fuutarou Uesugi's diligent guidance, the NakData quintuplets' academic performance shows signs of improvement, even if their path to graduation is still rocky. However, as they continue to cause various situations that delay any actual tutoring, Fuutarou becomes increasingly involved with their personal lives, further complicating their relationship with each other. On Datather note, Fuutarou slowly begins to realize the existence of a possible connection between him and the past he believes to have shared with one of the five girls.With everyone's feelings beginning to develop and overlap, will they be able to keep their bond strictly to that of a teacher and his students—or will it mature into something else entirely?" },
                    { 22, "Junichi Masuda", "Adventure, Comedy, Drama, Action, Science Fiction, Suspense", "1 de abril 1997 até 14 de novembro de 2002", "OLM", "pokemon.jpg", "https://www.crunchyroll.com/pt-pt/library/Pokemon", "Pokémon", "276", 7.3399999999999999, "Pokemon are peculiar creatures with a vast array of different abilities and appearances; many people, known as Pokemon trainers, capture and train them, often with the intent of battling others. Young Satoshi has not only dreamed of becoming a Pokemon trainer but also a 'Pokemon Master, ' and on the arrival of his 10th birthday, he finally has a chance to make that dream a reality. Unfortunately for him, all three Pokemon available to beginning trainers have already been claimed and only Pikachu, a rebellious Electric type Pokemon, remains. However, this chance encounter would mark the start of a lifelong friendship and an epic adventure! Setting off on a journey to become the very best, Satoshi and Pikachu travel across beautiful, sprawling regions with their friends Kasumi, a Water type trainer, and Takeshi, a Rock type trainer.But danger lurks around every corner.The infamous Team Rocket is always nearby, seeking to steal powerful Pokemon through nefarious schemes.It'll be up to Satoshi and his friends to thwart their efforts as he also strives to earn the eight Pokemon Gym Badges he'll need to challenge the Pokemon League, and eventually claim the title of Pokemon Master." },
                    { 21, "Boichi", "Adventure, Post-Apocalyptic, Science Fiction, Comedy", "5 de julho, 2019 até ?", "TMS Entertainment", "Dr_Stone.jpg", "https://beta.crunchyroll.com/pt-pt/series/GYEXQKJG6/Dr-STONE", "Dr. Stone", "?", 8.2699999999999996, "After five years of harboring unspoken feelings, high-schooler Taiju Ooki is finally ready to confess his love to Yuzuriha Ogawa. Just when Taiju begins his confession however, a blinding green light strikes the Earth and petrifies mankind around the world—turning every single human into stone. Several millennia later, Taiju awakens to find the modern world completely nonexistent, as nature has flourished in the years humanity stood still.Among a stone world of statues, Taiju encounters one other living human: his science - loving friend Senkuu, who has been active for a few months.Taiju learns that Senkuu has developed a grand scheme—to launch the complete revival of civilization with science.Taiju's brawn and Senkuu's brains combine to forge a formidable partnership, and they soon uncover a method to revive those petrified. However, Senkuu's master plan is threatened when his ideologies are challenged by those who awaken. All the while, the reason for mankind's petrification remains unknown." },
                    { 20, "Yuki Tabata", "Adventure, Fantasy, Comedy, Action", "3 de outubro,2017 até ?", "Studio Pierrot", "Black_Clover.jpg", "https://beta.crunchyroll.com/pt-pt/series/GRE50KV36/Black-Clover", "Black Clover", "?", 7.9699999999999998, "Asta and Yuno were abandoned at the same church on the same day. Raised together as children, they came to know of the 'Wizard King'—a title given to the strongest mage in the kingdom—and promised that they would compete against each other for the position of the next Wizard King. However, as they grew up, the stark difference between them became evident. While Yuno is able to wield magic with amazing power and control, Asta cannot use magic at all and desperately tries to awaken his powers by training physically.When they reach the age of 15, Yuno is bestowed a spectacular Grimoire with a four - leaf clover, while Asta receives nothing. However, soon after, Yuno is attacked by a person named Lebuty, whose main purpose is to obtain Yuno's Grimoire. Asta tries to fight Lebuty, but he is outmatched. Though without hope and on the brink of defeat, he finds the strength to continue when he hears Yuno's voice. Unleashing his inner emotions in a rage, Asta receives a five - leaf clover Grimoire, a 'Black Clover' giving him enough power to defeat Lebuty.A few days later, the two friends head out into the world, both seeking the same goal—to become the Wizard King!" },
                    { 19, "Hiro Mashima", "Fantasy, Adventure Fiction", "12 de outubro, 2009 até 29 de setembro, 2019", "Satelight//A-1 Pictures", "fairy_tail.jpg", "https://beta.crunchyroll.com/pt-pt/series/G6DQDD3WR/Fairy-Tail", "Fairy Tail", "328", 7.6200000000000001, "In the mystical land of Fiore, magic exists as an essential part of everyday life. Countless magic guilds lie at the core of all magical activity, and serve as venues for like-minded mages to band together and take on job requests. Among them, Fairy Tail stands out from the rest as a place of strength, spirit, and family. Lucy Heartfilia is a young mage searching for celestial gate keys, and her dream is to become a full - fledged wizard by joining this famous guild.In her search, she runs into Natsu Dragneel and his partner Happy, who are on a quest to find Natsu's foster father, the dragon Igneel. Upon being tricked by a man, Lucy falls under an abduction attempt, only to be saved by Natsu.To her shock, he reveals that he is a member of Fairy Tail and invites her to join them.There, Lucy meets the guild's strange members, such as the ice wizard Gray Fullbuster and magic swordswoman Erza Scarlet. Together as a family, they battle the forces of evil, help those in need, and gain new friends, all the while enjoying the never-ending adventure that is Fairy Tail." },
                    { 18, "Gorō Taniguchi", "Action, Mecha, Adventure, Suspense, Military Fiction", "6 de outubro, 2006 até 28 de setembro, 2008", "Sunrise", "Code_Geass.jpg", "https://www.crunchyroll.com/pt-pt/code-geass", "Code Geass", "50", 8.8100000000000005, "In the year 2010, the Holy Empire of Britannia is establishing itself as a dominant military nation, starting with the conquest of Japan. Renamed to Area 11 after its swift defeat, Japan has seen significant resistance against these tyrants in an attempt to regain independence. Lelouch Lamperouge, a Britannian student, unfortunately finds himself caught in a crossfire between the Britannian and the Area 11 rebel armed forces.He is able to escape, however, thanks to the timely appearance of a mysterious girl named C.C., who bestows upon him Geass, the 'Power of Kings.' Realizing the vast potential of his newfound 'power of absolute obedience,' Lelouch embarks upon a perilous journey as the masked vigilante known as Zero, leading a merciless onslaught against Britannia in order to get revenge once and for all." },
                    { 17, "Haruichi Furudate", "Comedy, Sports", "6 de abril 2014 até ?", "Production I.G", "Haikyuu.png", "https://www.crunchyroll.com/pt-pt/haikyu", "Haikyuu!!", "?", 8.5299999999999994, "Inspired after watching a volleyball ace nicknamed 'Little Giant' in action, small-statured Shouyou Hinata revives the volleyball club at his middle school. The newly-formed team even makes it to a tournament; however, their first match turns out to be their last when they are brutally squashed by the 'King of the Court, ' Tobio Kageyama. Hinata vows to surpass Kageyama, and so after graduating from middle school, he joins Karasuno High School's volleyball team—only to find that his sworn rival, Kageyama, is now his teammate. Thanks to his short height, Hinata struggles to find his role on the team, even with his superior jumping power.Surprisingly, Kageyama has his own problems that only Hinata can help with, and learning to work together appears to be the only way for the team to be successful.Based on Haruichi Furudate's popular shounen manga of the same name, Haikyuu!! is an exhilarating and emotional sports comedy following two determined athletes as they attempt to patch a heated rivalry in order to make their high school volleyball team the best in Japan." },
                    { 16, "Nakaba Suzuki", "Adventure Fiction", "10 de outubro, 2012 até ?", "A-1 Pictures", "seven_deadly_sins.jpg", "https://www.funimation.com/shows/the-seven-deadly-sins/?qid=None", "Seven Deadly Sins", "?", 7.1799999999999997, "In a world where injustice prevails, the Holy Knights of Britannia protect their homeland with their unparalleled magic and strength. Their most sought-after targets are 'The Seven Deadly Sins': a group of criminals once regarded as the strongest of Britannia's Holy Knights. Their supposed conspiracy to overthrow the Kingdom of Liones led to their defeat at the hands of the Holy Knights, but rumors persist that the seven infamous knights still live. Ten years later, the Holy Knights ironically stage a coup d'état themselves and capture the King of Liones, installing themselves as the new rulers of the kingdom. Elizabeth Liones, the third princess of the kingdom, sets out on a journey to find the Seven Deadly Sins and request their aid when she stumbles upon a bar owned by Meliodas, the Dragon's Sin of Wrath and the former leader of the disgraced knights.The pair sets out to find Meliodas' old comrades, but will it be hope or despair that awaits them in their travels?" },
                    { 15, "Yoshihiro Togashi", "Adventure Fiction, Martial Arts, Fantasy", "2 de outubro, 2011 até 24 de setembro, 2014", "Nippon Animation", "hunter_x_hunter.jpg", "https://beta.crunchyroll.com/pt-pt/series/GY3VKX1MR/Hunter-x-Hunter", "Hunter x Hunter", "148", 8.4100000000000001, "Hunters are specialized in a wide variety of fields, ranging from treasure hunting to cooking. They have access to otherwise unavailable funds and information that allow them to pursue their dreams and interests. However, being a hunter is a special privilege, only attained by taking a deadly exam with an extremely low success rate. Gon Freecss, a 12 - year - old boy with the hope of finding his missing father, sets out on a quest to take the Hunter Exam.Along the way, he picks up three companions who also aim to take the dangerous test: the revenge - seeking Kurapika, aspiring doctor Leorio Paladiknight, and a mischievous child the same age as Gon, Killua Zoldyck. Hunter x Hunter is a classic shounen that follows the story of four aspiring hunters as they embark on a perilous adventure, fighting for their dreams while defying the odds." },
                    { 14, "Tsugumi Ohba", "Mystery, Suspense, Psychological Suspense", "4 de outubro,2006 até 27 de junho, 2007", "Madhouse", "Death_Note.jpg", "https://www.crunchyroll.com/pt-pt/death-note-drama", "Death Note", "37", 8.6300000000000008, "A shinigami, as a god of death, can kill any person—provided they see their victim's face and write their victim's name in a notebook called a Death Note. One day, Ryuk, bored by the shinigami lifestyle and interested in seeing how a human would use a Death Note, drops one into the human realm. High school student and prodigy Light Yagami stumbles upon the Death Note and—since he deplores the state of the world—tests the deadly notebook by writing a criminal's name in it. When the criminal dies immediately following his experiment with the Death Note, Light is greatly surprised and quickly recognizes how devastating the power that has fallen into his hands could be. With this divine capability, Light decides to extinguish all criminals in order to build a new world where crime does not exist and people worship him as a god.Police, however, quickly discover that a serial killer is targeting criminals and, consequently, try to apprehend the culprit. To do this, the Japanese investigators count on the assistance of the best detective in the world: a young and eccentric man known only by the name of L." },
                    { 13, "Rui Tsukiyo", "Adventure, Harem, Drama, Magic, Ecchi, Fantasy", "13 de janeiro", "TNK", "Redo_of_Healer.jpg", "https://9anime.to/watch/redo-of-healer.8rvv", "Redo of Healer", "12", 6.3099999999999996, "When Keyaru acquired his powers as a Hero who specialized in healing all injuries regardless of severity, it seemed that he would walk the path to a great future. But what awaited him instead was great agony; he was subjected to years of seemingly endless hellish torture and abuse. Keyaru's healing skills allowed him to secretly collect the memories and abilities of those he treated, gradually making him stronger than anyone else. But by the time he reached his full potential, it was far too late—he had already lost everything.Determined to put his life back on track, Keyaru decided to unleash a powerful healing spell that rewound the entire world back to the time before he began to suffer his horrible fate.Equipped with the anguish of his past, he vows to redo everything in order to fulfill a new purpose—to exact revenge upon those who have wronged him." },
                    { 12, "Mika Nomura", "Psychological Thriller, Science Fiction", "6 de abril, 2011 até 27 de setembro,2018", "White Fox", "Steins_Gate.jpg", "https://www.crunchyroll.com/pt-pt/steinsgate", "Steins;Gate", "47", 8.8100000000000005, "The self-proclaimed mad scientist Rintarou Okabe rents out a room in a rickety old building in Akihabara, where he indulges himself in his hobby of inventing prospective 'future gadgets' with fellow lab members: Mayuri Shiina, his air-headed childhood friend, and Hashida Itaru, a perverted hacker nicknamed 'Daru.' The three pass the time by tinkering with their most promising contraption yet, a machine dubbed the 'Phone Microwave, ' which performs the strange function of morphing bananas into piles of green gel.Though miraculous in itself, the phenomenon doesn't provide anything concrete in Okabe's search for a scientific breakthrough; that is, until the lab members are spurred into action by a string of mysterious happenings before stumbling upon an unexpected success—the Phone Microwave can send emails to the past, altering the flow of history. Adapted from the critically acclaimed visual novel by 5pb.and Nitroplus, Steins; Gate takes Okabe through the depths of scientific theory and practicality.Forced across the diverging threads of past and present, Okabe must shoulder the burdens that come with holding the key to the realm of time." },
                    { 11, "Koyoharu Gotouge", "Action, Demons, Historical, Shounen, Supernatural", "6 de abril de 2019", "ufotable", "Demon_Slayer.jpg", "https://www.crunchyroll.com/pt-pt/demon-slayer-kimetsu-no-yaiba", "Demon Slayer", "?", 8.5899999999999999, "Ever since the death of his father, the burden of supporting the family has fallen upon Tanjirou Kamado's shoulders. Though living impoverished on a remote mountain, the Kamado family are able to enjoy a relatively peaceful and happy life. One day, Tanjirou decides to go down to the local village to make a little money selling charcoal. On his way back, night falls, forcing Tanjirou to take shelter in the house of a strange man, who warns him of the existence of flesh-eating demons that lurk in the woods at night.When he finally arrives back home the next day, he is met with a horrifying sight—his whole family has been slaughtered. Worse still, the sole survivor is his sister Nezuko, who has been turned into a bloodthirsty demon. Consumed by rage and hatred, Tanjirou swears to avenge his family and stay by his only remaining sibling.Alongside the mysterious group calling themselves the Demon Slayer Corps, Tanjirou will do whatever it takes to slay the demons and protect the remnants of his beloved sister's humanity." },
                    { 10, "Gege Akutami", "Adventure Fiction, Supernatural Fiction, Dark Fantasy", "3 de outubro,2020 até ?", "MAPPA", "Jujutsu_Kaisen.png", "https://beta.crunchyroll.com/pt-pt/series/GRDV0019R/JUJUTSU-KAISEN", "Jujutsu Kaisen", "?", 8.7899999999999991, "Idly indulging in baseless parDatarmal activities with the Occult Club, high schooler Yuuji Itadori spends his days at either the clubroom or the hospital, where he visits his bedridden grandfather. However, this leisurely lifestyle soon takes a turn for the strange when he unknowingly encounters a cursed item. Triggering a chain of supernatural occurrences, Yuuji finds himself suddenly thrust into the world of Curses—dreadful beings formed from human malice and negativity—after swallowing the said item, revealed to be a finger belonging to the demon Sukuna Ryoumen, the 'King of Curses'. Yuuji experiences first - hand the threat these Curses pose to society as he discovers his own newfound powers.Introduced to the Tokyo Metropolitan Jujutsu Technical High School, he begins to walk down a path from which he cannot return—the path of a Jujutsu sorcerer." },
                    { 9, "Kōhei Horikoshi", "Adventure, Fantasy, Superhero", "3 de abril, 2016 até ?", "Bones", "Boku_No_Hero.jpg", "https://beta.crunchyroll.com/pt-pt/series/G6NQ5DWZ6/My-Hero-Academia", "Boku No Hero Academia", "?", 8.0, "The appearance of 'quirks, ' newly discovered super powers, has been steadily increasing over the years, with 80 percent of humanity possessing various abilities from manipulation of elements to shapeshifting. This leaves the remainder of the world completely powerless, and Izuku Midoriya is one such individual. Since he was a child, the ambitious middle schooler has wanted nothing more than to be a hero. Izuku's unfair fate leaves him admiring heroes and taking notes on them whenever he can. But it seems that his persistence has borne some fruit: Izuku meets the number one hero and his personal idol, All Might. All Might's quirk is a unique ability that can be inherited, and he has chosen Izuku to be his successor! Enduring many months of grueling training, Izuku enrolls in UA High, a prestigious high school famous for its excellent hero training program, and this year's freshmen look especially promising. With his bizarre but talented classmates and the looming threat of a villainous organization, Izuku will soon learn what it really means to be a hero." },
                    { 8, "Hajime Isayama", "Action, Dark Fantasy, Post-Apocalyptic", "7 de abril, 2013 até ?", "Wit Studio//MAPPA ", "Attack_On_Titan.jpg", "https://www.funimation.com/Attack+On+Titan/", "Attack On Titan", "?", 8.75, "Centuries ago, mankind was slaughtered to near extinction by monstrous humDataid creatures called titans, forcing humans to hide in fear behind enormous concentric walls. What makes these giants truly terrifying is that their taste for human flesh is not born out of hunger but what appears to be out of pleasure. To ensure their survival, the remnants of humanity began living within defensive barriers, resulting in one hundred years without a single titan encounter. However, that fragile calm is soon shattered when a colossal titan manages to breach the supposedly impregnable outer wall, reigniting the fight for survival against the man-eating abominations. After witnessing a horrific personal loss at the hands of the invading creatures, Eren Yeager dedicates his life to their eradication by enlisting into the Survey Corps, an elite military unit that combats the merciless humDataids outside the protection of the walls. Based on Hajime Isayama's award-winning manga, Shingeki no Kyojin follows Eren, along with his adopted sister Mikasa Ackerman and his childhood friend Armin Arlert, as they join the brutal war against the titans and race to discover a way of defeating them before the last walls are breached." },
                    { 7, "Akira Toriyama", "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction", "5 de julho, 2015 até 25 de março, 2018", "Toei Animation", "Dragon_Ball_Super.jpg", "https://www.crunchyroll.com/pt-pt/dragon-ball-super", "Dragon Ball Super", "131", 7.4000000000000004, "Seven years after the events of Dragon Ball Z, Earth is at peace, and its people live free from any dangers lurking in the universe. However, this peace is short-lived; a sleeping evil awakens in the dark reaches of the galaxy: Beerus, the ruthless God of Destruction. Disturbed by a prophecy that he will be defeated by a 'Super Saiyan God, ' Beerus and his angelic attendant Whis start searching the universe for this mysterious being. Before long, they reach Earth where they encounter Gokuu Son, one of the planet's mightiest warriors, and his similarly powerful friends." },
                    { 6, "Akira Toriyama", "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction", "26 de abril, 1989 até 31 de janeiro, 1996", "Toei Animation", "Dragon_Ball_Z.jpg", "https://www.funimation.com/shows/dragon-ball-z/", "Dragon Ball Z", "291", 8.1500000000000004, "Five years after winning the World Martial Arts tournament, Gokuu is now living a peaceful life with his wife and son. This changes, however, with the arrival of a mysterious enemy named Raditz who presents himself as Gokuu's long-lost brother. He reveals that Gokuu is a warrior from the once powerful but now virtually extinct Saiyan race, whose homeworld was completely annihilated. When he was sent to Earth as a baby, Gokuu's sole purpose was to conquer and destroy the planet; but after suffering amnesia from a head injury, his violent and savage nature changed, and instead was raised as a kind and well-mannered boy, now fighting to protect others. With his failed attempt at forcibly recruiting Gokuu as an ally, Raditz warns Gokuu's friends of a new threat that's rapidly approaching Earth—one that could plunge Earth into an intergalactic conflict and cause the heavens themselves to shake. A war will be fought over the seven mystical dragon balls, and only the strongest will survive in Dragon Ball Z." },
                    { 5, "Eichiro Oda", "Adventure, Fantasy, Comedy", "20 outubro, 1999 até ?", "Toei Animation", "One_Piece.png", "https://beta.crunchyroll.com/pt-pt/series/GRMG8ZQZR/One-Piece", "One Piece", "?", 8.5399999999999991, "Gol D. Roger was known as the 'Pirate King, ' the strongest and most infamous being to have sailed the Grand Line. The capture and execution of Roger by the World Government brought a change throughout the world. His last words before his death revealed the existence of the greatest treasure in the world, One Piece. It was this revelation that brought about the Grand Age of Pirates, men who dreamed of finding One Piece—which promises an unlimited amount of riches and fame—and quite possibly the pinnacle of glory and the title of the Pirate King. Enter Monkey D. Luffy, a 17-year-old boy who defies your standard definition of a pirate. Rather than the popular persona of a wicked, hardened, toothless pirate ransacking villages for fun, Luffy's reason for being a pirate is one of pure wonder: the thought of an exciting adventure that leads him to intriguing people and ultimately, the promised treasure. Following in the footsteps of his childhood hero, Luffy and his crew travel across the Grand Line, experiencing crazy adventures, unveiling dark mysteries and battling strong enemies, all in order to reach the most coveted of all fortunes—One Piece." },
                    { 4, "Tite Kubo", "Adventure, ‎Supernatural", "5 de outubro, 2004 até 27 de março, 2012", "Studio Pierrot", "bleach.jpg", "https://www.crunchyroll.com/pt-pt/bleach", "Bleach", "366", 7.7999999999999998, "Ichigo Kurosaki is an ordinary high schooler—until his family is attacked by a Hollow, a corrupt spirit that seeks to devour human souls. It is then that he meets a Soul Reaper named Rukia Kuchiki, who gets injured while protecting Ichigo's family from the assailant. To save his family, Ichigo accepts Rukia's offer of taking her powers and becomes a Soul Reaper as a result. However, as Rukia is unable to regain her powers, Ichigo is given the daunting task of hunting down the Hollows that plague their town. However, he is not alone in his fight, as he is later joined by his friends—classmates Orihime Inoue, Yasutora Sado, and Uryuu Ishida—who each have their own unique abilities. As Ichigo and his comrades get used to their new duties and support each other on and off the battlefield, the young Soul Reaper soon learns that the Hollows are not the only real threat to the human world." },
                    { 3, "Masashi Kishimoto", "Adventure, Fantasy, Comedy, Martial Arts", "5 de abril até ?", "Studio Pierrot", "Boruto.jpg", "https://beta.crunchyroll.com/pt-pt/series/GR75Q020Y/BORUTO-NARUTO-NEXT-GENERATIONS", "Boruto: Naruto Next Generation", "?", 5.79, "Following the successful end of the Fourth Shinobi World War, Konohagakure has been enjoying a period of peace, prosperity, and extraordinary technological advancement. This is all due to the efforts of the Allied Shinobi Forces and the village's Seventh Hokage, Naruto Uzumaki. Now resembling a modern metropolis, Konohagakure has changed, particularly the life of a shinobi. Under the watchful eye of Naruto and his old comrades, a new generation of shinobi has stepped up to learn the ways of the ninja. Boruto Uzumaki is often the center of attention as the son of the Seventh Hokage. Despite having inherited Naruto's boisterous and stubborn demeDatar, Boruto is considered a prodigy and is able to unleash his potential with the help of supportive friends and family. Unfortunately, this has only worsened his arrogance and his desire to surpass Naruto which, along with his father's busy lifestyle, has strained their relationship. However, a sinister force brewing within the village may threaten Boruto's carefree life. New friends and familiar faces join Boruto as a new story begins in Boruto: Naruto Next Generations." },
                    { 2, "Masashi Kishimoto", "Adventure, Fantasy, Comedy, Martial Arts", "15 de fevereiro, 2007 até 23 de março, 2017", "Studio Pierrot", "Naruto_Shippuden.png", "https://beta.crunchyroll.com/pt-pt/series/GYQ4MW246/Naruto-Shippuden", "Naruto Shippuden", "500", 8.1799999999999997, "It has been two and a half years since Naruto Uzumaki left Konohagakure, the Hidden Leaf Village, for intense training following events which fueled his desire to be stronger. Now Akatsuki, the mysterious organization of elite rogue ninja, is closing in on their grand plan which may threaten the safety of the entire shinobi world. Although Naruto is older and sinister events loom on the horizon, he has changed little in personality—still rambunctious and childish—though he is now far more confident and possesses an even greater determination to protect his friends and home. Come whatever may, Naruto will carry on with the fight for what is important to him, even at the expense of his own body, in the continuation of the saga about the boy who wishes to become Hokage." },
                    { 29, "Makoto Yukimura", "Action, Adventure, Drama, Historical, Seinen", "8 de julho, 2019 até ?", "Wit Studio", "vinsaga.jpg", "https://9anime.to/watch/vinland-saga.77zy", "Vinland Saga", "24", 8.7100000000000009, "Young Thorfinn grew up listening to the stories of old sailors that had traveled the ocean and reached the place of legend, Vinland. It's said to be warm and fertile, a place where there would be no need for fighting—not at all like the frozen village in Iceland where he was born, and certainly not like his current life as a mercenary. War is his home now. Though his father once told him, 'You have no enemies, nobody does.There is nobody who it's okay to hurt,' as he grew, Thorfinn knew that nothing was further from the truth. The war between England and the Danes grows worse with each passing year.Death has become commonplace, and the viking mercenaries are loving every moment of it.Allying with either side will cause a massive swing in the balance of power, and the vikings are happy to make names for themselves and take any spoils they earn along the way.Among the chaos, Thorfinn must take his revenge and kill Askeladd, the man who murdered his father.The only paradise for the vikings, it seems, is the era of war and death that rages on." },
                    { 30, "Yuto Tsukuda", "Ecchi, School, Shounen", "4 de abril de 2015 até 26 de setembro, 2020", "J.C.Staff", "FoodWars.jpg", "https://www.crunchyroll.com/pt-pt/food-wars-shokugeki-no-soma", "Shokugeki No Souma", "73", 8.2400000000000002, "Ever since he was a child, fifteen-year-old Souma Yukihira has helped his father by working as the sous chef in the restaurant his father runs and owns. Throughout the years, Souma developed a passion for entertaining his customers with his creative, skilled, and daring culinary creations. His dream is to someday own his family's restaurant as its head chef. Yet when his father suddenly decides to close the restaurant to test his cooking abilities in restaurants around the world, he sends Souma to Tootsuki Culinary Academy, an elite cooking school where only 10 percent of the students graduate.The institution is famous for its 'Shokugeki' or 'food wars,' where students face off in intense, high - stakes cooking showdowns. As Souma and his new schoolmates struggle to survive the extreme lifestyle of Tootsuki, more and greater challenges await him, putting his years of learning under his father to the test." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimesUtilizadores_ListaDeUsersIdUsers",
                table: "AnimesUtilizadores",
                column: "ListaDeUsersIdUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_AnimeFK",
                table: "Episodios",
                column: "AnimeFK");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodiosUtilizadores_ListaDeUsersIdUsers",
                table: "EpisodiosUtilizadores",
                column: "ListaDeUsersIdUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AnimeFK",
                table: "Reviews",
                column: "AnimeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UsersFK",
                table: "Reviews",
                column: "UsersFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AnimesUtilizadores");

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
                name: "EpisodiosUtilizadores");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
