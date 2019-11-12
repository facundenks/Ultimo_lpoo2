﻿using System;
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

        public List<Ciudad> getCiudades()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Ciudad> ciudades = from q in context.Ciudad
                                              select q;
                return ciudades.ToList();
            }
        }

        public Ciudad getCiudad(String nombre)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Ciudad> ciudad = from q in context.Ciudad
                                              where q.ciu_nombre == nombre
                                              select q;

                List<Ciudad> lista = ciudad.ToList();
                if (lista.Count != 0)
                {
                    var ciudadEncontrada = lista[0];

                    return ciudadEncontrada;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
