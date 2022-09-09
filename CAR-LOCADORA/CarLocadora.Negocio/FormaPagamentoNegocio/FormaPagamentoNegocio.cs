using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.FormasPagamento
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly Context _context;

        public FormaPagamentoNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<FormaPagamentoModel>> ObterLista()
        {
            return await _context.FormasPagamento.ToListAsync();
        }
        public async Task<FormaPagamentoModel> Obter(int id)
        {
            return await _context.FormasPagamento.SingleAsync(x => x.Id.Equals(id));

        }
        public async Task Alterar(FormaPagamentoModel pagamento)
        {
            _context.FormasPagamento.Update(pagamento);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(FormaPagamentoModel pagamento)
        {
            _context.FormasPagamento.Add(pagamento);
            _context.SaveChangesAsync();
        }

        public async Task Excluir(int pagamento)
        {
            var id = _context.FormasPagamento.Single(x => x.Id.Equals(pagamento));
            _context.FormasPagamento.Remove(id);
            await _context.SaveChangesAsync();
        }
    }
}