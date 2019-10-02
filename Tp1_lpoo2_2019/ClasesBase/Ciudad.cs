using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ciudad
    {
        private int ciu_codigo;

        public int Ciu_codigo
        {
            get { return ciu_codigo; }
            set { ciu_codigo = value; }
        }
        private string ciu_nombre;

        public string Ciu_nombre
        {
            get { return ciu_nombre; }
            set { ciu_nombre = value; }
        }
    }
}
