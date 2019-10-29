using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class PasajeRepositorio
    {
        public void AgrgarPasaje(Pasaje oPasaje)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Pasaje.AddObject(oPasaje);
                context.SaveChanges();
            }
        }
    }
}
