using CarLocadora.Modelo;


namespace CarLocadora.Negocio.ManutencaoVeiculo
{
    public interface IManutencaoVeiculoNegocio
    {
        Task<List<ManutencaoVeiculoModel>> ObterLista();
        Task<ManutencaoVeiculoModel> Obter(int id);
        Task Alterar(ManutencaoVeiculoModel manutencao);
        Task Inserir(ManutencaoVeiculoModel manutencao);
        Task Excluir(int valor);
    }
}


