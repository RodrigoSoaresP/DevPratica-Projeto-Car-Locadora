using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly Context _context;

        public VeiculoController(Context context)

        {

            _context = context;

        }

        [HttpPost()]

        public void Post([FromBody] Veiculo veiculo)

        {

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

        }

        [HttpGet()]

        public async Task<List<Veiculo>> Get()

        {

            return _context.Veiculos.ToList();

        }


    }
}
