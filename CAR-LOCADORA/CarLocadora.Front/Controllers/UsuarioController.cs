using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class UsuarioController : Controller
    {
        private string mensagem = string.Empty;

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public UsuarioController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }

        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
           
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Usuario");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<UsuarioModel>>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }



        // GET: UsuarioController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Usuario", model);

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

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(string CPF)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Usuario/ObterDados?CPF={CPF}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<UsuarioModel>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Usuario", model);

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

        //// GET: UsuarioController/Delete/5
        //public async Task<IActionResult>Delete(string cpf)
        //{
        //    try
        //    {
        //        HttpClient client = new();
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


        //        HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Usuario?CPF={cpf}").Result;

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

        //// POST: UsuarioController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult>Delete(string cpf, IFormCollection collection)
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
