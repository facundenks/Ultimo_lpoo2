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

        public Servicio buscarServicio(int codigo) {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicioEncontrado = from q in context.Servicio
                                                          where q.ser_codigo == codigo && 
                                                          q.ser_estado == "Abierto"
                                                          select q;

                List<Servicio> lista = servicioEncontrado.ToList();
                if (lista.Count != 0)
                {
                    var servicio = lista[0];

                    return servicio;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool servicioConVentas(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Pasaje> servicioConPasajes = from q in context.Pasaje
                                                          where q.ser_codigo == codigo
                                                          select q;

                List<Pasaje> lista = servicioConPasajes.ToList();
                if (lista.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
