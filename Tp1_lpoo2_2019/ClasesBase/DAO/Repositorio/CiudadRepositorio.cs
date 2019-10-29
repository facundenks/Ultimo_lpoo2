using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class CiudadRepositorio
    {
        public void AgregarCiudad(Ciudad oCiudad) 
        {
            using(BDpasajesEntities1 context = new BDpasajesEntities1())
            {
                context.Ciudad.AddObject(oCiudad);
                context.SaveChanges();
            }
        }
    }
}
