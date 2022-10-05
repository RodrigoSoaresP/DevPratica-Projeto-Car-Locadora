using CarLocadora.Comum.Modelo;
using CarLocadora.Comum.Servico;
using CarLocadora.Modelo;


namespace CarLocadora.Front.Extensoes
{
    public static class ServicoExtencoesFront
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IApiToken, ApiToken>();
            services.AddSingleton<LoginRespostaModel>();
            services.AddHttpClient();
        }

        public static void ConfiguraAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DadosBase>(configuration.GetSection("DadosBase"));
        }
    }
}