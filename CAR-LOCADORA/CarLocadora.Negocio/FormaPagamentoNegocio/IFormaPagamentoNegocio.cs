using CarLocadora.Modelo;


namespace CarLocadora.Negocio.FormasPagamento
{
    public interface IFormaPagamentoNegocio
    {
        Task<List<FormaPagamentoModel>> ObterLista();
        Task<FormaPagamentoModel> Obter(int id);
        Task Alterar(FormaPagamentoModel pagamento);
        Task Inserir(FormaPagamentoModel pagamento);
        Task Excluir(int id);
    }
}