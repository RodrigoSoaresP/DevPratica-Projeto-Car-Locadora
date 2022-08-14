using CarLocadora.Modelo;
using CarLocadora.Negocio.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] CategoriaModel categoria)

        {
            _categoriaNegocio.Inserir(categoria);

        }

        [HttpGet()]

        public async Task<List<CategoriaModel>> Get()

        {

            return _categoriaNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public CategoriaModel Get([FromQuery] int id)
        {
            return _categoriaNegocio.Obter(id);
        }

        [HttpPut()]

        public void Put([FromBody] CategoriaModel categoria)

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