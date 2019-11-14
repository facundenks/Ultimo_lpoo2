using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class AutobusRepositorio
    {
        public void AgrgarAutobus(Autobus oAutobus) {
            using(BDpasajesEntities context = new BDpasajesEntities()){
                context.Autobus.AddObject(oAutobus);
                context.SaveChanges();
            }
        }

        public List<Autobus> getAutobus() {
            using(BDpasajesEntities context = new BDpasajesEntities()) {
                IQueryable<Autobus> Autobus = from q in context.Autobus
                                              select q;
                return Autobus.ToList();
            }   
        }

        public Autobus buscarAutobus(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Autobus> autobus = from q in context.Autobus
                                                          where q.aut_codigo == codigo
                                                          select q;

                List<Autobus> lista = autobus.ToList();
                if (lista.Count != 0)
                {
                    var autobusEncontrado = lista[0];

                    return autobusEncontrado;
                }
                else
                {
                    return null;
                }
            }
        }

        public Autobus buscarAutobusMatricula(String matricula)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Autobus> autobus = from q in context.Autobus
                                              where q.aut_matricula == matricula
                                              select q;

                List<Autobus> lista = autobus.ToList();
                if (lista.Count != 0)
                {
                    var autobusEncontrado = lista[0];

                    return autobusEncontrado;
                }
                else
                {
                    return null;
                }
            }
        }

        public void eliminarAutobus(int id)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                Autobus autobus = (from q in context.Autobus
                                     where q.aut_codigo == id
                                     select q).First();
                context.DeleteObject(autobus);
                context.SaveChanges();
            }
        }

        public void ModificarAutobus(Autobus oAutobus)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                Autobus autobus = context.Autobus.SingleOrDefault(p => p.aut_codigo == oAutobus.aut_codigo);
                autobus.aut_capacidad = oAutobus.aut_capacidad;
                autobus.aut_tiposervicio = oAutobus.aut_tiposervicio;
                autobus.aut_matricula = oAutobus.aut_matricula;
                autobus.emp_codigo = oAutobus.emp_codigo;
                autobus.aut_cantidadPisos = oAutobus.aut_cantidadPisos;
                autobus.aut_imagen = oAutobus.aut_imagen;

                context.SaveChanges();
            }
        }

    }
}
