using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Negocio.FormaPagamentoNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoNegocio _formaPagamentoNegocio;


        public FormaPagamentoController(IFormaPagamentoNegocio formaPagamentoNegocio)


        {
            _formaPagamentoNegocio = formaPagamentoNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] FormaPagamento pagamento)

        {

            _formaPagamentoNegocio.Incluir(pagamento);


        }

        [HttpGet()]

        public async Task<List<FormaPagamento>> Get()

        {

            return _formaPagamentoNegocio.ObterLista();

        }

        [HttpPut()]
        public void Put([FromBody] FormaPagamento pagamento)

        {

            _formaPagamentoNegocio.Alterar(pagamento);

        }


    }
}
