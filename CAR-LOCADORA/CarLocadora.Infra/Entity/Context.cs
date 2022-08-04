using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Infra.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Categoria > Categorias { get; set; }    
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }




    }
}
