using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MidgetBee.Models {
    public class Utilizadores {

        public Utilizadores() {
            // inicializar a lista de Reviews associados aos Utilizadores
            ListaDeReviews = new HashSet<Reviews>();
            // inicializar a lista de Animes associados aos Utilizadores
            ListaDeFavoritos = new HashSet<Favoritos>();
        }
        /// <summary>
        /// Possui o Identificador do User
        /// </summary>
        [Key]
        public int IdUsers { get; set; }

        /// <summary>
        /// Possui o Email do User
        /// </summary>

        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Ligação entre os Utilizadores e a tabela de Autenticação
        /// </summary>
        public string UserNameID { get; set; }

        /// <summary>
        /// Vai possuir o valor de true caso o utilizador já tenho postado um comentário, false se ainda não colocou um comentário
        /// </summary>
        public bool ContComment { get; set; }

        /// <summary>
        /// Lista de Reviews associados aos Animes
        /// </summary>
        public ICollection<Reviews> ListaDeReviews { get; set; }

        /// <summary>
        /// Lista de Animes associados aos Utilizadores
        /// </summary>
        public ICollection<Favoritos> ListaDeFavoritos { get; set; }
    }
}
