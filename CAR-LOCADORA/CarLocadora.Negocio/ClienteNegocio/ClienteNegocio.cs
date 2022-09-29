using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;

        public ClienteNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<ClienteModel>> ObterLista()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> Obter(string CPF)
        {
            return await _context.Clientes.SingleAsync(x => x.CPF.Equals(CPF));

        }
        public async Task Alterar(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(ClienteModel cliente)
        {
            _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(string cliente)
        {
            var CPF = _context.Clientes.Single(x => x.CPF.Equals(cliente));
            _context.Clientes.Remove(CPF);
            _context.SaveChanges();

        }

        public async Task<List<ClienteModel>> ObterListaEnviarEmail()
        {
            return await _context.Clientes.Where(e => e.Email != null && e.EmailEnviado.Equals(false)).ToListAsync();
        }
    }
}