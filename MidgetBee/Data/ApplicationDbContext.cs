﻿using MidgetBee.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Anime>().HasData(
                new Anime { IdAnime = 1, Nome = "Naruto", QuantEpisodios = "220", Rating = 7.92, Sinopse = "Moments prior to Naruto Uzumaki's birth, a huge demon known as the Kyuubi, the Nine-Tailed Fox, attacked Konohagakure, the Hidden Leaf Village, and wreaked havoc. In order to put an end to the Kyuubi's rampage, the leader of the village, the Fourth Hokage, sacrificed his life and sealed the monstrous beast inside the newborn Naruto. Now, Naruto is a hyperactive and knuckle-headed ninja still living in Konohagakure. Shunned because of the Kyuubi inside him, Naruto struggles to find his place in the village, while his burning desire to become the Hokage of Konohagakure leads him not only to some great new friends, but also some deadly foes.", Autor = "Masashi Kishimoto", Estudio = "Studio Pierrot", Data = "3 de outubro, 2002 até 8 de fevereiro, 2007", Links = "https://beta.crunchyroll.com/pt-pt/series/GY9PJ5KWR/Naruto", Fotografia = "Naruto.jpg", Categoria = "Adventure, Fantasy, Comedy, Martial Arts" },

                new Anime { IdAnime = 2, Nome = "Naruto Shippuden", QuantEpisodios = "500", Rating = 8.18, Sinopse = "It has been two and a half years since Naruto Uzumaki left Konohagakure, the Hidden Leaf Village, for intense training following events which fueled his desire to be stronger. Now Akatsuki, the mysterious organization of elite rogue ninja, is closing in on their grand plan which may threaten the safety of the entire shinobi world. Although Naruto is older and sinister events loom on the horizon, he has changed little in personality—still rambunctious and childish—though he is now far more confident and possesses an even greater determination to protect his friends and home. Come whatever may, Naruto will carry on with the fight for what is important to him, even at the expense of his own body, in the continuation of the saga about the boy who wishes to become Hokage.", Estudio = "Studio Pierrot", Data = "15 de fevereiro, 2007 até 23 de março, 2017", Links = "https://beta.crunchyroll.com/pt-pt/series/GYQ4MW246/Naruto-Shippuden", Fotografia = "Naruto_Shippuden.png", Categoria = "Adventure, Fantasy, Comedy, Martial Arts" },

                new Anime { IdAnime = 3, Nome = "Boruto: Naruto Next Generation", QuantEpisodios = "?", Rating = 5.79, Sinopse = "Following the successful end of the Fourth Shinobi World War, Konohagakure has been enjoying a period of peace, prosperity, and extraordinary technological advancement. This is all due to the efforts of the Allied Shinobi Forces and the village's Seventh Hokage, Naruto Uzumaki. Now resembling a modern metropolis, Konohagakure has changed, particularly the life of a shinobi. Under the watchful eye of Naruto and his old comrades, a new generation of shinobi has stepped up to learn the ways of the ninja. Boruto Uzumaki is often the center of attention as the son of the Seventh Hokage. Despite having inherited Naruto's boisterous and stubborn demeDatar, Boruto is considered a prodigy and is able to unleash his potential with the help of supportive friends and family. Unfortunately, this has only worsened his arrogance and his desire to surpass Naruto which, along with his father's busy lifestyle, has strained their relationship. However, a sinister force brewing within the village may threaten Boruto's carefree life. New friends and familiar faces join Boruto as a new story begins in Boruto: Naruto Next Generations.", Estudio = "Studio Pierrot", Data = "5 de abril até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GR75Q020Y/BORUTO-NARUTO-NEXT-GENERATIONS", Fotografia = "Boruto.jpg", Categoria = "Adventure, Fantasy, Comedy, Martial Arts" },

                new Anime { IdAnime = 4, Nome = "Bleach", QuantEpisodios = "366", Rating = 7.80, Sinopse = "Ichigo Kurosaki is an ordinary high schooler—until his family is attacked by a Hollow, a corrupt spirit that seeks to devour human souls. It is then that he meets a Soul Reaper named Rukia Kuchiki, who gets injured while protecting Ichigo's family from the assailant. To save his family, Ichigo accepts Rukia's offer of taking her powers and becomes a Soul Reaper as a result. However, as Rukia is unable to regain her powers, Ichigo is given the daunting task of hunting down the Hollows that plague their town. However, he is not alone in his fight, as he is later joined by his friends—classmates Orihime Inoue, Yasutora Sado, and Uryuu Ishida—who each have their own unique abilities. As Ichigo and his comrades get used to their new duties and support each other on and off the battlefield, the young Soul Reaper soon learns that the Hollows are not the only real threat to the human world.", Estudio = "Studio Pierrot", Data = "5 de outubro, 2004 até 27 de março, 2012", Links = "https://www.funimation.com/bleach/", Fotografia = "Bleach.jpg", Categoria = "Adventure, ‎Supernatural" },

                new Anime { IdAnime = 5, Nome = "One Piece", QuantEpisodios = "?", Rating = 8.54, Sinopse = "Gol D. Roger was known as the 'Pirate King, ' the strongest and most infamous being to have sailed the Grand Line. The capture and execution of Roger by the World Government brought a change throughout the world. His last words before his death revealed the existence of the greatest treasure in the world, One Piece. It was this revelation that brought about the Grand Age of Pirates, men who dreamed of finding One Piece—which promises an unlimited amount of riches and fame—and quite possibly the pinnacle of glory and the title of the Pirate King. Enter Monkey D. Luffy, a 17-year-old boy who defies your standard definition of a pirate. Rather than the popular persona of a wicked, hardened, toothless pirate ransacking villages for fun, Luffy's reason for being a pirate is one of pure wonder: the thought of an exciting adventure that leads him to intriguing people and ultimately, the promised treasure. Following in the footsteps of his childhood hero, Luffy and his crew travel across the Grand Line, experiencing crazy adventures, unveiling dark mysteries and battling strong enemies, all in order to reach the most coveted of all fortunes—One Piece.", Estudio = "Toei Animation", Data = "20 outubro, 1999 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GRMG8ZQZR/One-Piece", Fotografia = "One_Piece.png", Categoria = "Adventure, Fantasy, Comedy" },

                new Anime { IdAnime = 6, Nome = "Dragon Ball Z", QuantEpisodios = "291", Rating = 8.15, Sinopse = "Five years after winning the World Martial Arts tournament, Gokuu is now living a peaceful life with his wife and son. This changes, however, with the arrival of a mysterious enemy named Raditz who presents himself as Gokuu's long-lost brother. He reveals that Gokuu is a warrior from the once powerful but now virtually extinct Saiyan race, whose homeworld was completely annihilated. When he was sent to Earth as a baby, Gokuu's sole purpose was to conquer and destroy the planet; but after suffering amnesia from a head injury, his violent and savage nature changed, and instead was raised as a kind and well-mannered boy, now fighting to protect others. With his failed attempt at forcibly recruiting Gokuu as an ally, Raditz warns Gokuu's friends of a new threat that's rapidly approaching Earth—one that could plunge Earth into an intergalactic conflict and cause the heavens themselves to shake. A war will be fought over the seven mystical dragon balls, and only the strongest will survive in Dragon Ball Z.", Estudio = "Toei Animation", Data = "26 de abril, 1989 até 31 de janeiro, 1996", Links = "https://www.funimation.com/Dragon+Ball+Z/", Fotografia = "Dragon_Ball_Z", Categoria = "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction" },

                new Anime { IdAnime = 7, Nome = "Dragon Ball Super", QuantEpisodios = "131", Rating = 7.40, Sinopse = "Seven years after the events of Dragon Ball Z, Earth is at peace, and its people live free from any dangers lurking in the universe. However, this peace is short-lived; a sleeping evil awakens in the dark reaches of the galaxy: Beerus, the ruthless God of Destruction. Disturbed by a prophecy that he will be defeated by a 'Super Saiyan God, ' Beerus and his angelic attendant Whis start searching the universe for this mysterious being. Before long, they reach Earth where they encounter Gokuu Son, one of the planet's mightiest warriors, and his similarly powerful friends.", Estudio = "Toei Animation", Data = "5 de julho, 2015 até 25 de março, 2018", Links = "https://beta.crunchyroll.com/pt-pt/series/GR19V7816/Dragon-Ball-Super", Fotografia = "Dragon_Ball_Super.jpg", Categoria = "Action, Comedy,Drama,Adventure,Martial Arts,Adventure Fiction" },

                new Anime { IdAnime = 8, Nome = "Attack On Titan", QuantEpisodios = "?", Rating = 8.75, Sinopse = "Centuries ago, mankind was slaughtered to near extinction by monstrous humDataid creatures called titans, forcing humans to hide in fear behind enormous concentric walls. What makes these giants truly terrifying is that their taste for human flesh is not born out of hunger but what appears to be out of pleasure. To ensure their survival, the remnants of humanity began living within defensive barriers, resulting in one hundred years without a single titan encounter. However, that fragile calm is soon shattered when a colossal titan manages to breach the supposedly impregnable outer wall, reigniting the fight for survival against the man-eating abominations. After witnessing a horrific personal loss at the hands of the invading creatures, Eren Yeager dedicates his life to their eradication by enlisting into the Survey Corps, an elite military unit that combats the merciless humDataids outside the protection of the walls. Based on Hajime Isayama's award-winning manga, Shingeki no Kyojin follows Eren, along with his adopted sister Mikasa Ackerman and his childhood friend Armin Arlert, as they join the brutal war against the titans and race to discover a way of defeating them before the last walls are breached.", Estudio = "Wit Studio//MAPPA ", Data = "7 de abril, 2013 até ?", Links = "https://www.funimation.com/Attack+On+Titan/", Fotografia = "Attack_On_Titan.jpg", Categoria = "Action, Dark Fantasy, Post-Apocalyptic" },

                new Anime { IdAnime = 9, Nome = "Boku No Hero Academia", QuantEpisodios = "?", Rating = 8.0, Sinopse = "The appearance of 'quirks, ' newly discovered super powers, has been steadily increasing over the years, with 80 percent of humanity possessing various abilities from manipulation of elements to shapeshifting. This leaves the remainder of the world completely powerless, and Izuku Midoriya is one such individual. Since he was a child, the ambitious middle schooler has wanted nothing more than to be a hero. Izuku's unfair fate leaves him admiring heroes and taking notes on them whenever he can. But it seems that his persistence has borne some fruit: Izuku meets the number one hero and his personal idol, All Might. All Might's quirk is a unique ability that can be inherited, and he has chosen Izuku to be his successor! Enduring many months of grueling training, Izuku enrolls in UA High, a prestigious high school famous for its excellent hero training program, and this year's freshmen look especially promising. With his bizarre but talented classmates and the looming threat of a villainous organization, Izuku will soon learn what it really means to be a hero.", Estudio = "Bones", Data = "3 de abril, 2016 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/G6NQ5DWZ6/My-Hero-Academia", Fotografia = "Boku_No_Hero.jpg", Categoria = "Adventure, Fantasy, Superhero" },

                new Anime { IdAnime = 10, Nome = "Jujutsu Kaisen", QuantEpisodios = "?", Rating = 8.79, Sinopse = "Idly indulging in baseless parDatarmal activities with the Occult Club, high schooler Yuuji Itadori spends his days at either the clubroom or the hospital, where he visits his bedridden grandfather. However, this leisurely lifestyle soon takes a turn for the strange when he unknowingly encounters a cursed item. Triggering a chain of supernatural occurrences, Yuuji finds himself suddenly thrust into the world of Curses—dreadful beings formed from human malice and negativity—after swallowing the said item, revealed to be a finger belonging to the demon Sukuna Ryoumen, the 'King of Curses'. Yuuji experiences first - hand the threat these Curses pose to society as he discovers his own newfound powers.Introduced to the Tokyo Metropolitan Jujutsu Technical High School, he begins to walk down a path from which he cannot return—the path of a Jujutsu sorcerer.", Estudio = "MAPPA", Data = "3 de outubro,2020 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GRDV0019R/JUJUTSU-KAISEN", Fotografia = "Jujutsu_Kaisen.png", Categoria = "Adventure Fiction, Supernatural Fiction, Dark Fantasy" },

                new Anime { IdAnime = 11, Nome = "Demon Slayer", QuantEpisodios = "?", Rating = 8.60, Sinopse = "Ever since the death of his father, the burden of supporting the family has fallen upon Tanjirou Kamado's shoulders. Though living impoverished on a remote mountain, the Kamado family are able to enjoy a relatively peaceful and happy life. One day, Tanjirou decides to go down to the local village to make a little money selling charcoal. On his way back, night falls, forcing Tanjirou to take shelter in the house of a strange man, who warns him of the existence of flesh-eating demons that lurk in the woods at night.When he finally arrives back home the next day, he is met with a horrifying sight—his whole family has been slaughtered. Worse still, the sole survivor is his sister Nezuko, who has been turned into a bloodthirsty demon. Consumed by rage and hatred, Tanjirou swears to avenge his family and stay by his only remaining sibling.Alongside the mysterious group calling themselves the Demon Slayer Corps, Tanjirou will do whatever it takes to slay the demons and protect the remnants of his beloved sister's humanity.", Estudio = "ufotable", Data = "6 de abril, 2019 até ?", Links = "", Fotografia = "", Categoria = "" },

                new Anime { IdAnime = 12, Nome = "Steins;Gate", QuantEpisodios = "47", Rating = 8.81, Sinopse = "The self-proclaimed mad scientist Rintarou Okabe rents out a room in a rickety old building in Akihabara, where he indulges himself in his hobby of inventing prospective 'future gadgets' with fellow lab members: Mayuri Shiina, his air-headed childhood friend, and Hashida Itaru, a perverted hacker nicknamed 'Daru.' The three pass the time by tinkering with their most promising contraption yet, a machine dubbed the 'Phone Microwave, ' which performs the strange function of morphing bananas into piles of green gel.Though miraculous in itself, the phenomenon doesn't provide anything concrete in Okabe's search for a scientific breakthrough; that is, until the lab members are spurred into action by a string of mysterious happenings before stumbling upon an unexpected success—the Phone Microwave can send emails to the past, altering the flow of history. Adapted from the critically acclaimed visual novel by 5pb.and Nitroplus, Steins; Gate takes Okabe through the depths of scientific theory and practicality.Forced across the diverging threads of past and present, Okabe must shoulder the burdens that come with holding the key to the realm of time.", Estudio = "White Fox", Data = "6 de abril, 2011 até 27 de setembro,2018", Links = "ARRANJAR LINK FUNIMATION", Fotografia = "Steins_Gate.jpg", Categoria = "Psychological Thriller, Science Fiction" },

                new Anime { IdAnime = 13, Nome = "Redo of Healer", QuantEpisodios = "12", Rating = 6.31, Sinopse = "When Keyaru acquired his powers as a Hero who specialized in healing all injuries regardless of severity, it seemed that he would walk the path to a great future. But what awaited him instead was great agony; he was subjected to years of seemingly endless hellish torture and abuse. Keyaru's healing skills allowed him to secretly collect the memories and abilities of those he treated, gradually making him stronger than anyone else. But by the time he reached his full potential, it was far too late—he had already lost everything.Determined to put his life back on track, Keyaru decided to unleash a powerful healing spell that rewound the entire world back to the time before he began to suffer his horrible fate.Equipped with the anguish of his past, he vows to redo everything in order to fulfill a new purpose—to exact revenge upon those who have wronged him.", Estudio = "TNK", Data = "13 de janeiro", Links = "NÃO DISPONIVEL", Fotografia = "", Categoria = "Redo_of_Healer.jpg" },

                new Anime { IdAnime = 14, Nome = "Death Note", QuantEpisodios = "37", Rating = 8.63, Sinopse = "A shinigami, as a god of death, can kill any person—provided they see their victim's face and write their victim's name in a notebook called a Death Note. One day, Ryuk, bored by the shinigami lifestyle and interested in seeing how a human would use a Death Note, drops one into the human realm. High school student and prodigy Light Yagami stumbles upon the Death Note and—since he deplores the state of the world—tests the deadly notebook by writing a criminal's name in it. When the criminal dies immediately following his experiment with the Death Note, Light is greatly surprised and quickly recognizes how devastating the power that has fallen into his hands could be. With this divine capability, Light decides to extinguish all criminals in order to build a new world where crime does not exist and people worship him as a god.Police, however, quickly discover that a serial killer is targeting criminals and, consequently, try to apprehend the culprit. To do this, the Japanese investigators count on the assistance of the best detective in the world: a young and eccentric man known only by the name of L.", Estudio = "Madhouse", Data = "4 de outubro,2006 até 27 de junho, 2007", Links = "ARRANJAR LINK", Fotografia = "Death_Note.jpg", Categoria = "Mystery, Suspense, Psychological Suspense" },

                new Anime { IdAnime = 15, Nome = "Hunter x Hunter", QuantEpisodios = "148", Rating = 8.41, Sinopse = "Hunters are specialized in a wide variety of fields, ranging from treasure hunting to cooking. They have access to otherwise unavailable funds and information that allow them to pursue their dreams and interests. However, being a hunter is a special privilege, only attained by taking a deadly exam with an extremely low success rate. Gon Freecss, a 12 - year - old boy with the hope of finding his missing father, sets out on a quest to take the Hunter Exam.Along the way, he picks up three companions who also aim to take the dangerous test: the revenge - seeking Kurapika, aspiring doctor Leorio Paladiknight, and a mischievous child the same age as Gon, Killua Zoldyck. Hunter x Hunter is a classic shounen that follows the story of four aspiring hunters as they embark on a perilous adventure, fighting for their dreams while defying the odds.", Estudio = "Nippon Animation", Data = "2 de outubro, 2011 até 24 de setembro, 2014", Links = "https://beta.crunchyroll.com/pt-pt/series/GY3VKX1MR/Hunter-x-Hunter", Fotografia = "Hunter_x_Hunter.jpg", Categoria = "Adventure Fiction, Martial Arts, Fantasy" },

                new Anime { IdAnime = 16, Nome = "Seven Deadly Sins", QuantEpisodios = "?", Rating = 7.18, Sinopse = "In a world where injustice prevails, the Holy Knights of Britannia protect their homeland with their unparalleled magic and strength. Their most sought-after targets are 'The Seven Deadly Sins': a group of criminals once regarded as the strongest of Britannia's Holy Knights. Their supposed conspiracy to overthrow the Kingdom of Liones led to their defeat at the hands of the Holy Knights, but rumors persist that the seven infamous knights still live. Ten years later, the Holy Knights ironically stage a coup d'état themselves and capture the King of Liones, installing themselves as the new rulers of the kingdom. Elizabeth Liones, the third princess of the kingdom, sets out on a journey to find the Seven Deadly Sins and request their aid when she stumbles upon a bar owned by Meliodas, the Dragon's Sin of Wrath and the former leader of the disgraced knights.The pair sets out to find Meliodas' old comrades, but will it be hope or despair that awaits them in their travels?", Estudio = "", Data = "10 de outubro, 2012 até ?", Links = "AINDA NÃO DISPONIVEL", Fotografia = "Seven_Deadly_Sins.jpg", Categoria = "Adventure Fiction" },

                new Anime { IdAnime = 17, Nome = "Haikyuu!!", QuantEpisodios = "?", Rating = 8.53, Sinopse = "Inspired after watching a volleyball ace nicknamed 'Little Giant' in action, small-statured Shouyou Hinata revives the volleyball club at his middle school. The newly-formed team even makes it to a tournament; however, their first match turns out to be their last when they are brutally squashed by the 'King of the Court, ' Tobio Kageyama. Hinata vows to surpass Kageyama, and so after graduating from middle school, he joins Karasuno High School's volleyball team—only to find that his sworn rival, Kageyama, is now his teammate. Thanks to his short height, Hinata struggles to find his role on the team, even with his superior jumping power.Surprisingly, Kageyama has his own problems that only Hinata can help with, and learning to work together appears to be the only way for the team to be successful.Based on Haruichi Furudate's popular shounen manga of the same name, Haikyuu!! is an exhilarating and emotional sports comedy following two determined athletes as they attempt to patch a heated rivalry in order to make their high school volleyball team the best in Japan.", Estudio = "Production I.G", Data = "6 de abril 2014 até ?", Links = "NÃO DISPONIVEL", Fotografia = "Haikyuu.png", Categoria = "Comedy, Sports" },


               new Anime { IdAnime = 18, Nome = "Code Geass", QuantEpisodios = "50", Rating = 8.81, Sinopse = "In the year 2010, the Holy Empire of Britannia is establishing itself as a dominant military nation, starting with the conquest of Japan. Renamed to Area 11 after its swift defeat, Japan has seen significant resistance against these tyrants in an attempt to regain independence. Lelouch Lamperouge, a Britannian student, unfortunately finds himself caught in a crossfire between the Britannian and the Area 11 rebel armed forces.He is able to escape, however, thanks to the timely appearance of a mysterious girl named C.C., who bestows upon him Geass, the 'Power of Kings.' Realizing the vast potential of his newfound 'power of absolute obedience,' Lelouch embarks upon a perilous journey as the masked vigilante known as Zero, leading a merciless onslaught against Britannia in order to get revenge once and for all.", Estudio = "Sunrise", Data = "6 de outubro, 2006 até 28 de setembro, 2008", Links = "NÃO DISPONIVEL", Fotografia = "Code_Geass.jpg", Categoria = "Action, Mecha, Adventure, Suspense, Military Fiction" },

                new Anime { IdAnime = 19, Nome = "Fairy Tail", QuantEpisodios = "328", Rating = 7.62, Sinopse = "In the mystical land of Fiore, magic exists as an essential part of everyday life. Countless magic guilds lie at the core of all magical activity, and serve as venues for like-minded mages to band together and take on job requests. Among them, Fairy Tail stands out from the rest as a place of strength, spirit, and family. Lucy Heartfilia is a young mage searching for celestial gate keys, and her dream is to become a full - fledged wizard by joining this famous guild.In her search, she runs into Natsu Dragneel and his partner Happy, who are on a quest to find Natsu's foster father, the dragon Igneel. Upon being tricked by a man, Lucy falls under an abduction attempt, only to be saved by Natsu.To her shock, he reveals that he is a member of Fairy Tail and invites her to join them.There, Lucy meets the guild's strange members, such as the ice wizard Gray Fullbuster and magic swordswoman Erza Scarlet. Together as a family, they battle the forces of evil, help those in need, and gain new friends, all the while enjoying the never-ending adventure that is Fairy Tail.", Estudio = "Satelight//A-1 Pictures", Data = "12 de outubro, 2009 até 29 de setembro, 2019", Links = "https://beta.crunchyroll.com/pt-pt/series/G6DQDD3WR/Fairy-Tail", Fotografia = "Fairy_Tail.jpg", Categoria = "Fantasy, Adventure Fiction" },

                new Anime { IdAnime = 20, Nome = "Black Clover", QuantEpisodios = "?", Rating = 7.97, Sinopse = "Asta and Yuno were abandoned at the same church on the same day. Raised together as children, they came to know of the 'Wizard King'—a title given to the strongest mage in the kingdom—and promised that they would compete against each other for the position of the next Wizard King. However, as they grew up, the stark difference between them became evident. While Yuno is able to wield magic with amazing power and control, Asta cannot use magic at all and desperately tries to awaken his powers by training physically.When they reach the age of 15, Yuno is bestowed a spectacular Grimoire with a four - leaf clover, while Asta receives nothing. However, soon after, Yuno is attacked by a person named Lebuty, whose main purpose is to obtain Yuno's Grimoire. Asta tries to fight Lebuty, but he is outmatched. Though without hope and on the brink of defeat, he finds the strength to continue when he hears Yuno's voice. Unleashing his inner emotions in a rage, Asta receives a five - leaf clover Grimoire, a 'Black Clover' giving him enough power to defeat Lebuty.A few days later, the two friends head out into the world, both seeking the same goal—to become the Wizard King!", Estudio = "Studio Pierrot", Data = "3 de outubro,2017 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GRE50KV36/Black-Clover", Fotografia = "Black_Clover", Categoria = "Adventure, Fantasy, Comedy, Action" },

                new Anime { IdAnime = 21, Nome = "Dr. Stone", QuantEpisodios = "?", Rating = 8.27, Sinopse = "After five years of harboring unspoken feelings, high-schooler Taiju Ooki is finally ready to confess his love to Yuzuriha Ogawa. Just when Taiju begins his confession however, a blinding green light strikes the Earth and petrifies mankind around the world—turning every single human into stone. Several millennia later, Taiju awakens to find the modern world completely nonexistent, as nature has flourished in the years humanity stood still.Among a stone world of statues, Taiju encounters one other living human: his science - loving friend Senkuu, who has been active for a few months.Taiju learns that Senkuu has developed a grand scheme—to launch the complete revival of civilization with science.Taiju's brawn and Senkuu's brains combine to forge a formidable partnership, and they soon uncover a method to revive those petrified. However, Senkuu's master plan is threatened when his ideologies are challenged by those who awaken. All the while, the reason for mankind's petrification remains unknown.", Estudio = "TMS Entertainment", Data = "5 de julho, 2019 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GYEXQKJG6/Dr-STONE", Fotografia = "Dr_Stone.jpg", Categoria = "Adventure, Post-Apocalyptic, Science Fiction, Comedy" },

                new Anime { IdAnime = 22, Nome = "Pokémon", QuantEpisodios = "276", Rating = 7.34, Sinopse = "Pokemon are peculiar creatures with a vast array of different abilities and appearances; many people, known as Pokemon trainers, capture and train them, often with the intent of battling others. Young Satoshi has not only dreamed of becoming a Pokemon trainer but also a 'Pokemon Master, ' and on the arrival of his 10th birthday, he finally has a chance to make that dream a reality. Unfortunately for him, all three Pokemon available to beginning trainers have already been claimed and only Pikachu, a rebellious Electric type Pokemon, remains. However, this chance encounter would mark the start of a lifelong friendship and an epic adventure! Setting off on a journey to become the very best, Satoshi and Pikachu travel across beautiful, sprawling regions with their friends Kasumi, a Water type trainer, and Takeshi, a Rock type trainer.But danger lurks around every corner.The infamous Team Rocket is always nearby, seeking to steal powerful Pokemon through nefarious schemes.It'll be up to Satoshi and his friends to thwart their efforts as he also strives to earn the eight Pokemon Gym Badges he'll need to challenge the Pokemon League, and eventually claim the title of Pokemon Master.", Estudio = "OLM", Data = "1 de abril 1997 até 14 de novembro de 2002", Links = "AINDA NÃO DISPONIVEL", Fotografia = "Pokemon.jpg", Categoria = "Adventure, Comedy, Drama, Action, Science Fiction, Suspense" },

                new Anime { IdAnime = 23, Nome = "The Quintessential Quintuplets", QuantEpisodios = "?", Rating = 7.9, Sinopse = "Through their tutor Fuutarou Uesugi's diligent guidance, the NakData quintuplets' academic performance shows signs of improvement, even if their path to graduation is still rocky. However, as they continue to cause various situations that delay any actual tutoring, Fuutarou becomes increasingly involved with their personal lives, further complicating their relationship with each other. On Datather note, Fuutarou slowly begins to realize the existence of a possible connection between him and the past he believes to have shared with one of the five girls.With everyone's feelings beginning to develop and overlap, will they be able to keep their bond strictly to that of a teacher and his students—or will it mature into something else entirely?", Estudio = "Bibury Animation Studios", Data = "8 de janeiro, 2021 até ?", Links = "https://beta.crunchyroll.com/pt-pt/series/GY4PD7Z06/The-Quintessential-Quintuplets", Fotografia = "Quint_Quint.jpg", Categoria = "Harem, Romantic Comedy" },

                new Anime { IdAnime = 24, Nome = "Darling In The FranXX", QuantEpisodios = "24", Rating = 7.31, Sinopse = "In the distant future, humanity has been driven to near-extinction by giant beasts known as Klaxosaurs, forcing the surviving humans to take refuge in massive fortress cities called Plantations. Children raised here are trained to pilot giant mechas known as FranXX—the only weapons known to be effective against the Klaxosaurs—in boy-girl pairs. Bred for the sole purpose of piloting these machines, these children know nothing of the outside world and are only able to prove their existence by defending their race. Hiro, an aspiring FranXX pilot, has lost his motivation and self - confidence after failing an aptitude test.Skipping out on his class' graduation ceremony, Hiro retreats to a forest lake, where he encounters a mysterious girl with two horns growing out of her head. She introduces herself by her codename Zero Two, which is known to belong to an infamous FranXX pilot known as the 'Partner Killer.' Before Hiro can digest the encounter, the Plantation is rocked by a sudden Klaxosaur attack. Zero Two engages the creature in her FranXX, but it is heavily damaged in the skirmish and crashes near Hiro. Finding her partner dead, Zero Two invites Hiro to pilot the mecha with her, and the duo easily defeats the Klaxosaur in the ensuing fight. With a new partner by his side, Hiro has been given a chance at redemption for his past failures, but at what cost?", Estudio = "A-1 Pictures//Trigger//CloverWorks", Data = "13 de janeiro, 2018 até 7 de julho, 2018", Links = "https://beta.crunchyroll.com/pt-pt/series/GY8VEQ95Y/DARLING-in-the-FRANXX", Fotografia = "Darling_Franxx.jpg", Categoria = "Romance, Science Fiction, Mecha" },

                new Anime { IdAnime = 25, Nome = "Tokyo Ghoul", QuantEpisodios = "48", Rating = 7.1, Sinopse = "Tokyo has become a cruel and merciless city—a place where vicious creatures called 'ghouls' exist alongside humans. The citizens of this once great metropolis live in constant fear of these bloodthirsty savages and their thirst for human flesh. However, the greatest threat these ghouls pose is their dangerous ability to masquerade as humans and blend in with society. Based on the best - selling supernatural horror manga by Sui Ishida, Tokyo Ghoul follows Ken Kaneki, a shy, bookish college student, who is instantly drawn to Rize Kamishiro, an avid reader like himself.However, Rize is not exactly who she seems, and this unfortunate meeting pushes Kaneki into the dark depths of the ghouls' inhuman world. In a twist of fate, Kaneki is saved by the enigmatic waitress Touka Kirishima, and thus begins his new, secret life as a half-ghoul/half-human who must find a way to integrate into both societies.", Estudio = "Studio Pierrot", Data = "4 de julho, 2014 até 19 de junho, 2018", Links = "Ainda não disponivel", Fotografia = "Tokyo_Ghoul.jpg", Categoria = "Dark Fantasy, Suspense, Horror, Thriller, Gore, Supernatural, Action" }
            );

            modelBuilder.Entity<Episodios>().HasData(
                new Episodios { }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users { }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { }
            );

            modelBuilder.Entity<UsersAnimes>().HasData(
                new UsersAnimes { }
            );

            modelBuilder.Entity<UsersEpisodios>().HasData(
                new UsersEpisodios { }
            );
        }
        //Representar as Tabelas da BD
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Episodios> Episodios { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<UsersAnimes> UsersAnimes { get; set; }
        public DbSet<UsersEpisodios> UsersEpisodios { get; set; }


    }
}
