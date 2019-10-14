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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void GridAutobus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridAdministracion.Children.Clear();
            userControls.userControlABM.UserControlABMAutobus autobuses = new userControls.userControlABM.UserControlABMAutobus();
            GridAdministracion.Children.Add(autobuses);
        }

        private void GridCiudad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridAdministracion.Children.Clear();
            userControls.userControlABM.userControlABMCiudad ciudades = new userControls.userControlABM.userControlABMCiudad();
            GridAdministracion.Children.Add(ciudades);
        }

        private void GridUsuario_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridAdministracion.Children.Clear();
            userControls.userControlABM.UserControlABMUsuario usuarios = new userControls.userControlABM.UserControlABMUsuario();
            GridAdministracion.Children.Add(usuarios);
        }
    }
}
