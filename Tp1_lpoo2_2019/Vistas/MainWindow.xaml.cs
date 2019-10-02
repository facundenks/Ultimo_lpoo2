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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Usuario oUsuario = new Usuario();

        public Usuario OUsuario
        {
            get { return oUsuario; }
            set { oUsuario = value; }
        }

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            validar();
        }

        private void validar()
        {
            if (oUsuario.rol_codigo == 1)
            {
                vent.Visibility = Visibility.Visible;
                ges.Visibility = Visibility.Hidden;
            }
            else {
                if (oUsuario.rol_codigo == 2)
                {
                    vent.Visibility = Visibility.Hidden;
                    ges.Visibility = Visibility.Visible;
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuItem_Cliente(object sender, RoutedEventArgs e)
        {
            formCliente cleinteForm = new formCliente();
            cleinteForm.Show();
        }

        private void MenuItem_Autobus(object sender, RoutedEventArgs e)
        {
            formAutobus autobusForm = new formAutobus();
            autobusForm.Show();
        }

        private void MenuItem_Pasaje(object sender, RoutedEventArgs e)
        {
            formVenta ventaForm = new formVenta();
            ventaForm.Show();
        }
    }
}
