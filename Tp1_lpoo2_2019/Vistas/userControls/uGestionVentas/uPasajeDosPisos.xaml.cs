﻿using System;
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
using System.Windows.Controls.Primitives;

namespace Vistas.userControls.uGestionVentas
{
    /// <summary>
    /// Lógica de interacción para uPasajeDosPisos.xaml
    /// </summary>
    public partial class uPasajeDosPisos : UserControl
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

        private bool band = false;

        public bool Band
        {
            get { return band; }
            set { band = value; }
        }

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

        private int codigoEmpresa;

        public int CodigoEmpresa
        {
            get { return codigoEmpresa; }
            set { codigoEmpresa = value; }
        }

        private int pisos;

        public int Pisos
        {
            get { return pisos; }
            set { pisos = value; }
        }

        public uPasajeDosPisos()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            oServicio = _servicioRepositorio.buscarServicio(codigoServicio);
            oAutobus = _autobusRepositorio.buscarAutobus(Convert.ToInt32(oServicio.aut_codigo));
            codigoAutobus = oAutobus.aut_codigo;
            capacidad = (int)oAutobus.aut_capacidad;
            cargarAsientos(capacidad);
            contadorDeAsientos();
            if(band){
                scrol.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrol.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }

        private void cargarAsientos(int cantAsientos)
        {
            int cantidadAsientos = cantAsientos;

            int contadorAsientos = 1;
            Boolean bandera = false;
            for (int i = 1; i <= 48 / 2; i++)
            {
                if (!bandera)
                    stackColumna2.Children.Add(generarDosAsientos(contadorAsientos));
                else
                    stackColumna1.Children.Add(generarDosAsientos(contadorAsientos));

                bandera = !bandera;

                contadorAsientos += 2;
            }
            
            int cantidadPlantaBaja = cantidadAsientos - 48;

            Boolean bandera1 = false;
            Boolean bandera2 = false;
            int j = 1;
            while(j<cantidadPlantaBaja){
                if (!bandera1)
                {
                    stackColumna4.Children.Add(generarDosAsientos(contadorAsientos));
                    j += 2;
                }
                else
                {
                    stackColumna3.Children.Add(generarUnAsiento(contadorAsientos));
                    bandera2 = true;
                    j += 1;
                }

                bandera1 = !bandera1;
                if (bandera2)
                {
                    contadorAsientos += 1;
                    bandera2 = false;
                }
                else
                {
                    contadorAsientos += 2;
                }
            }
         
            if (cantidadAsientos % 2 == 1)
            {
                if (!bandera1)
                    stackColumna4.Children.Add(generarUnAsiento(contadorAsientos));
                else
                    stackColumna3.Children.Add(generarUnAsiento(contadorAsientos));
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

            if (_servicioRepositorio.servicioConVentas(oServicio.ser_codigo) == true)
            {

                Pasaje oPasaje = _pasajeRepositorio.traerAsiento(numeroAsiento, oServicio.ser_codigo);

                if (oPasaje != null)
                {
                    Cliente oCliente = new Cliente();
                    oCliente = _clienteRepositorio.buscarCliente(oPasaje.cli_dni);

                    botonAsiento.Background = Brushes.Red;
                    ToolTip tt = new ToolTip();
                    tt.Content = "Cliente: " + oCliente.cli_nombre + " " + oCliente.cli_apellido
                        + "\nDNI: " + oCliente.cli_dni
                        + "\nTelefono: " + oCliente.cli_telefono
                        + "\nEmail: " + oCliente.cli_email;
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
                MessageBox.Show("Asiento no Disponible.", "Venta de Pasaje", MessageBoxButton.OK, MessageBoxImage.Information);
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
                venta.Pisos = pisos;
                gridPrincipalPasajes.Children.Add(venta);
            }
        }

        //metodo que obtiene la cantidad de asientos libres
        private void contadorDeAsientos()
        {
            asientoLibre = capacidad - asientoOcupado;
            label1.Content = asientoLibre + " Asientos Libres";
            label2.Content = asientoOcupado + " Asientos Ocupados";
        }

    }
}