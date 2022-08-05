using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly Context _context;

        public FormaPagamentoController(Context context)

        {

            _context = context;

        }

        [HttpPost()]

        public void Post([FromBody] FormaPagamento pagamento)

        {

            _context.FormasPagamento.Add(pagamento);
            _context.SaveChanges();

        }

        [HttpGet()]

        public async Task<List<FormaPagamento>> Get()

        {

            return _context.FormasPagamento.ToList();

        }


    }
}
