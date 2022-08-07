using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Negocio.VeiculoNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoNegocio _veiculoNegocio;

        public VeiculoController(IVeiculoNegocio veiculoNegocio)


        {
            _veiculoNegocio = veiculoNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] Veiculo veiculo)

        {
            _veiculoNegocio.Incluir(veiculo);

        }

        [HttpGet()]

        public async Task<List<Veiculo>> Get()

        {

            return _veiculoNegocio.ObterLista();

        }

        [HttpPut()]

        public void Put([FromBody] Veiculo veiculo)

        {

            _veiculoNegocio.Alterar(veiculo);



        }
    }
}