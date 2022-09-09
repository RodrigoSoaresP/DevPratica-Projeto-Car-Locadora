using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.ManutencaoVeiculo
{
    public class ManutencaoVeiculoNegocio : IManutencaoVeiculoNegocio
    {
        private readonly Context _context;

        public ManutencaoVeiculoNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<ManutencaoVeiculoModel>> ObterLista()
        {
            return await _context.ManutencaoVeiculo.ToListAsync();
        }
        public async Task<ManutencaoVeiculoModel> Obter(int id)
        {
            return await _context.ManutencaoVeiculo.SingleAsync(x => x.Id.Equals(id));

        }
        public async Task Alterar(ManutencaoVeiculoModel manutencao)
        {
            _context.ManutencaoVeiculo.Update(manutencao);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(ManutencaoVeiculoModel manutencao)
        {
            _context.ManutencaoVeiculo.Add(manutencao);
            _context.SaveChangesAsync();
        }

        public async Task Excluir(int manutencao)
        {
            var id = _context.ManutencaoVeiculo.Single(x => x.Id.Equals(manutencao));
            _context.ManutencaoVeiculo.Remove(id);
            await _context.SaveChangesAsync();
        }
    }
}