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

        private void GridUsuario_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GridAdministracion.Children.Clear();
            userControls.userControlABM.UserControlABMCliente usuarios = new userControls.userControlABM.UserControlABMCliente();
            GridAdministracion.Children.Add(usuarios);
        }
<<<<<<< HEAD

        private void GridCiudad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
=======
>>>>>>> 3b4e606bc4b1c4cace3586e3350250462607fa27
    }
}
