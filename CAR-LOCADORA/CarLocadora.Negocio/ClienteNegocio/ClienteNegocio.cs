using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;

        public async Task<List<ClienteModel>> ObterLista()
        {
            return await _context.Clientes.OrderBy(x => x.CPF).ToListAsync();
        }
        public async Task<ClienteModel> Obter(int cpf)
        {
            return await _context.Clientes.SingleAsync(x => x.CPF.Equals(cpf));

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

        public async Task Excluir(int cliente)
        {
            var id = _context.Clientes.Single(x => x.CPF.Equals(cliente));
            _context.Clientes.Remove(id);
            _context.SaveChanges();

        }
    }
}