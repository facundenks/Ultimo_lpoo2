using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Servicio
    {
        private int ser_codigo;

        public int Ser_codigo
        {
            get { return ser_codigo; }
            set { ser_codigo = value; }
        }
        private int aut_codigo;

        public int Aut_codigo
        {
            get { return aut_codigo; }
            set { aut_codigo = value; }
        }
        private DateTime ser_fecha;

        public DateTime Ser_fecha
        {
            get { return ser_fecha; }
            set { ser_fecha = value; }
        }
        private int ter_codigo_origen;

        public int Ter_codigo_origen
        {
            get { return ter_codigo_origen; }
            set { ter_codigo_origen = value; }
        }
        private int ter_codigo_destino;

        public int Ter_codigo_destino
        {
            get { return ter_codigo_destino; }
            set { ter_codigo_destino = value; }
        }
        private string ser_estado;

        public string Ser_estado
        {
            get { return ser_estado; }
            set { ser_estado = value; }
        }
    }
}
