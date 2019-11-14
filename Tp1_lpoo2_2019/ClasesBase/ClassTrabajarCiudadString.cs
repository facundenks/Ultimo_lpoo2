using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class ClassTrabajarCiudadString
    {
        public List<ClassCiudadString> CiudadStringList()
        {
            List<ClassCiudadString> listaString = new List<ClassCiudadString>(); 
            CiudadRepositorio _ciudadRepositorio = new CiudadRepositorio();
            List<Ciudad> ciudades = _ciudadRepositorio.getCiudades();
            foreach(Ciudad ciu in ciudades)
            {
                ClassCiudadString ciudad = new ClassCiudadString();
                ciudad.Ciu_codigo = Convert.ToString(ciu.ciu_codigo);
                ciudad.Ciu_nombre = ciu.ciu_nombre;
                
                listaString.Add(ciudad);
            }

            return listaString;
        }
    }
}
