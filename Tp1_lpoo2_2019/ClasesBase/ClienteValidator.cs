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
            get {
                string msg_error = null;
                switch(columnName){
                    case "Cli_dni":
                        msg_error = validar_cliDni();
                        break;
                    case "Cli_nombre":
                        msg_error = validar_cliNombre();
                        break;
                    case "Cli_apellido":
                        msg_error = validar_cliApellido(); 
                        break;
                    case "Cli_telefono":
                        msg_error = validar_cliTelefono();
                        break;
                    case "Cli_email":
                        msg_error = validar_cliEmail();
                        break;
                }
                return msg_error; 
            }
        }

        private string validar_cliDni() { 
            if(String.IsNullOrEmpty(Cli_dni)){
                return "El DNI es obligatorio\nTambien puede ingresar DNI para mostrar datos";
            }
            return null;
        }

        private string validar_cliNombre()
        {
            if (String.IsNullOrEmpty(Cli_nombre))
            {
                return "El Nombre es obligatorio";
            }
            return null;
        }

        private string validar_cliApellido()
        {
            if (String.IsNullOrEmpty(Cli_apellido))
            {
                return "El Apellido es obligatorio";
            }
            return null;
        }

        private string validar_cliTelefono()
        {
            if (String.IsNullOrEmpty(Cli_telefono))
            {
                return "El Telefono es obligatorio";
            }
            return null;
        }

        private string validar_cliEmail()
        {
            if (String.IsNullOrEmpty(Cli_email))
            {
                return "El Email es obligatorio";
            }
            return null;
        }
    }
}
