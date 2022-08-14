using CarLocadora.Modelo;
using CarLocadora.Negocio.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;

        public ClienteController(IClienteNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] ClienteModel cliente)

        {
            _clienteNegocio.Inserir(cliente);

        }

        [HttpGet()]

        public async Task<List<ClienteModel>> Get()

        {

            return _clienteNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public ClienteModel Get([FromQuery] string cpf)
        {
            return _clienteNegocio.Obter(cpf);
        }

        [HttpPut()]

        public void Put([FromBody] ClienteModel cliente)

        {

            _clienteNegocio.Alterar(cliente);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] int id)
        //{
        //    _clienteNegocio.Excluir(id);
        //}


    }
}