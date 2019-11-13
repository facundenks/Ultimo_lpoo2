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
        String total;

        public String Total
        {
            get { return total; }
            set { total = value; }
        }
        String cantidad;

        public String Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        String horario;

        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        
        
        public UserControlListadoFechas()
        {            
            InitializeComponent();
         }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Ventas.ItemsSource = oVenta;
            cantidad= oVenta.Count.ToString();
            total = OVenta.Sum(x => Convert.ToDouble(x.PasajePrecio)).ToString();
            //horario = OVenta.Max(x=>Convert.ToDateTime(x.ServicioFec.));
            
            txtCantidad.Text = Convert.ToString(cantidad);
            txtMontoTotal.Text = Convert.ToString(total);
            txtHorarios.Text = Convert.ToString(horario);
            
            //String cantidad = Ventas.Items.Count.ToString();
            //String total = OVenta.Sum(x => Convert.ToDouble(x.PasajePrecio)).ToString();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Document.Doc.VentaFiltradaPorFecha usuDoc = new Document.Doc.VentaFiltradaPorFecha();
            List<ClassVentas> vents = new List<ClassVentas>();
            for (int i = 0; i < Ventas.Items.Count; i++)
            {
                vents.Add((ClassVentas)Ventas.Items[i]);
            }
            usuDoc.Ventas = vents;
            usuDoc.Show();
        }
    }
}
