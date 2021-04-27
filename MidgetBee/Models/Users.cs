using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class Users {

        public Users() {
            // inicializar a lista de Animes do User
            ListaDeAnimes = new HashSet<UsersAnimes>();
            // inicializar a lista de Episodios
            ListaDeEpisodios = new HashSet<UsersEpisodios>();
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
        [RegularExpression("[a-z][0-9]@[a-z].[a-z]",
                           ErrorMessage = "Por favor, insira um email correto.")]
        public string Email { get; set; }

        /// <summary>
        /// Possui a Password do User
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// lista dos Animes associados ao User
        /// </summary>
        public ICollection<UsersAnimes> ListaDeAnimes { get; set; }

        /// <summary>
        /// lista dos Animes associados ao Episodio
        /// </summary>
        public ICollection<UsersEpisodios> ListaDeEpisodios { get; set; }
    }
}
