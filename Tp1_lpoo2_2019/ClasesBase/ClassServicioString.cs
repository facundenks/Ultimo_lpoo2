using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class ClassServicioString
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

        private String ter_origen;

        public String Ter_origen
        {
            get { return ter_origen; }
            set { ter_origen = value; }
        }

        private String ter_destino;

        public String Ter_destino
        {
            get { return ter_destino; }
            set { ter_destino = value; }
        }

        private DateTime ser_fecha;

        public DateTime Ser_fecha
        {
            get { return ser_fecha; }
            set { ser_fecha = value; }
        }

        private String ser_estado;

        public String Ser_estado
        {
            get { return ser_estado; }
            set { ser_estado = value; }
        }

        private String aut_matricula;

        public String Aut_matricula
        {
            get { return aut_matricula; }
            set { aut_matricula = value; }
        }

        private String aut_tiposervicio;

        public String Aut_tiposervicio
        {
            get { return aut_tiposervicio; }
            set { aut_tiposervicio = value; }
        }
    }
}
