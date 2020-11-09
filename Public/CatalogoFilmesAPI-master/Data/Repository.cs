using System.Linq;
using System.Threading.Tasks;
using CatalogoFilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoFilmesAPI.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }

        public Repository(DataContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        // GENERO
        public async Task<Genero[]> GetAllGenerosAsync()
        {
            IQueryable<Genero> query = _context.Generos.Include(g => g.Filmes);

            query = query.AsNoTracking().OrderBy(g => g.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Genero> GetGeneroAsyncById(int GeneroId)
        {
            IQueryable<Genero> query = _context.Generos.Include(g => g.Filmes);

            query = query.AsNoTracking().OrderBy(g => g.Id).Where(g => g.Id == GeneroId);

            return await query.FirstOrDefaultAsync();
        }

        //FILME
        public async Task<Filme[]> GetAllFilmesAsync()
        {
            IQueryable<Filme> query = _context.Filmes.Include(f => f.Genero).Include(f => f.Diretor);

            query = query.AsNoTracking().OrderBy(f => f.Titulo);

            return await query.ToArrayAsync();
        }

        public async Task<Filme> GetFilmeAsyncById(int FilmeId)
        {
            IQueryable<Filme> query = _context.Filmes.Include(f => f.Genero).Include(f => f.Diretor);

            query = query.AsNoTracking().OrderBy(f => f.Id).Where(f => f.Id == FilmeId);

            return await query.FirstOrDefaultAsync();
        }

        //DIRETOR
        public async Task<Diretor[]> GetAllDiretoresAsync()
        {
            IQueryable<Diretor> query = _context.Diretores.Include(d => d.Filmes);

            query = query.AsNoTracking().OrderBy(d => d.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Diretor> GetDiretorAsyncById(int DiretorId)
        {
            IQueryable<Diretor> query = _context.Diretores.Include(d => d.Filmes);

            query = query.AsNoTracking().OrderBy(d => d.Nome).Where(d => d.Id == DiretorId);

            return await query.FirstOrDefaultAsync();
        }

        //OUTROS
        public async Task<Filme[]> GetFilmesAsyncByGeneroId(int GeneroId)
        {
            IQueryable<Filme> query = _context.Filmes.Include(f => f.Genero).Include(f => f.Diretor);

            query = query.AsNoTracking().OrderBy(f => f.Id).Where(f => f.GeneroId == GeneroId);

            return await query.ToArrayAsync();
        }

        public async Task<Filme[]> GetFilmesAsyncByDiretorId(int DiretorId)
        {
            IQueryable<Filme> query = _context.Filmes.Include(f => f.Genero).Include(f => f.Diretor);

            query = query.AsNoTracking().OrderBy(f => f.Id).Where(f => f.DiretorId == DiretorId);

            return await query.ToArrayAsync();
        }
    }
}