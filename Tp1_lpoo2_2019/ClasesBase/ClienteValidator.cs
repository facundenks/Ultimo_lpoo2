using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class ClienteValidator: IDataErrorInfo
    {
        private String cli_dni;

        public String Cli_dni
        {
            get { return cli_dni; }
            set { cli_dni = value; }
        }
        private String cli_nombre;

        public String Cli_nombre
        {
            get { return cli_nombre; }
            set { cli_nombre = value; }
        }
        private String cli_apellido;

        public String Cli_apellido
        {
            get { return cli_apellido; }
            set { cli_apellido = value; }
        }
        private String cli_telefono;

        public String Cli_telefono
        {
            get { return cli_telefono; }
            set { cli_telefono = value; }
        }
        private String cli_email;

        public String Cli_email
        {
            get { return cli_email; }
            set { cli_email = value; }
        }



        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
