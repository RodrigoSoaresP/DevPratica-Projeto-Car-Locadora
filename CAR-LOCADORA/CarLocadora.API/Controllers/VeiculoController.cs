using CarLocadora.Modelo;
using CarLocadora.Negocio.Veiculo;
using Microsoft.AspNetCore.Authorization;
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

        public void Post([FromBody] VeiculoModel veiculo)

        {
            _veiculoNegocio.Inserir(veiculo);

        }

        [HttpGet()]

        public async Task<List<VeiculoModel>> Get()

        {

            return _veiculoNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public VeiculoModel Get([FromQuery] string placa)
        {
            return _veiculoNegocio.Obter(placa);
        }

        [HttpPut()]

        public void Put([FromBody] VeiculoModel veiculo)

        {

            _veiculoNegocio.Alterar(veiculo);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] string placa)
        //{
        //    _veiculoNegocio.Excluir(placa);
        //}


    }
}