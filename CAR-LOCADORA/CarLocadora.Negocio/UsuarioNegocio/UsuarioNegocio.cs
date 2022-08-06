using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.UsuarioNegocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly Context _context;

            public UsuarioNegocio(Context context)
        {
            _context = context;
        }


        public void Incluir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ObterLista()
        {
            //return _context.Usuarios.ToList();
            return _context.Usuarios.OrderBy(x => x.Nome).ToList();
        }

    
        public void Alterar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
      
    }
}
