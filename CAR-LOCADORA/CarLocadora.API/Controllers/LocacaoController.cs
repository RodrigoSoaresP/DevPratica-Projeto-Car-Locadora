using CarLocadora.Modelo;
using CarLocadora.Negocio.Locacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoNegocio _locacaoNegocio;

        public LocacaoController(ILocacaoNegocio locacaoNegocio)
        {
            _locacaoNegocio = locacaoNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] LocacaoModel locacao)

        {
            _locacaoNegocio.Inserir(locacao);

        }

        //[HttpGet()]

        //public async Task<List<LocacaoModel>> Get()

        //{

        //    return _locacaoNegocio.ObterLista();

        //}

        //[HttpGet("ObterDados")]
        //public LocacaoModel Get([FromQuery] int id)
        //{
        //    return _locacaoNegocio.Obter(id);
        //}

        [HttpPut()]

        public void Put([FromBody] LocacaoModel locacao)

        {

            _locacaoNegocio.Alterar(locacao);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] int id)
        //{
        //    _locacaoNegocio.Excluir(id);
        //}


    }
}