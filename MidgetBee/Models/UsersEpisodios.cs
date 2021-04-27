using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class UsersEpisodios {

        /// <summary>
        /// PK para a tabela do relacionamento entre Users e Episodios
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
        /// FK para a Fotografia do Anime
        /// </summary>
        [ForeignKey(nameof(Episodios))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                         // e que representa uma FK para a classe Review
        public int idEpisodiosFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Fotografia do Anime
        public Episodios IdEpisodios { get; set; }   // atributo para ser usado no C#. Representa a FK para a Fotografia do Anime
    }
}
