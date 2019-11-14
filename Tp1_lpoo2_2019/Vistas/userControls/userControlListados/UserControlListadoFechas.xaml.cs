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
using ClasesBase.DAO.Repositorio;

namespace Vistas.userControls.userControlListados
{
    /// <summary>
    /// Interaction logic for UserControlListadoFechas.xaml
    /// </summary>
    public partial class UserControlListadoFechas : UserControl
    {
        List<ClassVentas> oVenta = new List<ClassVentas>();
        ServicioRepositorio _ServicioRepositorio = new ServicioRepositorio();
        List<ObjetoService> contadorArreglo;

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
            obtenerCantidadServicios();
            cantidad= oVenta.Count.ToString();
            total = OVenta.Sum(x => Convert.ToDouble(x.PasajePrecio)).ToString();
            Servicio s = _ServicioRepositorio.buscarServicio(buscarServicioQueMasSeRepite());
            mostrarHoraFormateada(s);
            txtCantidad.Text = Convert.ToString(cantidad);
            txtMontoTotal.Text = Convert.ToString(total);
            txtMayorHorario.Text = Convert.ToString(horario);
        }

        //metodo para mostrar la hora formateada
        private void mostrarHoraFormateada(Servicio s)
        {
            int hora = Convert.ToDateTime(s.ser_fecha).Hour;
            int minutos = Convert.ToDateTime(s.ser_fecha).Minute;

            if (hora == 0 && minutos == 0)
            {
                horario = hora + "0:0" + minutos;
            }
            else
            {
                horario = hora + ":" + minutos;
            }
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

        //metodo con el cual se obtiene los servicios y la cantidad que se repite c/u
        private void obtenerCantidadServicios()
        {
            contadorArreglo = new List<ObjetoService>();
            
            List<Servicio> servicios = _ServicioRepositorio.listarServicios();
            
            foreach (Servicio s in servicios)
            {
                if (existeServicio(s.ser_codigo))
                {
                    ObjetoService oObjetoService = new ObjetoService();
                    oObjetoService.CodigoServicio = s.ser_codigo;

                    foreach (ClassVentas cv in oVenta)
                    {
                        if (Convert.ToString(oObjetoService.CodigoServicio).Equals(cv.ServicioCodigo))
                        {
                            oObjetoService.MasPasajeVendido += 1;
                        }
                    }
                    contadorArreglo.Add(oObjetoService);    
                }   
            }
        }

        //metodo que devuelve el IdServicio que mas se repite
        private int buscarServicioQueMasSeRepite()
        {
            int numeroServicio = 0;
            int max = contadorArreglo[0].MasPasajeVendido;
            for (int i = 0; i < contadorArreglo.Count; i++ )
            {
                if(max <= contadorArreglo[i].MasPasajeVendido){
                    max = contadorArreglo[i].MasPasajeVendido;
                    numeroServicio = contadorArreglo[i].CodigoServicio;
                }
            }
            return numeroServicio;
        }

        //Metodo que devuelve un booleano cuando el IDservicio de la bd existe en la lista filtrada 
        private Boolean existeServicio(int codigoServicio)
        {
            Boolean band = false;
            foreach (ClassVentas cv in oVenta)
            {
                if (codigoServicio == Convert.ToInt32(cv.ServicioCodigo))
                {
                    band = true;
                }
            }
            return band;
        }
    }
}
