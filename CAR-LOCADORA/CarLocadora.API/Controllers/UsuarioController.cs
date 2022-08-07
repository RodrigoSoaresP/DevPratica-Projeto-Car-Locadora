using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using CarLocadora.Negocio.UsuarioNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;

        public UsuarioController(IUsuarioNegocio usuarioNegocio)


        {
            _usuarioNegocio = usuarioNegocio;
        }

        [HttpPost()]

        public void Post([FromBody] Usuario usuario)

        {
            _usuarioNegocio.Incluir(usuario);

        }

        [HttpGet()]

        public async Task<List<Usuario>> Get()

        {

            return _usuarioNegocio.ObterLista();

        }

        [HttpPut()]

        public void Put([FromBody] Usuario usuario)

        {

            _usuarioNegocio.Alterar(usuario);

        }
    }
}
