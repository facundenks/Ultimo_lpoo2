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
    /// Interaction logic for userControlListadoVentaPorFecha.xaml
    /// </summary>
    public partial class userControlListadoVentaPorFecha : UserControl
    {
        ClassTrabajarVentaString ventas = new ClassTrabajarVentaString();
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

                if (ventas.ClienteDNI.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase) || ventas.AutobusMatricula.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase)
                    || ventas.NombreEmpresa.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Document.Doc.VentaDoc usuDoc = new Document.Doc.VentaDoc();
            List<ClassVentas> vent = new List<ClassVentas>();
            for (int i = 0; i < Ventas.Items.Count; i++)
            {
                vent.Add((ClassVentas)Ventas.Items[i]);
            }
            usuDoc.Ventas = vent;
            usuDoc.Show();

        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime inicio = Convert.ToDateTime(dtpInicio.ToString());
            DateTime fin = Convert.ToDateTime(dtpFin.ToString());


            if (inicio <= fin)
            {
                GridVentas.Children.Clear();
                userControls.userControlListados.UserControlListadoFechas ventasFecha = new userControls.userControlListados.UserControlListadoFechas();
                ventasFecha.OVenta = ventas.listarVentasPorFecha(inicio, fin);
                String cantidad = ventasFecha.OVenta.Count.ToString();
                String total = ventasFecha.OVenta.Sum(x => Convert.ToDouble(x.PasajePrecio)).ToString();
                GridVentas.Children.Add(ventasFecha);
            }
            else
            {
                MessageBox.Show("Inicio no puede ser mayor que Fin");
            }

        }

        private List <ClassVentas> filtro (){
            
            List<ClassVentas> ventas = new List<ClasesBase.ClassVentas>();

            for (int i = 0; i < Ventas.Items.Count; i++)
            {
                ventas.Add((ClassVentas)Ventas.Items[i]);
            }

            return ventas;
        }
            
    }
}
