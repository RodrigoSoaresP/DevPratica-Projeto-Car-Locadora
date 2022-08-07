
using CarLocadora.Negocio.CategoriaNegocio;
using CarLocadora.Negocio.ClienteNegocio;
using CarLocadora.Negocio.FormaPagamentoNegocio;
using CarLocadora.Negocio.UsuarioNegocio;
using CarLocadora.Negocio.VeiculoNegocio;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {

        public static void ConfigurarServicos(this IServiceCollection services)
        {

            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234;Initial Catalog=DBCarLocadora;";

            services.AddDbContext<Infra.Entity.Context>(item => item.UseSqlServer(connectionString));
            services.AddScoped<ICategoriaNegocio, CategoriaNegocio>();
            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            services.AddScoped<IFormaPagamentoNegocio, FormaPagamentoNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IVeiculoNegocio, VeiculoNegocio>();
        }



    }
}
