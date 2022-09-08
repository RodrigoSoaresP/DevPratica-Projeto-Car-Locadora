using CarLocadora.Modelo;

namespace CarLocadora.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        Task<List<ClienteModel>> ObterLista();
        Task<ClienteModel> Obter(int cpf);
        Task Alterar(ClienteModel cliente);
        Task Inserir(ClienteModel cliente);
        Task Excluir(int cpf);
    }

    
}