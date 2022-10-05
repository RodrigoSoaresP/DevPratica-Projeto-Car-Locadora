using CarLocadora.Comum.Modelo;
using CarLocadora.Comum.Servico;
using CarLocadora.Modelo;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;

namespace CarLocadora.EnviarEmail
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;
        private readonly IApiToken _apiToken;
        private readonly IOptions<DadosBase> _dadosBase;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient, IOptions<DadosBase> dadosBase, IApiToken apiToken)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
            _dadosBase = dadosBase;
            _apiToken = apiToken;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Serviço executado às", DateTime.Now);

                List<ClienteModel> clientes = await BuscarEmailCliente();
                //HttpResponseMessage retorno = await _httpClient.GetAsync("https://localhost:44369/api/Cliente");
                foreach (var cliente in clientes)
                {
                    try
                    {
                        await EnviarEmail(cliente.Email, cliente.Nome);
                        await AtualizarCliente(cliente);
                    }
                    catch (Exception)
                    {
                        continue;
                    }


                }

                await Task.Delay(35000, stoppingToken);
            }
        }
        private async Task<List<ClienteModel>> BuscarEmailCliente()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage retorno = await _httpClient.GetAsync("https://localhost:44369/api/Cliente/ObterListaEnviarEmail");
            if (retorno.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<ClienteModel>>(await retorno.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }

        }

        private async Task EnviarEmail(string email, string nome)
        {
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("turma1@devpratica.com.br");
            mensagem.To.Add(email);
            mensagem.Subject = "Bem-Vindo!!!";
            mensagem.IsBodyHtml = true;
            mensagem.Body = EmailBoasVindas(nome);

            var smtpCliente = new SmtpClient("smtp.kinghost.net")
            {
                Port = 587,
                Credentials = new NetworkCredential("turma1@devpratica.com.br", "Senha@senha10"),
                EnableSsl = false,

            };
            smtpCliente.Send(mensagem);
        }
        private string EmailBoasVindas(string nome)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>Parabéns <b>{nome},</b></p>");
            sb.Append($"<p>Seja muito bem-vindo a <b>CAR-LOCADORA.</b></p>");
            sb.Append($"<p>Estamos muito felizes de você fazer parte da <b>CAR-LOCADORA</b>.</p>");
            sb.Append($"<br>");
            sb.Append($"<p>Grande abraço</p>");
            return sb.ToString();
        }

        private async Task AtualizarCliente(ClienteModel cliente)
        {
            cliente.EmailEnviado = true;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", cliente);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Email Enviado com sucesso!");
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
