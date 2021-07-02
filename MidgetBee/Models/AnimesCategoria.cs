using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidgetBee.Models {
    public class AnimesCategoria {


        [Key]
        public int idAnimesCategoria { get; set; }

        /// <summary>
        /// FK para a Review do User
        /// </summary>
        [ForeignKey(nameof(Animes))]  // esta 'anotação' indica que o atributo 'IdUsersFK' está a executar o mesmo que o atributo 'IdUsers',
                                          // e que representa uma FK para a classe Review
        public int AnimesFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do User
        public Animes Animes { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do User

        /// <summary>
        /// FK para a Review do Anime
        /// </summary>
        [ForeignKey(nameof(Categorias))]  // esta 'anotação' indica que o atributo 'idAnimeFK' está a executar o mesmo que o atributo 'idAnime',
                                     // e que representa uma FK para a classe Review
        public int CategoriaFK { get; set; }   // atributo para ser usado no SGBD e no C#. Representa a FK para a Review do Anime
        public Categorias Categorias { get; set; }   // atributo para ser usado no C#. Representa a FK para a Review do Anime
    }
}
