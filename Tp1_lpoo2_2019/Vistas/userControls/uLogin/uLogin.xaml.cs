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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;

using ClasesBase.DAO.Repositorio;

namespace Vistas.userControls.uLogin
{
    /// <summary>
    /// Interaction logic for uLogin.xaml
    /// </summary>
    public partial class uLogin : UserControl
    {
        private Usuario user = new Usuario();
        private UsuarioRepositorio _userRepositorio = new UsuarioRepositorio();

        public uLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPass.Password))
            {
                MessageBox.Show("Debe ingresar Username y Password.\nIntente nuevamente.", "Login incorrecto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                Usuario user = new Usuario();
                user.usu_nombreUsuario = txtUsuario.Text;
                user.usu_contraseña = txtPass.Password;
                if (_userRepositorio.login(user) == null)
                {
                    MessageBox.Show("Username o Password incorrectos.\nIntente nuevamente.", "Login incorrecto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else {
                    Main main = new Main();
                    main.Usuario = _userRepositorio.login(user);

                    Window parentwin = Window.GetWindow(this);
                    parentwin.Close();

                    main.ShowDialog();
                }
            }
        }
    }
}
