using CarLocadora.Modelo;


namespace CarLocadora.Negocio.Locacao
{
    public interface ILocacaoNegocio
    {
        Task<List<LocacaoModel>> ObterLista();
        Task<LocacaoModel> Obter(int id);
        Task Alterar(LocacaoModel locacao);
        Task Inserir(LocacaoModel locacao);
        Task Excluir(int id);
    }
}