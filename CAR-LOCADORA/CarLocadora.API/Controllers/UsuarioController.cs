using CarLocadora.Modelo;
using CarLocadora.Negocio.Usuario;
using Microsoft.AspNetCore.Authorization;
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

        public void Post([FromBody] UsuarioModel usuario)

        {
            _usuarioNegocio.Inserir(usuario);

        }

        [HttpGet()]

        public async Task<List<UsuarioModel>> Get()

        {

            return _usuarioNegocio.ObterLista();

        }

        [HttpGet("ObterDados")]
        public UsuarioModel Get([FromQuery] string cpf)
        {
            return _usuarioNegocio.Obter(cpf);
        }

        [HttpPut()]

        public void Put([FromBody] UsuarioModel usuario)

        {

            _usuarioNegocio.Alterar(usuario);

        }


        //[HttpDelete()]
        //public void Delete([FromQuery] string cpg)
        //{
        //    _usuarioNegocio.Excluir(cpf);
        //}


    }
}