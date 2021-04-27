using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class Episodios {
        public Episodios() {
            // inicializar a lista de Users do Episodios
            ListaDeUsers = new HashSet<UsersEpisodios>();
        }
        /// <summary>
        /// Possui o Identificador do Episodio
        /// </summary>
        [Key]
        public int NumEpisodio { get; set; }

        /// <summary>
        /// FK para a Review do Anime
        /// </summary>
        [ForeignKey(nameof(Anime))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int idAnimeFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do Anime
        public Anime idAnime { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do Anime

        /// <summary>
        /// Lista dos Animes associados ao User
        /// </summary>
        public ICollection<UsersEpisodios> ListaDeUsers { get; set; }
    }
}
