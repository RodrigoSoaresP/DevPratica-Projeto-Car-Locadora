using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.CategoriaNegocio
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly Context _context;

        public CategoriaNegocio(Context context)
        {
            _context = context;
        }


        public void Incluir(Categoria categoria)
        {
            _context.Categorias.AddAsync(categoria);
            _context.SaveChanges();
        }

        public List<Categoria> ObterLista()
        {
            //return _context.Categorias.ToList();
            return _context.Categorias.OrderBy(x => x.ID).ToList();
        }



        public void Alterar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria categoria = _context.Categorias.SingleOrDefault(x => x.ID == id);
            _context.Categorias.Remove(categoria);
            _context.SaveChangesAsync();
        }
    }
}
