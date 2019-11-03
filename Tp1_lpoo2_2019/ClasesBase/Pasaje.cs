using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Pasaje
    {
        private int pas_codigo;

        public int Pas_codigo
        {
            get { return pas_codigo; }
            set { pas_codigo = value; }
        }
        private string cli_dni;

        public string Cli_dni
        {
            get { return cli_dni; }
            set { cli_dni = value; }
        }
        private int ser_codigo;

        public int Ser_codigo
        {
            get { return ser_codigo; }
            set { ser_codigo = value; }
        }
        private int pas_asiento;

        public int Pas_asiento
        {
            get { return pas_asiento; }
            set { pas_asiento = value; }
        }
        private decimal pas_precio;

        public decimal Pas_precio
        {
            get { return pas_precio; }
            set { pas_precio = value; }
        }
    }
}
