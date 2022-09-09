using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Usuario
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly Context _context;

        public UsuarioNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> ObterLista()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Obter(string CPF)
        {
            return await _context.Usuarios.SingleAsync(x => x.CPF.Equals(CPF));

        }
        public async Task Alterar(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(UsuarioModel usuario)
        {
            _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        //public async Task Excluir(int usuario)
        //{
        //    var id = _context.Usuarios.Single(x => x.CPF.Equals(usuario));
        //    _context.Usuarios.Remove(id);
        //    _context.SaveChanges();

        //}
    }
}