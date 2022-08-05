using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(Context context)

        {

            _context = context;

        }

        [HttpPost()]

        public void Post([FromBody] Cliente cliente)

        {

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

        }

        [HttpGet()]

        public async Task<List<Cliente>> Get()

        {

            return _context.Clientes.ToList();

        }


    }
}
