using CarLocadora.Modelo;


namespace CarLocadora.Negocio.Vistoria
{
    public interface IVistoriaNegocio
    {
        Task<List<VistoriaModel>> ObterLista();
        Task<VistoriaModel> Obter(int id);
        Task Alterar(VistoriaModel model);
        Task Inserir(VistoriaModel model);
        Task Excluir(int id);
    }
}