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

        public LocacaoController(ILocacaoNegocio locacao)
        {
            _locacaoNegocio = locacao;
        }

        [HttpGet()]

        public async Task<List<LocacaoModel>> Get()
        {

            return await _locacaoNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<LocacaoModel> Get([FromQuery] int id)
        {

            return await _locacaoNegocio.Obter(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] LocacaoModel locacao)
        {
            locacao.DataInclusao = DateTime.Now;
            locacao.DataAlteracao = null;
            await _locacaoNegocio.Inserir(locacao);
        }


        [HttpPut()]
        public async Task Put([FromBody] LocacaoModel locacao)
        {
            locacao.DataAlteracao = DateTime.Now;
            await _locacaoNegocio.Alterar(locacao);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            await _locacaoNegocio.Excluir(id);
        }

    }
}