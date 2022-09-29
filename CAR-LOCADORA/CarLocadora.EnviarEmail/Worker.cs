using CarLocadora.Modelo;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CarLocadora.EnviarEmail
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Servi�o executado �s", DateTimeOffset.Now);
                HttpResponseMessage retorno = await _httpClient.GetAsync("https://localhost:44369/api/Cliente/ObterListaEnviarEmail");

                await Task.Delay(5000, stoppingToken);
            }
        }

    }
}
