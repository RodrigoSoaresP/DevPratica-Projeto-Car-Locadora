using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class VeiculoController : Controller
    {
        private string mensagem = string.Empty;

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public VeiculoController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }

        // GET: VeiculoController
        public async Task<IActionResult> Index()
        {
           

            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<VeiculoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }


        // GET: VeiculoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] VeiculoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Algo deu errado");
                    }

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algo deu errado " + ex.Message;

                return View();
            }
        }

        // GET: VeiculoController/Edit/5
        public async Task<IActionResult> Edit(string placa)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo/ObterDados?placa={placa}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<VeiculoModel>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] VeiculoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", model);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
                    else
                        throw new Exception("Algo deu errado");

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algo deu errado " + ex.Message;

                return View();
            }
        }

        //// GET: VeiculoController/Delete/5
        //public async Task<IActionResult>Delete(string placa)
        //{
        //    try
        //    {
        //        HttpClient client = new();
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


        //        HttpResponseMessage response = await client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo?Placa={placa}");

        //        if (response.IsSuccessStatusCode)
        //            return RedirectToAction(nameof(Index), new { mensagem = "Registro deletado!", sucesso = true });
        //        else
        //            throw new Exception("Algo deu errado");

        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["erro"] = " Não foi possível realizar a exlusão" + ex.Message;

        //        return View();
        //    }
        //}

        //// POST: VeiculoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult>Delete(string veiculo, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
