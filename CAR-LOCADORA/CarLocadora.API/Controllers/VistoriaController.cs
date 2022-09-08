using CarLocadora.Modelo;
using CarLocadora.Negocio.Vistoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VistoriaController : ControllerBase
    {
        private readonly IVistoriaNegocio _vistoriaNegocio;

        public VistoriaController(IVistoriaNegocio vistoria)
        {
            _vistoriaNegocio = vistoria;
        }

        [HttpGet("ObterLista")]

        public async Task<List<VistoriaModel>> Get()
        {

            return await _vistoriaNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<VistoriaModel> Get([FromQuery] int id)
        {

            return await _vistoriaNegocio.Obter(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] VistoriaModel vistoria)
        {
            vistoria.DataInclusao = DateTime.Now;
            vistoria.DataAlteracao = null;
            await _vistoriaNegocio.Inserir(vistoria);
        }


        [HttpPut()]
        public async Task Put([FromBody] VistoriaModel vistoria)
        {
            vistoria.DataAlteracao = DateTime.Now;
            await _vistoriaNegocio.Alterar(vistoria);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            await _vistoriaNegocio.Excluir(id);
        }

    }
}