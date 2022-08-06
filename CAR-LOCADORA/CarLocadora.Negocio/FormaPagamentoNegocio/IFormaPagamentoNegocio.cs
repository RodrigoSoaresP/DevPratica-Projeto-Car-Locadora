using CarLocadora.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.FormaPagamentoNegocio
{
    public interface IFormaPagamentoNegocio
    {
        List<FormaPagamento> ObterLista();

        void Incluir(FormaPagamento pagamento);

        void Alterar(FormaPagamento pagamento);



    }
}
