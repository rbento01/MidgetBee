using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class Anime {

        public Anime() {
            // inicializar a lista de Animes
            ListaDeAnimes = new HashSet<Anime>();
            // inicializar a lista de Users dos Animes
            ListaDeUsers = new HashSet<UsersAnimes>();
        }

        /// <summary>
        /// Identificador de cada Anime
        /// </summary>
        [Key]
        public int IdAnime { get; set; }

        /// <summary>
        /// Possui o Nome do anime
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Possui a Quantidade de Episodios
        /// </summary>
        public string QuantEpisodios { get; set; }

        /// <summary>
        /// Possui o Rating do Anime
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Possui a Sinopse do Anime
        /// </summary>
        public string Sinopse { get; set; }

        /// <summary>
        /// Possui o Nome do Autor
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Possui o Nome do Estudio
        /// </summary>
        public string Estudio { get; set; }

        /// <summary>
        /// Possui o Valor do Ano
        /// </summary>
        public string Ano { get; set; }

        /// <summary>
        /// Possui o Link do Ano
        /// </summary>
        public string Links { get; set; }

        /// <summary>
        /// Possui o caminho da foto em formato string
        /// </summary>
        public string Fotografia { get; set; }

        /// <summary>
        /// Possui a Categoria do Anime
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Lista dos Animes
        /// </summary>
        public ICollection<Anime> ListaDeAnimes { get; set; }

        /// <summary>
        /// Lista de Users associados aos Animes
        /// </summary>
        public ICollection<UsersAnimes> ListaDeUsers { get; set; }
    }
}
