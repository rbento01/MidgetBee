using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidgetBee.Models {
    /// <summary>
    /// comentários a um Anime
    /// </summary>
    public class Categorias {

        public Categorias() {
            ListaDeAnimes = new HashSet<Animes>();
        }

        /// <summary>
        /// Possui o Identificador da Review
        /// </summary>
        [Key]
        public int IdCategoria { get; set; }

        /// <summary>
        /// Vai possuir o nome do categoria
        /// </summary>
        public string nomeCategoria { get; set; }

        /// <summary>
        /// Vai ter a ligação entre animes e categorias
        /// </summary>
        public ICollection<Animes> ListaDeAnimes { get; set; }
    }
}
