using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Controllers
{
    public class VistoriaController : Controller
    {
        private string mensagem = "";

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        public VistoriaController(IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {

            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }
        public async Task<IActionResult> Index()
        {
         

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Vistoria");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<VistoriaModel>>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }

        }

        // GET: VistoriaController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Locacoes = CarregarLocacoes().Result;
            return View();
        }

        // POST: VistoriaController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] VistoriaModel vistoria)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Vistoria", vistoria);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro cadastrado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Algo deu errado");
                    }


                }
                else
                {
                    ViewBag.CarregarLocacao = Locacao();
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        // GET: VistoriaController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Vistoria/ObterDados?Id={id}");

            if (response.IsSuccessStatusCode)
            {

                ViewBag.locacoes = CarregarLocacoes().Result;
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<VistoriaModel>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // POST: VistoriaController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] VistoriaModel vistoria)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Vistoria", vistoria);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Editado!", sucesso = true });

                    }
                    else
                    {

                        throw new Exception("Erro ao tentar editar uma Vistoria!!");
                    }


                }
                else
                {
                    ViewBag.CarregarLocacao = Locacao();
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }



        private async Task <List<SelectListItem>> Locacao()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                List<LocacaoModel> locacao = JsonConvert.DeserializeObject<List<LocacaoModel>>(conteudo);

                foreach (var linha in locacao)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.Id.ToString(),
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }


        private async Task<List<SelectListItem>> CarregarLocacoes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Locacao");

            if (response.IsSuccessStatusCode)
            {
                List<LocacaoModel> locacoes = JsonConvert.DeserializeObject<List<LocacaoModel>>(response.Content.ReadAsStringAsync().Result);

                foreach (var linha in locacoes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.VeiculoPlaca + " - " + linha.ClienteCPF,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}