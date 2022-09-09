using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.Negocio.Vistoria
{
    public class VistoriaNegocio : IVistoriaNegocio
    {
        private readonly Context _context;

        public VistoriaNegocio(Context context)
        {
            _context = context;
        }

        public async Task<List<VistoriaModel>> ObterLista()
        {
            return await _context.Vistorias.ToListAsync();
        }
        public async Task<VistoriaModel> Obter(int model)
        {
            return await _context.Vistorias.SingleAsync(x => x.Id.Equals(model));

        }
        public async Task Alterar(VistoriaModel model)
        {
            _context.Vistorias.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task Inserir(VistoriaModel model)
        {
            _context.Vistorias.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int veiculo)
        {
            var id = _context.Vistorias.Single(x => x.Id.Equals(veiculo));
            _context.Vistorias.Remove(id);
            _context.SaveChanges();

        }
    }
}