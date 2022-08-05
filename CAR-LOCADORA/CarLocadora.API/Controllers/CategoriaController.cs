using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly Context _context;

        public CategoriaController(Context context)

        {

            _context = context;

        }

        [HttpPost()]

        public void Post([FromBody] Categoria categoria)

        {

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

        }

        [HttpGet()]

        public async Task<List<Categoria>> Get()

        {

            return _context.Categorias.ToList();

        }


    }
}
