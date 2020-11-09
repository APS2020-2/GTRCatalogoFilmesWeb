using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmesAPI.Models
{
    public class Diretor
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Bio { get; set; }

        public string DataNasc { get; set; }

        public string Imagem { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}