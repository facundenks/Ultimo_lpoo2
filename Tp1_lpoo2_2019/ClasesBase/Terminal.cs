using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Terminal
    {
        private int ter_codigo;

        public int Ter_codigo
        {
            get { return ter_codigo; }
            set { ter_codigo = value; }
        }
        private int ciu_codigo;

        public int Ciu_codigo
        {
            get { return ciu_codigo; }
            set { ciu_codigo = value; }
        }
        private string ter_nombre;

        public string Ter_nombre
        {
            get { return ter_nombre; }
            set { ter_nombre = value; }
        }
    }
}
