using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class ClassTrabajarTerminalString
    {
        public List<ClassTerminalString> TerminalStringList()
        {
            TerminalRepositorio listTerDAO = new TerminalRepositorio();
            CiudadRepositorio listCiuDAO = new CiudadRepositorio();

            List<Terminal> lista = listTerDAO.getTerminales();
            List<ClassTerminalString> listaString = new List<ClassTerminalString>();
            foreach (Terminal item in lista)
            {
                ClassTerminalString ter = new ClassTerminalString();
                ter.Terminal_codigo = Convert.ToString(item.ter_codigo);
                ter.Terminal_nombre = Convert.ToString(item.ter_nombre);
                Ciudad ciu = new Ciudad();
                ciu = listCiuDAO.getCiudadId((int)item.ciu_codigo);
                ter.Terminal_ciudad = ciu.ciu_nombre;
                listaString.Add(ter);
            }
            return listaString;
        }
    }
}
