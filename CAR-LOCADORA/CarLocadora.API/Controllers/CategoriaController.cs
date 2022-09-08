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

        public CategoriaController(ICategoriaNegocio categoria)
        {
            _categoriaNegocio = categoria;
        }

        [HttpGet("ObterLista")]

        public async Task<List<CategoriaModel>> Get()
        {

            return await _categoriaNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<CategoriaModel> Get([FromQuery] int id)
        {

            return await _categoriaNegocio.Obter(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] CategoriaModel categoria)
        {
            categoria.DataInclusao = DateTime.Now;
            categoria.DataAlteracao = null;
            await _categoriaNegocio.Inserir(categoria);
        }


        [HttpPut()]
        public async Task Put([FromBody] CategoriaModel categoria)
        {
            categoria.DataAlteracao = DateTime.Now;
            await _categoriaNegocio.Alterar(categoria);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            //Utilizando o Entity
            await _categoriaNegocio.Excluir(id);
        }

    }
}