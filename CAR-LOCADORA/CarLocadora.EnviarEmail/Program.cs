using CarLocadora.Comum;
using CarLocadora.Comum.Modelo;
using CarLocadora.Comum.Servico;
using CarLocadora.EnviarEmail;
using CarLocadora.Modelo;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();
        services.AddSingleton<IApiToken, ApiToken>();
        services.AddSingleton<LoginRespostaModel>();
        services.Configure<DadosBase>(hostContext.Configuration.GetSection("DadosBase"));


        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();