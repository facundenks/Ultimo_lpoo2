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

namespace Vistas.userControls.userControlListados
{
    /// <summary>
    /// Lógica de interacción para userControlListadoAutobus.xaml
    /// </summary>
    public partial class userControlListadoAutobus : UserControl
    {
        public userControlListadoAutobus()
        {
            InitializeComponent();
        }

        private void Autobuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GridAutobusesMain.Children.Clear();
            userControls.uGestionVentas.uPasaje pasajes = new userControls.uGestionVentas.uPasaje();
            GridAutobusesMain.Children.Add(pasajes);
        }
    }
}
