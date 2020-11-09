using System.Threading.Tasks;
using CatalogoFilmesAPI.Models;

namespace CatalogoFilmesAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //GENERO
        Task<Genero[]> GetAllGenerosAsync();

        Task<Genero> GetGeneroAsyncById(int GeneroId);

        //FILME
        Task<Filme[]> GetAllFilmesAsync();

        Task<Filme> GetFilmeAsyncById(int FilmeId);

        //DIRETOR
        Task<Diretor[]> GetAllDiretoresAsync();

        Task<Diretor> GetDiretorAsyncById(int DiretorId);

        //OUTROS
        Task<Filme[]> GetFilmesAsyncByGeneroId(int GeneroId);

        Task<Filme[]> GetFilmesAsyncByDiretorId(int DiretorId);
    }
}