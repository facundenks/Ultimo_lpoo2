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
using System.Windows.Threading;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private Usuario usuario;
        
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
            lblHora.Visibility = Visibility.Visible;
            lblFecha.Visibility = Visibility.Visible;
            lblUser.Visibility = Visibility.Visible;
            stack_Gestion.Visibility = Visibility.Visible;
            stack_Ventas.Visibility = Visibility.Visible;
            validar();
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
            lblHora.Visibility = Visibility.Collapsed;
            lblFecha.Visibility = Visibility.Collapsed;
            lblUser.Visibility = Visibility.Collapsed;
            stack_Gestion.Visibility = Visibility.Collapsed;
            stack_Ventas.Visibility = Visibility.Collapsed;

        }

        private void validar()
        {
            if (Usuario.rol_codigo == 1)
            {
                stack_Ventas.Visibility = Visibility.Visible;
                stack_Gestion.Visibility = Visibility.Hidden;
            }
            else
            {
                if (Usuario.rol_codigo == 2)
                {
                    stack_Ventas.Visibility = Visibility.Hidden;
                    stack_Gestion.Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblFecha.Content = DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("es-ES"));
            DispatcherTimer disp = new DispatcherTimer();
            disp.Interval = TimeSpan.FromMilliseconds(500);
            disp.Tick += ponerHora;
            disp.Start();
            lblUser.Content = Usuario.usu_nombreUsuario;
            btnOpenMenu_Click(null, null);
        }

        private void stack_Ventas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gridprincipal.Children.Clear();
            userControls.gestionMenu.UserControlVentas menuVentas = new userControls.gestionMenu.UserControlVentas();
            Gridprincipal.Children.Add(menuVentas);
        }

        private void stack_Gestion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gridprincipal.Children.Clear();
            userControls.gestionMenu.UserControl1 menuGestion = new userControls.gestionMenu.UserControl1();
            menuGestion.UserName = usuario.usu_nombreUsuario;
            Gridprincipal.Children.Add(menuGestion);
        }

        private void ponerHora(object sender, EventArgs e)
        {
            lblHora.Content = DateTime.Now.ToString("T");
        }
    }
}
