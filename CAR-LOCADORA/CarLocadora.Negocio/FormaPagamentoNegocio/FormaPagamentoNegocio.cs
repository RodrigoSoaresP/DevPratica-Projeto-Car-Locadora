using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamentoNegocio
{
    public class FormaPagamentoNegocio : IFormaPagamentoNegocio
    {
        private readonly Context _context;

            public FormaPagamentoNegocio(Context context)
        {
            _context = context;
        }


        public void Incluir(FormaPagamento pagamento)
        {
            _context.FormasPagamento.Add(pagamento);
            _context.SaveChanges();
        }

        public List<FormaPagamento> ObterLista()
        {
            //return _context.FormasPagamento.ToList();
            return _context.FormasPagamento.OrderBy(x => x.ID).ToList();
        }

    

        public void Alterar(FormaPagamento pagamento)
        {
            _context.FormasPagamento.Update(pagamento);
            _context.SaveChanges();
        }
      
    }
}
