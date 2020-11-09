using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmesAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Poster { get; set; }

        public string Descricao { get; set; }

        public string IdiomaOriginal { get; set; }

        public string DataLancamento { get; set; }

        public int Duracao { get; set; }
        
        // Genero
        public int GeneroId { get; set; }

        public Genero Genero { get; set; }

        // Diretor
        public int DiretorId { get; set; }

        public Diretor Diretor { get; set; }
    }
}