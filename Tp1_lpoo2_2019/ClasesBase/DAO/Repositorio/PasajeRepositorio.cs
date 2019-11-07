﻿using System;
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

        public List<Pasaje> ListaPasajes(int numServicio)
        {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Pasaje> pasaje = from q in db.Pasaje
                                                where q.ser_codigo == numServicio 
                                                select q;
                List<Pasaje> lista = pasaje.ToList();
                if (lista.Count != 0)
                {
                    return pasaje.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public Pasaje ultimoPasaje() { 
            using(BDpasajesEntities context = new BDpasajesEntities()){
                var registroMasActualizado = context.Pasaje
                                             .OrderByDescending(x => x.pas_codigo)
                                             .FirstOrDefault();
                return registroMasActualizado;
            }
        }

        public Pasaje traerAsiento(int asiento, int servicio)
        {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Pasaje> Asiento = from q in db.Pasaje
                                              where q.pas_asiento == asiento &&
                                              q.ser_codigo == servicio
                                              select q;
                List<Pasaje> lista = Asiento.ToList();
                if (lista.Count != 0)
                {
                    var pasaje = lista[0];

                    return pasaje;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Pasaje> listarPasajes()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Pasaje> Pasajes = from q in context.Pasaje
                                               select q;
                return Pasajes.ToList();
            }

        }
    }
}
