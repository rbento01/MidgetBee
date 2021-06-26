using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MidgetBee.Models {
    public class Utilizadores {

        public Utilizadores() {
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
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Ligação entre os Utilizadores e a tabela de Autenticação
        /// </summary>
        public string UserNameID { get; set; }

        /// <summary>
        /// Lista de Links associados aos Animes
        /// </summary>
        public ICollection<Reviews> ListaDeReviews { get; set; }
    }
}
