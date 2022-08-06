using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VeiculoNegocio
{
    public class VeiculoNegocio : IVeiculoNegocio
    {
        private readonly Context _context;

        public VeiculoNegocio(Context context)
        {
            _context = context;
        }


        public void Incluir(Veiculo veiculo)
        {
            _context.Veiculos.AddAsync(veiculo);
            _context.SaveChanges();
        }

        public List<Veiculo> ObterLista()
        {
            //return _context.Veiculos.ToList();
            return _context.Veiculos.OrderBy(x => x.Placa).ToList();
        }


        public void Alterar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

    }
}
