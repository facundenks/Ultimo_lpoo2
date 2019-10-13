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

        public Cliente buscarCliente(String dni) {

            using(BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Cliente> Clientes = from q in context.Cliente
                                               where q.cli_dni == dni
                                               select q;
                List<Cliente> lista = Clientes.ToList();
                if (lista.Count != 0)
                {
                    var clienteEncontrado = lista[0];
                    return clienteEncontrado;
                }
                else {
                    return null;
                }
            }
        }

        public void modificarCliente(Cliente unCliente) { 
            using(BDpasajesEntities context = new BDpasajesEntities()){
                Cliente oCliente = context.Cliente.SingleOrDefault(p => p.cli_dni == unCliente.cli_dni);
                oCliente.cli_dni = unCliente.cli_dni;
                oCliente.cli_nombre = unCliente.cli_nombre;
                oCliente.cli_apellido = unCliente.cli_apellido;
                oCliente.cli_telefono = unCliente.cli_telefono;
                oCliente.cli_email = unCliente.cli_email;
                context.SaveChanges();        
            }
        }
    }
}
