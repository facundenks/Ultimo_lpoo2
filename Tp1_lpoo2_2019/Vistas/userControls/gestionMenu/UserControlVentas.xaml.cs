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

namespace Vistas.userControls.gestionMenu
{
    /// <summary>
    /// Interaction logic for UserControlVentas.xaml
    /// </summary>
    public partial class UserControlVentas : UserControl
    {
        public UserControlVentas()
        {
            InitializeComponent();
        }

        private void GridPasaje_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridGestionVentas.Children.Clear();
            userControls.uGestionVentas.uPasaje asientos = new userControls.uGestionVentas.uPasaje();
            GridGestionVentas.Children.Add(asientos);
        }

        private void GridCliente_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridGestionVentas.Children.Clear();
            userControls.userControlABM.UserControlABMCliente usuarios = new userControls.userControlABM.UserControlABMCliente();
            GridGestionVentas.Children.Add(usuarios);
        }

    }
}
