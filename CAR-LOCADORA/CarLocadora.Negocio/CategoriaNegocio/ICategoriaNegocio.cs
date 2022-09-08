using CarLocadora.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Categoria
{
    public interface ICategoriaNegocio
    {
        Task<List<CategoriaModel>> ObterLista();
        Task<CategoriaModel> Obter(int id);
        Task Alterar(CategoriaModel categoria);
        Task Inserir(CategoriaModel categoria);
        Task Excluir(int id);

      
    }
}