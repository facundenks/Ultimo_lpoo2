using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class ClienteRepositorio
    {
        public void AgrgarCliente(Cliente oCliene)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Cliente.AddObject(oCliene);
                context.SaveChanges();
            }
        }

        public List<Cliente> listarClientes()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Cliente> Clientes = from q in context.Cliente
                                              select q;
                return Clientes.ToList();
            }

        }
    }
}
