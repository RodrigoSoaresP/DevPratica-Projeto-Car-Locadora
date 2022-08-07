using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Negocio.ClienteNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;

        public ClienteController(IClienteNegocio clienteNegocio)


        {
            _clienteNegocio = clienteNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] Cliente cliente)

        {
            _clienteNegocio.Incluir(cliente);

        }

        [HttpGet()]

        public async Task<List<Cliente>> Get()

        {

            return _clienteNegocio.ObterLista();

        }

        [HttpPut()]

        public void Put([FromBody] Cliente cliente)

        {

            _clienteNegocio.Alterar(cliente);



        }
    }
}