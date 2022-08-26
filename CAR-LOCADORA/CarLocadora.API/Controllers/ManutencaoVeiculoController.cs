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

        public ManutencaoVeiculoController(IManutencaoVeiculoNegocio manutencaoVeiculoNegocio)
        {
            _manutencaoVeiculoNegocio = manutencaoVeiculoNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)

        {
            _manutencaoVeiculoNegocio.Inserir(manutencaoVeiculoModel);

        }

        [HttpGet()]

        public async Task<List<ManutencaoVeiculoModel>> Get()

        {

            return _manutencaoVeiculoNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public ManutencaoVeiculoModel Get([FromQuery] int id)
        {
            return _manutencaoVeiculoNegocio.Obter(id);
        }

        [HttpPut()]

        public void Put([FromBody] ManutencaoVeiculoModel manutencaoVeiculoModel)

        {

            _manutencaoVeiculoNegocio.Alterar(manutencaoVeiculoModel);

        }


        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _manutencaoVeiculoNegocio.Excluir(id);
        }


    }
}