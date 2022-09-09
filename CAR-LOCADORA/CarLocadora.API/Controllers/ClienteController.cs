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

        public ClienteController(IClienteNegocio cliente)
        {
            _clienteNegocio = cliente;
        }

        [HttpGet()]

        public async Task<List<ClienteModel>> Get()
        {

            return await _clienteNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<ClienteModel> Get([FromQuery] string CPF)
        {

            return await _clienteNegocio.Obter(CPF);
        }

        [HttpPost()]
        public async Task Post([FromBody] ClienteModel cliente)
        {
            cliente.DataInclusao = DateTime.Now;
            cliente.DataAlteracao = null;
            await _clienteNegocio.Inserir(cliente);
        }


        [HttpPut()]
        public async Task Put([FromBody] ClienteModel cliente)
        {
            cliente.DataAlteracao = DateTime.Now;
            await _clienteNegocio.Alterar(cliente);
        }

        //[HttpDelete()]
        //public async Task Delete([FromQuery] int cpf)
        //{

        //    await _clienteNegocio.Excluir(cpf);
        //}

    }
}