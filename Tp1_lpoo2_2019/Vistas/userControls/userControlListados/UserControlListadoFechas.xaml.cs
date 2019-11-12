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
    /// Interaction logic for UserControlListadoFechas.xaml
    /// </summary>
    public partial class UserControlListadoFechas : UserControl
    {
        List<ClassVentas> oVenta = new List<ClassVentas>();


        public List<ClassVentas> OVenta
        {
            get { return oVenta; }
            set { oVenta = value; }
        }
        
        public UserControlListadoFechas()
        {            
            InitializeComponent();
         }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Ventas.ItemsSource = oVenta;

        }
    }
}
