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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for formLogin.xaml
    /// </summary>
    public partial class formLogin : Window
    {
        private double tiempoTranscurrido;
        private DispatcherTimer _timer = new DispatcherTimer();

        public formLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tiempoTranscurrido = 0;
            InicializarTemporizador();
            Saludo();
        }

        private void InicializarTemporizador()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(300);
            _timer.Tick += Bienvenida;
            _timer.Start();
        }

        private void Saludo() {
            stackLogin.Children.Clear();
            userControls.uMensaje.uBienvenida mensaje = new userControls.uMensaje.uBienvenida();
            stackLogin.Children.Add(mensaje);
        }

        private void Bienvenida(object sender, EventArgs e)
        {
            if (tiempoTranscurrido > 10)
            {
                _timer.Stop();
                AgregarLogin();
            }
            tiempoTranscurrido++;
        }

        private void AgregarLogin() {
            stackLogin.Children.Clear();
            userControls.uLogin.uLogin login = new userControls.uLogin.uLogin();
            stackLogin.Children.Add(login);
            login.txtUsuario.Focus();
        }
    }
}
