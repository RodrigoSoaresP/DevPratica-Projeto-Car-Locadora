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

        public VistoriaController(IVistoriaNegocio vistoriaNegocio)
        {
            _vistoriaNegocio = vistoriaNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] VistoriaModel vistoria)

        {
            _vistoriaNegocio.Inserir(vistoria);

        }

        //[HttpGet()]

        //public async Task<List<VistoriaModel>> Get()

        //{

        //    return _vistoriaNegocio.ObterLista();

        //}

        //[HttpGet("ObterDados")]
        //public VistoriaModel Get([FromQuery] int id)
        //{
        //    return _vistoriaNegocio.Obter(id);
        //}

        [HttpPut()]

        public void Put([FromBody] VistoriaModel vistoria)

        {

            _vistoriaNegocio.Alterar(vistoria);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] int id)
        //{
        //    _vistoriaNegocio.Excluir(id);
        //}


    }
}