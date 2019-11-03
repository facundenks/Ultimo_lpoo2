using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TrabajarClienteValidator
    {
        public ClienteValidator TraerCliente() {
            ClienteValidator oCliente = new ClienteValidator();
            oCliente.Cli_nombre = "";
            oCliente.Cli_apellido = "";
            oCliente.Cli_dni = "";
            oCliente.Cli_telefono = "";
            oCliente.Cli_email = "";
            return oCliente;
        }
    }
}
