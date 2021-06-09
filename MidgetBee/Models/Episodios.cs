using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidgetBee.Models {
    public class Episodios {
        public Episodios() {
            // inicializar a lista de Users do Episodios
            ListaDeUsers = new HashSet<Utilizadores>();
        }
        /// <summary>
        /// Possui o Identificador do Episodio
        /// </summary>
        [Key]
        public int NumEpisodio { get; set; }

        /// <summary>
        /// título do episódio
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// resumo do episódio
        /// </summary>
        public string Resumo { get; set; }

        /// <summary>
        /// FK para a Review do Anime
        /// </summary>
        [ForeignKey(nameof(Anime))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int AnimeFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do Anime
        public Animes Anime { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do Anime

        /// <summary>
        /// Lista dos Animes associados ao User
        /// </summary>
        public ICollection<Utilizadores> ListaDeUsers { get; set; }
    }
}