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
    }
}
