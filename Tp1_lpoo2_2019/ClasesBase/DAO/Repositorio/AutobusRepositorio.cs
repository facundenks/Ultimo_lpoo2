﻿using System;
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

    }
}
