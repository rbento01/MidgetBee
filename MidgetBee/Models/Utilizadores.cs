using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class Utilizadores {

        public Utilizadores() {
            // inicializar a lista de Animes do User
            ListaDeAnimes = new HashSet<Animes>();
            // inicializar a lista de Episodios
            ListaDeEpisodios = new HashSet<Episodios>();
            ListaDeReviews = new HashSet<Reviews>();
        }
        /// <summary>
        /// Possui o Identificador do User
        /// </summary>
        [Key]
        public int IdUsers { get; set; }

        /// <summary>
        /// Possui o Email do User
        /// </summary>
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [EmailAddress(ErrorMessage = "o {0} introduzido não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// lista dos Animes associados ao User
        /// </summary>
        public ICollection<Animes> ListaDeAnimes { get; set; }

        /// <summary>
        /// lista dos Animes associados ao Episodio
        /// </summary>
        public ICollection<Episodios> ListaDeEpisodios { get; set; }

        /// <summary>
        /// Lista de Links associados aos Animes
        /// </summary>
        public ICollection<Reviews> ListaDeReviews { get; set; }
    }
}
