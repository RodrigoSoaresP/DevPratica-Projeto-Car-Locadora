
using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Categoria
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly Context _context;
        public CategoriaNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<CategoriaModel>> ObterLista()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<CategoriaModel> Obter(int id)
        {
            return await _context.Categorias.SingleAsync(x => x.Id.Equals(id));

        }
        public async Task Alterar(CategoriaModel categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(CategoriaModel categoria)
        {
            _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int valor)
        {
            var id = _context.Categorias.Single(x => x.Id.Equals(valor));
            _context.Categorias.Remove(id);
            _context.SaveChanges();

        }
    }
}