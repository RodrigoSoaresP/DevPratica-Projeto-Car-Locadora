using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Locacao
{
    public class LocacaoNegocio : ILocacaoNegocio
    {
        private readonly Context _context;

        public LocacaoNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<LocacaoModel>> ObterLista()
        {
            return await _context.Locacao.ToListAsync();
        }
        public async Task<LocacaoModel> Obter(int id)
        {
            return await _context.Locacao.SingleAsync(x => x.Id.Equals(id));

        }
        public async Task Alterar(LocacaoModel locacao)
        {
            _context.Locacao.Update(locacao);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(LocacaoModel locacao)
        {
            _context.Locacao.Add(locacao);
            _context.SaveChangesAsync();
        }

        public async Task Excluir(int locacao)
        {
            var id = _context.Locacao.Single(x => x.Id.Equals(locacao));
            _context.Locacao.Remove(id);
            await _context.SaveChangesAsync();
        }
    }
}
