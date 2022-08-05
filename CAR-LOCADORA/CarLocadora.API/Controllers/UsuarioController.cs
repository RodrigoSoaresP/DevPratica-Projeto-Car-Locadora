using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _context;

        public UsuarioController(Context context)

        {

            _context = context;

        }

        [HttpPost()]

        public void Post([FromBody] Usuario usuario)

        {

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

        }

        [HttpGet()]

        public async Task<List<Usuario>> Get()

        {

            return _context.Usuarios.ToList();

        }


    }
}
