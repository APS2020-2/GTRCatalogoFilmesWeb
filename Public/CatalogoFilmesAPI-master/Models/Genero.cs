using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmesAPI.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<Filme> Filmes { get; set; }
    }
}