using CarLocadora.Modelo;

namespace CarLocadora.Negocio.Veiculo
{
    public interface IVeiculoNegocio
    {
        Task<List<VeiculoModel>> ObterLista();
        Task<VeiculoModel> Obter(int placa);
        Task Alterar(VeiculoModel veiculo);
        Task Inserir(VeiculoModel veiculo);
        Task Excluir(int id);
    }
}