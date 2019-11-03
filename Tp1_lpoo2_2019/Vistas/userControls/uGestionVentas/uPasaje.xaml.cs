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

namespace Vistas.userControls.uGestionVentas
{
    /// <summary>
    /// Lógica de interacción para uPasaje.xaml
    /// </summary>
    public partial class uPasaje : UserControl
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        PasajeRepositorio _pasajeRepositorio = new PasajeRepositorio();
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio(); 
        Servicio oServicio = new Servicio();
        Autobus oAutobus = new Autobus();
        int capacidad = 0;
        int codigoAutobus = 0;

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private int codigoServicio;

        public int CodigoServicio
        {
            get { return codigoServicio; }
            set { codigoServicio = value; }
        }

        public uPasaje()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            oServicio = _servicioRepositorio.buscarServicio(codigoServicio);
            oAutobus = _autobusRepositorio.buscarAutobus((int)oServicio.aut_codigo);
            codigoAutobus = oAutobus.aut_codigo;
            capacidad = (int)oAutobus.aut_capacidad;
            cargarAsientos(capacidad);
        }

        private void cargarAsientos(int cantAsientos)
        {
            
            int cantidadAsientos = cantAsientos;

            int contadorAsientos = 1;
            Boolean bandera = false;
            for (int i = 1; i <= cantidadAsientos / 2; i++)
            {
                if (!bandera)
                    grdColumna2.Children.Add(generarDosAsientos(contadorAsientos));
                else
                    grdColumna1.Children.Add(generarDosAsientos(contadorAsientos));

                bandera = !bandera;
                contadorAsientos += 2;
            }
            if (cantidadAsientos % 2 == 1)
            {
                if (!bandera)
                    grdColumna2.Children.Add(generarUnAsiento(contadorAsientos));
                else
                    grdColumna1.Children.Add(generarUnAsiento(contadorAsientos));
            }
        }

        private StackPanel generarUnAsiento(int numeroAsiento)
        {
            StackPanel panelAsientos = new StackPanel();
            panelAsientos.Orientation = Orientation.Horizontal;
            panelAsientos.Children.Add(generarAsientoVacio(numeroAsiento));
            return panelAsientos;
        }

        private StackPanel generarDosAsientos(int numeroPrimerAsiento)
        {
            StackPanel panelAsientos = new StackPanel();
            panelAsientos.Orientation = Orientation.Horizontal;
            panelAsientos.Children.Add(generarAsientoVacio(numeroPrimerAsiento));
            panelAsientos.Children.Add(generarAsientoVacio(numeroPrimerAsiento + 1));
            return panelAsientos;
        }

        private Button generarAsientoVacio(int numeroAsiento)
        {
            Button botonAsiento = new Button
            {
                Background = Brushes.Green,
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                Content = numeroAsiento.ToString(),
                Margin = new Thickness(1),
                Width = 50,
                Height = 50,
                FontSize = 15,
                BorderBrush = Brushes.Transparent,
                Name = "btnAsiento_" + numeroAsiento
            };
            botonAsiento.Click += new RoutedEventHandler(btnAsiento_Click);

            if (_servicioRepositorio.servicioConVentas(oServicio.ser_codigo) == true) {

                List<Pasaje> pasajes = new List<Pasaje>();

                pasajes = _pasajeRepositorio.ListaPasajes(oServicio.ser_codigo);

                for (int i = 1; i <= capacidad; i++)
                {
                    foreach (Pasaje item in pasajes)
                    {
                        if (item.pas_asiento == i)
                        {
                            botonAsiento.Background = Brushes.Red;
                        }
                    }
                }
            }
            return botonAsiento;
        }

        private void btnAsiento_Click(object sender, RoutedEventArgs e)
        {
            Button asiento = ((Button)sender);
            if (asiento.Background == Brushes.Red)
            {
                MessageBox.Show("Asiento no Disponible.\n buttonName: \"" + asiento.Name + "\"\nAsiento N°: " + asiento.Content, "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Asiento Disponible, para la reserva de pasaje.\n buttonName: \"" + asiento.Name + "\"\nAsiento N°: " + asiento.Content, "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information);
                Document.Doc.VentaPasaje venta = new Document.Doc.VentaPasaje();
                asiento.Background = Brushes.Red;
                venta.CodigoAutobus = codigoAutobus;
                venta.NumeroAsietnto = Convert.ToInt32(asiento.Content);
                venta.ServicioCodigo = oServicio.ser_codigo;
                venta.NombreUsuario = nombreUsuario;
                venta.Show();
            }
        }

        /**private void vender_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (sender as Button);

            if (bt.Background == Brushes.Green)
            {
                MessageBox.Show("Asiento Disponible, para la reserva de pasaje");
                Document.Doc.VentaPasaje venta = new Document.Doc.VentaPasaje();
                bt.Background = Brushes.Red;
                venta.CodigoAutobus = codigoAutobus;
                venta.NumeroAsietnto = Convert.ToInt32(bt.Content);
                venta.ServicioCodigo = oServicio.ser_codigo;
                venta.NombreUsuario = nombreUsuario;
                venta.Show();
            }
            else
            {
                MessageBox.Show("Asiento no disponible");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            oServicio = _servicioRepositorio.servicioCoche(codigoAutobus);

            if(_servicioRepositorio.servicioConVentas(oServicio.ser_codigo)==true){

                List<Pasaje> pasajes = new List<Pasaje>();

                pasajes = _pasajeRepositorio.ListaPasajes(oServicio.ser_codigo);
       
                for (int i = 1; i <= 40; i++)
                {
                    foreach (Pasaje item in pasajes)
                    {
                        if (item.pas_asiento == i)
                        {
                            asiento(i);
                        }
                    }
                }
            }
        }

        private void asiento(int i) { 
            switch(i){
                case 1: btn1.Background = Brushes.Red;
                    break;
                case 2: btn2.Background = Brushes.Red;
                    break;
                case 3: btn3.Background = Brushes.Red;
                    break;
                case 4: btn4.Background = Brushes.Red;
                    break;
                case 5: btn5.Background = Brushes.Red;
                    break;
                case 6: btn6.Background = Brushes.Red;
                    break;
                case 7: btn7.Background = Brushes.Red;
                    break;
                case 8: btn8.Background = Brushes.Red;
                    break;
                case 9: btn9.Background = Brushes.Red;
                    break;
                case 10: btn10.Background = Brushes.Red;
                    break;
                case 11: btn11.Background = Brushes.Red;
                    break;
                case 12: btn12.Background = Brushes.Red;
                    break;
                case 13: btn13.Background = Brushes.Red;
                    break;
                case 14: btn14.Background = Brushes.Red;
                    break;
                case 15: btn16.Background = Brushes.Red;
                    break;
                case 17: btn17.Background = Brushes.Red;
                    break;
                case 18: btn18.Background = Brushes.Red;
                    break;
                case 19: btn19.Background = Brushes.Red;
                    break;
                case 20: btn20.Background = Brushes.Red;
                    break;
                case 21: btn21.Background = Brushes.Red;
                    break;
                case 22: btn22.Background = Brushes.Red;
                    break;
                case 23: btn23.Background = Brushes.Red;
                    break;
                case 24: btn24.Background = Brushes.Red;
                    break;
                case 25: btn25.Background = Brushes.Red;
                    break;
                case 26: btn26.Background = Brushes.Red;
                    break;
                case 27: btn27.Background = Brushes.Red;
                    break;
                case 28: btn28.Background = Brushes.Red;
                    break;
                case 29: btn29.Background = Brushes.Red;
                    break;
                case 30: btn30.Background = Brushes.Red;
                    break;
                case 31: btn31.Background = Brushes.Red;
                    break;
                case 32: btn32.Background = Brushes.Red;
                    break;
                case 33: btn33.Background = Brushes.Red;
                    break;
                case 34: btn34.Background = Brushes.Red;
                    break;
                case 35: btn35.Background = Brushes.Red;
                    break;
                case 36: btn36.Background = Brushes.Red;
                    break;
                case 37: btn37.Background = Brushes.Red;
                    break;
                case 38: btn38.Background = Brushes.Red;
                    break;
                case 39: btn39.Background = Brushes.Red;
                    break;
                case 40: btn40.Background = Brushes.Red;
                    break;
            }
        }**/
    }
}
