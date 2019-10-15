﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{

    public partial class Usuario : INotifyPropertyChanged
    {        

        public int Usu_id
        {
            get { return usu_id; }
            set { usu_id = value;
            Notificador("usu_id");
            }
        }

        public String Usu_nombreUsuario
        {
            get { return usu_nombreUsuario; }
            set { usu_nombreUsuario = value;
            Notificador(usu_nombreUsuario);
            }
        }

        public String Usu_apellidoNombre
        {
            get { return usu_apellidoNombre; }
            set { usu_apellidoNombre = value;
            Notificador(usu_apellidoNombre);
            }
        }

        public String Usu_contraseña
        {
            get { return usu_contraseña; }
            set { usu_contraseña = value;
            Notificador(usu_contraseña);
            }
        }

        public int Rol_codigo
        {
            set { rol_codigo = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notificador(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
