using System.Threading.Tasks;
using CatalogoFilmesAPI.Data;
using CatalogoFilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoFilmesAPI.Controllers
{
    [Route("CatalogoFilmesAPI/[controller]")]
    [ApiController]
    public class GeneroController : Controller
    {
        public IRepository _repo { get; }
        public GeneroController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllGenerosAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpGet("{GeneroId}")]
        public async Task<IActionResult> GetByGeneroId(int GeneroId)
        {
            try
            {
                var result = await _repo.GetGeneroAsyncById(GeneroId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Genero model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"CatalogoFilmesAPI/genero/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpPut("{GeneroId}")]
        public async Task<IActionResult> Put(int GeneroId, Genero model)
        {
            try
            {
                var genero = await _repo.GetGeneroAsyncById(GeneroId);
                if (genero == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    genero = await _repo.GetGeneroAsyncById(GeneroId);
                    return Created($"CatalogoFilmesAPI/genero/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpDelete("{GeneroId}")]
        public async Task<IActionResult> Delete(int GeneroId)
        {
            try
            {
                var genero = await _repo.GetGeneroAsyncById(GeneroId);
                if (genero == null) return NotFound();

                _repo.Delete(genero);

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