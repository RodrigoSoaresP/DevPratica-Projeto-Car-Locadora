using CarLocadora.Modelo;

namespace CarLocadora.Negocio.Usuario
{
    public interface IUsuarioNegocio
    {
        Task<List<UsuarioModel>> ObterLista();
        Task<UsuarioModel> Obter(string CPF);
        Task Alterar(UsuarioModel usuario);
        Task Inserir(UsuarioModel usuario);
        //Task Excluir(int id);
    }
}