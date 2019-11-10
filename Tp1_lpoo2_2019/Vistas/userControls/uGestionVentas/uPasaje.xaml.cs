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
    public partial class uPasaje : UserControl
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        PasajeRepositorio _pasajeRepositorio = new PasajeRepositorio();
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
        Servicio oServicio = new Servicio();
        Autobus oAutobus = new Autobus();
        int asientoLibre = 0, asientoOcupado = 0;
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

        private int codigoEmpresa;

        public int CodigoEmpresa
        {
            get { return codigoEmpresa; }
            set { codigoEmpresa = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            oServicio = _servicioRepositorio.buscarServicio(codigoServicio);
            oAutobus = _autobusRepositorio.buscarAutobus(Convert.ToInt32(oServicio.aut_codigo));
            codigoAutobus = oAutobus.aut_codigo;
            capacidad = (int)oAutobus.aut_capacidad;
            cargarAsientos(capacidad);
            contadorDeAsientos();
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

                Pasaje oPasaje = _pasajeRepositorio.traerAsiento(numeroAsiento,oServicio.ser_codigo);

                if (oPasaje != null)
                {
                    Cliente oCliente = new Cliente(); 
                    oCliente = _clienteRepositorio.buscarCliente(oPasaje.cli_dni);

                    botonAsiento.Background = Brushes.Red;
                    ToolTip tt = new ToolTip();
                    tt.Content = "Cliente: " + oCliente.cli_nombre + " " + oCliente.cli_apellido 
                        +"\nDNI: " + oCliente.cli_dni
                        +"\nTelefono: "+ oCliente.cli_telefono
                        +"\nEmail: "+ oCliente.cli_email;
                    botonAsiento.ToolTip = tt;
                    asientoOcupado++;
                }
                else
                {
                    botonAsiento.Cursor = Cursors.Hand;
                }
                
            }
            return botonAsiento;
        }

        private void btnAsiento_Click(object sender, RoutedEventArgs e)
        {
            Button asiento = ((Button)sender);
            if (asiento.Background == Brushes.Red)
            {
                if (MessageBox.Show("Dar de Baja el Pasaje", "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    DateTime fechaServicio = Convert.ToDateTime(oServicio.ser_fecha);
                    DateTime fechaBajaPasaje = DateTime.Now;
                    bajaPasaje(fechaServicio, fechaBajaPasaje, asiento);
                }
            }
            else
            {
                MessageBox.Show("Asiento Disponible", "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information);
                
                asiento.Background = Brushes.Red;
                gridPrincipalPasajes.Children.Clear();
                userControls.userControlABM.UserControlAVenta venta = new userControls.userControlABM.UserControlAVenta();
                venta.CodigoAutobus = codigoAutobus;
                venta.NumeroAsietnto = Convert.ToInt32(asiento.Content);
                venta.ServicioCodigo = oServicio.ser_codigo;
                venta.NombreUsuario = nombreUsuario;
                venta.CodigoEmpresa = codigoEmpresa;
                gridPrincipalPasajes.Children.Add(venta);
            }
        }

        private void bajaPasaje(DateTime fechaServicio, DateTime fechaBaja, Button button)
        {
            if (fechaServicio > fechaBaja)
            {
                Pasaje oPasaje = _pasajeRepositorio.traerAsiento(Convert.ToInt32(button.Content), oServicio.ser_codigo);
                _pasajeRepositorio.removePasaje(oPasaje.pas_codigo);
                gridPrincipalPasajes.Children.Clear();
                userControls.uGestionVentas.uPasaje pasajes = new userControls.uGestionVentas.uPasaje();
                pasajes.CodigoServicio = oServicio.ser_codigo;
                pasajes.NombreUsuario = nombreUsuario;
                //pasajes.CodigoEmpresa = oServicio.; 
                gridPrincipalPasajes.Children.Add(pasajes);
            }
            else
            {
                MessageBox.Show("No se puede dar de baja el Pasaje, el Servicio ya fue realizado", "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //metodo que obtiene la cantidad de asientos libres
        private void contadorDeAsientos()
        {
            asientoLibre = capacidad - asientoOcupado;
            label1.Content =  asientoLibre+" Asientos Libres";
            label2.Content = asientoOcupado + " Asientos Ocupados";
        }
    }
}
