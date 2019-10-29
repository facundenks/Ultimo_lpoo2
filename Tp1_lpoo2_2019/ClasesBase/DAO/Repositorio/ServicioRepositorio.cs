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

        public Servicio servicioCoche(int numAutobus)
        {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicio = from q in db.Servicio
                                              where q.aut_codigo == numAutobus &&
                                              q.ser_estado == "Abierto"
                                              select q;
                List<Servicio> lista = servicio.ToList();
                if (lista.Count != 0)
                {
                    var servicioCoche = lista[0];

                    return servicioCoche;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
