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
    /// Lógica de interacción para userControlListadoServicio.xaml
    /// </summary>
    public partial class userControlListadoServicio : UserControl
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        ClassTrabajarServicioFormat _classTrabajarServicioFormat = new ClassTrabajarServicioFormat();

        private CollectionViewSource vistaColeccionFiltrada;//vista de coleccion filtrada

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public userControlListadoServicio()
        {
            InitializeComponent();
            //Se accede al Recurso CollectionViewSource
            vistaColeccionFiltrada = Resources["Vista_Services"] as CollectionViewSource;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServiciosOrigen(textBox1.Text.ToString());
                }
                else
                {
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServicios();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        

        private void Servicios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassServicioString servicio = Servicios.SelectedItem as ClassServicioString;

            if (servicio == null)
            {
                return;
            }

            if (_servicioRepositorio.buscarServicio(servicio.Ser_codigo) != null)
            {
                GridAutobusesMain.Children.Clear();
                userControls.uGestionVentas.uGestionVentaPrincipal pasajes = new userControls.uGestionVentas.uGestionVentaPrincipal();
                pasajes.CodigoServicio = servicio.Ser_codigo;
                pasajes.NombreUsuario = nombreUsuario;
                pasajes.CodigoEmpresa = servicio.Emp_codigo;
                pasajes.Pisos = servicio.Aut_cantidadPisos;
                GridAutobusesMain.Children.Add(pasajes);
            }
            else
            {
                MessageBox.Show("Servicio no Disponible");
            }
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            DateTime inicio = Convert.ToDateTime(dateFechaInicio.ToString());
            DateTime fin = Convert.ToDateTime(dateFechaFin.ToString());

            if (inicio <= fin)
            {
                if (_classTrabajarServicioFormat.listarServiciosPorFecha(inicio, fin) != null)
                {
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServiciosPorFecha(inicio, fin);
                }
                else {
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServicios();
                }
                
            }
            else {
                MessageBox.Show("Inicio no puede ser mayor que Fin");
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(textBox2.Text != ""){
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServiciosDestino(textBox2.Text.ToString());
                }else{
                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServicios();
                }
                    
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void activarFiltroFecha() { 
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //btnFiltrar.IsEnabled = false;
            dateFechaFin.SelectedDate = DateTime.Today;
            dateFechaInicio.SelectedDate = DateTime.Today;
        }
    }
}
