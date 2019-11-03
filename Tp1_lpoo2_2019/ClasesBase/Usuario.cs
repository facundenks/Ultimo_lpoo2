using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private int usu_id;

        public int Usu_id
        {
            get { return usu_id; }
            set { usu_id = value; }
        }
        private string usu_nombreUsuario;

        public string Usu_nombreUsuario
        {
            get { return usu_nombreUsuario; }
            set { usu_nombreUsuario = value; }
        }
        private string usu_contraseña;

        public string Usu_contraseña
        {
            get { return usu_contraseña; }
            set { usu_contraseña = value; }
        }
        private string usu_apellidoNombre;

        public string Usu_apellidoNombre
        {
            get { return usu_apellidoNombre; }
            set { usu_apellidoNombre = value; }
        }
        private string rol_codigo;

        public string Rol_codigo
        {
            get { return rol_codigo; }
            set { rol_codigo = value; }
        }

        public Usuario(int id, string nombreUsuario, string contraseña, string apellidoNombre, string rol) {
            this.Usu_id = usu_id;
            this.Usu_nombreUsuario = nombreUsuario;
            this.Usu_contraseña = contraseña;
            this.Usu_apellidoNombre = apellidoNombre;
            this.Rol_codigo = rol;
        }
    }
}
