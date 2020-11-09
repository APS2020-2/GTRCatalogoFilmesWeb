using System.Threading.Tasks;
using CatalogoFilmesAPI.Data;
using CatalogoFilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoFilmesAPI.Controllers
{
    [Route("CatalogoFilmesAPI/[controller]")]
    [ApiController]
    public class FilmeController : Controller
    {
        public IRepository _repo { get; }
        public FilmeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllFilmesAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpGet("{FilmeId}")]
        public async Task<IActionResult> GetByFilmeId(int FilmeId)
        {
            try
            {
                var result = await _repo.GetFilmeAsyncById(FilmeId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpGet("Filme-Genero/{GeneroId}")]
        public async Task<IActionResult> GetByGeneroId(int GeneroId)
        {
            try
            {
                var result = await _repo.GetFilmesAsyncByGeneroId(GeneroId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpGet("Filme-Diretor/{DiretorId}")]
        public async Task<IActionResult> GetByDiretorId(int DiretorId)
        {
            try
            {
                var result = await _repo.GetFilmesAsyncByDiretorId(DiretorId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Filme model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"CatalogoFilmesAPI/filme/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpPut("{FilmeId}")]
        public async Task<IActionResult> Put(int FilmeId, Filme model)
        {
            try
            {
                var filme = await _repo.GetFilmeAsyncById(FilmeId);
                if (filme == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    filme = await _repo.GetFilmeAsyncById(FilmeId);
                    return Created($"CatalogoFilmesAPI/filme/{model.Id}", model);

                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpDelete("{FilmeId}")]
        public async Task<IActionResult> Delete(int FilmeId)
        {
            try
            {
                var filme = await _repo.GetFilmeAsyncById(FilmeId);
                if (filme == null) return NotFound();

                _repo.Delete(filme);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();

                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }
    }
}