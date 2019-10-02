using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow main = new MainWindow();
      
        public Login()
        {
            InitializeComponent();
            MessageBox.Show("Bienvenido");
            cargarUsuarios();
            txtUsuario.Focus();
        }

        private void cargarUsuarios() {
            
            Usuario usu1 = new Usuario(1,"admin","admin","Facundo Valdez","administrador");
            Usuario usu2 = new Usuario(2, "oper", "oper", "Vanina Valdez", "operador");
            main.Usuarios.Add(usu1);
            main.Usuarios.Add(usu2);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            Boolean bandera = false;

            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPass.Password)){
                MessageBox.Show("Completar los campos");
                txtUsuario.Text = "";
                txtPass.Clear();
                txtUsuario.Focus();
            }else{

                foreach (Usuario usu in main.Usuarios)
                {
                    if (usu.Usu_contraseña.Equals(txtPass.Password) && usu.Usu_nombreUsuario.Equals(txtUsuario.Text))
                    {
                        main.Rol = usu.Rol_codigo;
                        main.NombreApellido = usu.Usu_apellidoNombre;
                        bandera = true;
                    }
                }
                if (bandera == true)
                {
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                    txtUsuario.Text = "";
                    txtPass.Clear();
                    txtUsuario.Focus();
                }
            }
        }
    }
}
