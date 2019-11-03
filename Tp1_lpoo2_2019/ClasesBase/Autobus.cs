using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Autobus
    {
        private int aut_codigo;

        public int Aut_codigo
        {
            get { return aut_codigo; }
            set { aut_codigo = value; }
        }
        private int aut_capacidad;

        public int Aut_capacidad
        {
            get { return aut_capacidad; }
            set { aut_capacidad = value; }
        }
        private string aut_tipoServicio;

        public string Aut_tipoServicio
        {
            get { return aut_tipoServicio; }
            set { aut_tipoServicio = value; }
        }
        private string aut_matricula;

        public string Aut_matricula
        {
            get { return aut_matricula; }
            set { aut_matricula = value; }
        }
    }
}
