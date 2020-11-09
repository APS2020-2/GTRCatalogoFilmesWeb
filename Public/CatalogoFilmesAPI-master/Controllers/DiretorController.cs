using System.Threading.Tasks;
using CatalogoFilmesAPI.Data;
using CatalogoFilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoFilmesAPI.Controllers
{
    [Route("CatalogoFilmesAPI/[controller]")]
    [ApiController]
    public class DiretorController : Controller
    {
        public IRepository _repo { get; }
        public DiretorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllDiretoresAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpGet("{DiretorId}")]
        public async Task<IActionResult> GetByDiretorId(int DiretorId)
        {
            try
            {
                var result = await _repo.GetDiretorAsyncById(DiretorId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Diretor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"CatalogoFilmesAPI/diretor/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpPut("{DiretorId}")]
        public async Task<IActionResult> Put(int DiretorId, Diretor model)
        {
            try
            {
                var diretor = await _repo.GetDiretorAsyncById(DiretorId);
                if (diretor == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    diretor = await _repo.GetDiretorAsyncById(DiretorId);
                    return Created($"CatalogoFilmesAPI/diretor/{model.Id}", model);

                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou.");
            }

            return BadRequest();
        }

        [HttpDelete("{DiretorId}")]
        public async Task<IActionResult> Delete(int DiretorId)
        {
            try
            {
                var diretor = await _repo.GetDiretorAsyncById(DiretorId);
                if (diretor == null) return NotFound();

                _repo.Delete(diretor);

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