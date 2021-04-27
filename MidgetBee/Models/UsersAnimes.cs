using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class UsersAnimes {

        /// <summary>
        /// PK para a tabela do relacionamento entre Users e Animes
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// FK para a Fotografia do Anime
        /// </summary>
        [ForeignKey(nameof(Anime))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int idAnimeFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Fotografia do Anime
        public Anime idAnime { get; set; }   // atributo para ser usado no C#. Representa a FK para a Fotografia do Anime


        /// <summary>
        /// FK para o User ligado ao Anime
        /// </summary>
        [ForeignKey(nameof(Users))]  // esta 'anotação' indica que o atributo 'idUsersFK' está a executar o mesmo que o atributo 'idUsers',
                                     // e que representa uma FK para a classe Users
        public int idUsersFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para os Users e o Anime
        public Users idUsers { get; set; }   // atributo para ser usado no C#. Representa a FK para os Users e o Anime
    }
}
