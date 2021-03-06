using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidgetBee.Models {
    /// <summary>
    /// comentários a um Anime
    /// </summary>
    public class Favoritos {


        /// <summary>
        /// Possui o Identificador da Review
        /// </summary>
        [Key]
        public int IdFavoritos { get; set; }

        /// <summary>
        /// FK para a Review do User
        /// </summary>
        [ForeignKey(nameof(Utilizador))]  // esta 'anotação' indica que o atributo 'IdUsersFK' está a executar o mesmo que o atributo 'IdUsers',
                                          // e que representa uma FK para a classe Review
        public int UsersFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do User
        public Utilizadores Utilizador { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do User

        /// <summary>
        /// FK para a Review do Anime
        /// </summary>
        [ForeignKey(nameof(Anime))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int AnimeFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do Anime
        public Animes Anime { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do Anime

    }
}
