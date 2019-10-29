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
    }
}