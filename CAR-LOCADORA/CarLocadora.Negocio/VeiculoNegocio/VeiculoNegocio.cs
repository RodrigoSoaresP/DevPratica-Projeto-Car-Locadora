using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Veiculo
{
    public class VeiculoNegocio : IVeiculoNegocio
    {
        private readonly Context _context;

        public async Task<List<VeiculoModel>> ObterLista()
        {
            return await _context.Veiculos.OrderBy(x => x.Placa).ToListAsync();
        }
        public async Task<VeiculoModel> Obter(int placa)
        {
            return await _context.Veiculos.SingleAsync(x => x.Placa.Equals(placa));

        }
        public async Task Alterar(VeiculoModel veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(VeiculoModel veiculo)
        {
            _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int veiculo)
        {
            var id = _context.Veiculos.Single(x => x.Placa.Equals(veiculo));
            _context.Veiculos.Remove(id);
            _context.SaveChanges();

        }
    }
}