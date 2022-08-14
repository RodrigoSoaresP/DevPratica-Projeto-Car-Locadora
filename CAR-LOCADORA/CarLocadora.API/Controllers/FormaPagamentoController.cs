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

        public FormaPagamentoController(IFormaPagamentoNegocio formaPagamentoNegocio)
        {
            _formaPagamentoNegocio = formaPagamentoNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] FormaPagamentoModel pagamento)

        {
            _formaPagamentoNegocio.Inserir(pagamento);

        }

        [HttpGet()]

        public async Task<List<FormaPagamentoModel>> Get()

        {

            return _formaPagamentoNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public FormaPagamentoModel Get([FromQuery] int id)
        {
            return _formaPagamentoNegocio.Obter(id);
        }

        [HttpPut()]

        public void Put([FromBody] FormaPagamentoModel pagamento)

        {

            _formaPagamentoNegocio.Alterar(pagamento);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] int id)
        //{
        //    _formaPagamentoNegocio.Excluir(id);
        //}


    }
}