using CarLocadora.Modelo;
using CarLocadora.Negocio.ManutencaoVeiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManutencaoVeiculoController : ControllerBase
    {
        private readonly IManutencaoVeiculoNegocio _manutencaoVeiculoNegocio;

        public ManutencaoVeiculoController(IManutencaoVeiculoNegocio manutencao)
        {
            _manutencaoVeiculoNegocio = manutencao;
        }

        [HttpGet("ObterLista")]

        public async Task<List<ManutencaoVeiculoModel>> Get()
        {

            return await _manutencaoVeiculoNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<ManutencaoVeiculoModel> Get([FromQuery] int id)
        {

            return await _manutencaoVeiculoNegocio.Obter(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] ManutencaoVeiculoModel manutencao)
        {
            manutencao.DataInclusao = DateTime.Now;
            manutencao.DataAlteracao = null;
            await _manutencaoVeiculoNegocio.Inserir(manutencao);
        }


        [HttpPut()]
        public async Task Put([FromBody] ManutencaoVeiculoModel manutencao)
        {
            manutencao.DataAlteracao = DateTime.Now;
            await _manutencaoVeiculoNegocio.Alterar(manutencao);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            await _manutencaoVeiculoNegocio.Excluir(id);
        }

    }
}