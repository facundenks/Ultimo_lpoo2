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
            using(BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Ciudad.AddObject(oCiudad);
                context.SaveChanges();
            }
        }
    }
}
