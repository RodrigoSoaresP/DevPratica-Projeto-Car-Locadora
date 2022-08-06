using CarLocadora.Infra.Entity;
using CarLocadora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ClienteNegocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;

            public ClienteNegocio(Context context)
        {
            _context = context;
        }


        public void Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ObterLista()
        {
            //return _context.Clientes.ToList();
            return _context.Clientes.OrderBy(x => x.Nome).ToList();
        }

    

        public void Alterar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
      
    }
}
