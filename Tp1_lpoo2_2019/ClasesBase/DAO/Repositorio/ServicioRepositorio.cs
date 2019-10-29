using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class ServicioRepositorio
    {
        public void AgrgarServicio(Servicio oServicio)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Servicio.AddObject(oServicio);
                context.SaveChanges();
            }
        }

        public Servicio ultimoServicio() {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                var registroMasActualizado = context.Servicio
                                             .OrderByDescending(x => x.ser_codigo)
                                             .First();
                
                return registroMasActualizado;
            }
        }
    }
}
