using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Matiselacome.com

namespace ClasesBase
{
    public class Cliente
    {
        private string cli_dni;

        public string Cli_dni
        {
            get { return cli_dni; }
            set { cli_dni = value; }
        }
        private string cli_nombre;

        public string Cli_nombre
        {
            get { return cli_nombre; }
            set { cli_nombre = value; }
        }
        private string cli_apellido;

        public string Cli_apellido
        {
            get { return cli_apellido; }
            set { cli_apellido = value; }
        }
        private string cli_telefono;

        public string Cli_telefono
        {
            get { return cli_telefono; }
            set { cli_telefono = value; }
        }
        private string cli_email;

        public string Cli_email
        {
            get { return cli_email; }
            set { cli_email = value; }
        }
    }
}
