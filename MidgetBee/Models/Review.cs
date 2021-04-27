using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class Review {
        public Review() {
            // inicializar a lista de Animes do User
            ListaDeReviews = new HashSet<Review>();

        }
        /// <summary>
        /// Possui o Identificador da Review
        /// </summary>
        [Key]
        public int IdReview { get; set; }

        /// <summary>
        /// Possui o Comentário do Utilizador
        /// </summary>
        [Required]
        public string Comentario { get; set; }

        /// <summary>
        /// Possui a Rating do Anime
        /// </summary>
        [Required]
        public double Rating { get; set; }

        /// <summary>
        /// FK para a Review do User
        /// </summary>
        [ForeignKey(nameof(Users))]  // esta 'anotação' indica que o atributo 'IdUsersFK' está a executar o mesmo que o atributo 'IdUsers',
                                     // e que representa uma FK para a classe Review
        public int IdUsersFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do User
        public Users IdUsers { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do User

        /// <summary>
        /// FK para a Review do Anime
        /// </summary>
        [ForeignKey(nameof(Anime))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int idAnimeFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do Anime
        public Anime idAnime { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do Anime

        /// <summary>
        /// Lista de Links associados aos Animes
        /// </summary>
        public ICollection<Review> ListaDeReviews { get; set; }
    }
}
