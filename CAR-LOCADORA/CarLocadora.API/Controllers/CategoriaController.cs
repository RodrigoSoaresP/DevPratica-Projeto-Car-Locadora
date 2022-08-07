using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Negocio.CategoriaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] Categoria categoria)

        {
            _categoriaNegocio.Incluir(categoria);

        }

        [HttpGet()]

        public async Task<List<Categoria>> Get()

        {

            return _categoriaNegocio.ObterLista();

        }

        [HttpPut()]

        public void Put([FromBody] Categoria categoria)

        {

             _categoriaNegocio.Alterar(categoria);

        }


        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _categoriaNegocio.Excluir(id);
        }


    }
}
