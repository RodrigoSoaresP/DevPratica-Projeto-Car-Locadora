using CarLocadora.Modelo;
using CarLocadora.Negocio.FormasPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoNegocio _formaPagamentoNegocio;
        public FormaPagamentoController(IFormaPagamentoNegocio pagamento)
        {
            _formaPagamentoNegocio = pagamento;
        }

        [HttpGet("ObterLista")]

        public async Task<List<FormaPagamentoModel>> Get()
        {

            return await _formaPagamentoNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<FormaPagamentoModel> Get([FromQuery] int id)
        {

            return await _formaPagamentoNegocio.Obter(id);
        }

        [HttpPost()]
        public async Task Post([FromBody] FormaPagamentoModel pagamento)
        {
            pagamento.DataInclusao = DateTime.Now;
            pagamento.DataAlteracao = null;
            await _formaPagamentoNegocio.Inserir(pagamento);
        }


        [HttpPut()]
        public async Task Put([FromBody] FormaPagamentoModel pagamento)
        {
            pagamento.DataAlteracao = DateTime.Now;
            await _formaPagamentoNegocio.Alterar(pagamento);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int id)
        {

            await _formaPagamentoNegocio.Excluir(id);
        }

    }
}