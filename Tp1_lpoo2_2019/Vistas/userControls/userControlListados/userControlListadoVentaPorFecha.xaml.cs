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

namespace Vistas.userControls.userControlListados
{
    /// <summary>
    /// Interaction logic for userControlListadoVentaPorFecha.xaml
    /// </summary>
    public partial class userControlListadoVentaPorFecha : UserControl
    {
        private CollectionViewSource vistaColeccionFiltradaPorFecha;
        public userControlListadoVentaPorFecha()
        {
            InitializeComponent();
            vistaColeccionFiltradaPorFecha = Resources["Vista_Ventas"] as CollectionViewSource;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltradaPorFecha != null)
            {
                //Se invoca al metodo eventVistaUser a medida que se escriba en el textBox
                vistaColeccionFiltradaPorFecha.Filter += eventVistaVenta_filter;
            }
        }

        private void eventVistaVenta_filter(object sender, FilterEventArgs e)
        {
            ClasesBase.ClassVentas ventas = e.Item as ClasesBase.ClassVentas;

            try
            {

                /*if (ventas.PasajeFec.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }*/
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*Document.Doc.VentasDoc venDoc = new Document.Doc.VentasDoc();
            List<ClasesBase.ClassVentas> ventas = new List<ClasesBase.ClassVentas>();
            /*for (int i = 0; i < Ventas.Items.Count; i++)
            {
                ventas.Add((ClasesBase.ClassVentas.Items[i]));
            }
<<<<<<< HEAD
            venDoc.Usuario = ventas;*/
            venDoc.Show();
=======
            venDoc.Usuario = ventas;
            venDoc.Show();*/
>>>>>>> 0fa3ba2f4cb8b8542de356b1ddf3b80fb97ad8af
        }
    }
}
