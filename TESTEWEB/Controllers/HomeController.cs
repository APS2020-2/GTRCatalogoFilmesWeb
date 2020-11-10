using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TESTEWEB.DTO;
using TESTEWEB.Models;

namespace TESTEWEB.Controllers
{
    public class HomeController : Controller
    {
        public int forID;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AjaxPostCall(string titulo, string descricao, string idiomaOriginal, string dataLancamento, string duracao, string genero, string diretor)
        {
            DadosFilmes employee = new DadosFilmes
            {
                titulo = titulo,
                descricao = descricao,
                idiomaOriginal = idiomaOriginal,
                dataLancamento = dataLancamento,
                duracao = duracao,
                genero = new Genero { nome = genero},
                diretor = new Diretor { nome = diretor}
            };
            var serializedProduto = JsonConvert.SerializeObject(employee);
            InserirFilmes(employee);

            return Json(serializedProduto);
        }
        public JsonResult AjaxPutCall(int id,string titulo, string descricao, string idiomaOriginal, string dataLancamento, string duracao, string genero, string diretor)
        {
            forID = id;
            DadosFilmes employee = new DadosFilmes
            {
                id = id,
                titulo = titulo,
                descricao = descricao,
                idiomaOriginal = idiomaOriginal,
                dataLancamento = dataLancamento,
                duracao = duracao,
                genero = new Genero { nome = genero },
                diretor = new Diretor { nome = diretor }
            };
            var serializedProduto = JsonConvert.SerializeObject(employee);
            AtualizarFilmes(employee, id);

            return Json(serializedProduto);
        }
        private async void AtualizarFilmes(DadosFilmes dto,int forID)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {


                            var serializedProduto = JsonConvert.SerializeObject(dto);
                            var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                            var result = await client.PutAsync("http://localhost:5000/CatalogoFilmesAPI/filme/" + forID + "", content);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void InserirFilmes(DadosFilmes dto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {


                            var serializedProduto = JsonConvert.SerializeObject(dto);
                            var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                            var result = await client.PostAsync("http://localhost:5000/CatalogoFilmesAPI/filme/", content);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
