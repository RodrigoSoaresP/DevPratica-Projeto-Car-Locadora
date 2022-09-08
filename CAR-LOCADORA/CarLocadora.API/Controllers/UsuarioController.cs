using CarLocadora.Modelo;
using CarLocadora.Negocio.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;

        public UsuarioController(IUsuarioNegocio usuario)
        {
            _usuarioNegocio = usuario;
        }

        [HttpGet("ObterLista")]

        public async Task<List<UsuarioModel>> Get()
        {

            return await _usuarioNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<UsuarioModel> Get([FromQuery] int cpf)
        {

            return await _usuarioNegocio.Obter(cpf);
        }

        [HttpPost()]
        public async Task Post([FromBody] UsuarioModel usuario)
        {
            usuario.DataInclusao = DateTime.Now;
            usuario.DataAlteracao = null;
            await _usuarioNegocio.Inserir(usuario);
        }


        [HttpPut()]
        public async Task Put([FromBody] UsuarioModel usuario)
        {
            usuario.DataAlteracao = DateTime.Now;
            await _usuarioNegocio.Alterar(usuario);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int cpf)
        {

            await _usuarioNegocio.Excluir(cpf);
        }

    }
}