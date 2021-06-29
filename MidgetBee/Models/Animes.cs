using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MidgetBee.Models {
    /// <summary>
    /// série de diversão, efetuada com 'desenho animados'
    /// </summary>
    public class Animes {

        public Animes() {
            // inicializar a lista de Reviews associados aos Animes
            ListaDeReviews = new HashSet<Reviews>();
            // inicializar a lista de Utilizadores associados aos Animes
            ListaDeFavoritos = new HashSet<Favoritos>();
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
        public string Data { get; set; }

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
        /// Lista das Reviews associados aos Animes
        /// </summary>
        public ICollection<Reviews> ListaDeReviews { get; set; }

        /// <summary>
        /// Lista de Utilizadores ligados aos Animes
        /// </summary>
        public ICollection<Favoritos> ListaDeFavoritos { get; set; }
    }
}
