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

namespace Vistas.userControls.uGestionVentas
{
    /// <summary>
    /// Lógica de interacción para uPasaje.xaml
    /// </summary>
    public partial class uPasaje : UserControl
    {
        private int codigoAutobus;

        public int CodigoAutobus
        {
            get { return codigoAutobus; }
            set { codigoAutobus = value; }
        }

        public uPasaje()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        
        }

        private void vender_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (sender as Button);

            MessageBox.Show(""+bt.Content);

            if (bt.Background == Brushes.Green)
            {
                
                MessageBox.Show("Asiento Disponible, para la reserva de pasaje");
                Document.Doc.VentaPasaje venta = new Document.Doc.VentaPasaje();
                venta.CodigoAutobus = codigoAutobus;
                venta.Show();
            }
            else
            {
                MessageBox.Show("Asiento no disponible");
            }
        }
    }
}
