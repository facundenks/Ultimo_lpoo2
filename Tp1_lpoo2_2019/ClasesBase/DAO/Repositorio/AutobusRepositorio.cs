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

    }
}
