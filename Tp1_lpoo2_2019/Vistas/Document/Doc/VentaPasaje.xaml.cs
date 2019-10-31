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
using System.Windows.Shapes;
using ClasesBase;
using ClasesBase.DAO.Repositorio;

namespace Vistas.Document.Doc
{
    /// <summary>
    /// Interaction logic for VentaPasaje.xaml
    /// </summary>
    public partial class VentaPasaje : Window
    {
        DateTime day = DateTime.Today;
        PasajeRepositorio _pasajeRepositorio = new PasajeRepositorio();
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private int codigoAutobus;

        public int CodigoAutobus
        {
            get { return codigoAutobus; }
            set { codigoAutobus = value; }
        }

        private int numeroAsietnto;

        public int NumeroAsietnto
        {
            get { return numeroAsietnto; }
            set { numeroAsietnto = value; }
        }

        private int servicioCodigo;

        public int ServicioCodigo
        {
            get { return servicioCodigo; }
            set { servicioCodigo = value; }
        }

        public VentaPasaje()
        {
            InitializeComponent();
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            if (txtDniCliente.Text != "" && txtPrecio.Text != "")
            {
                if (MessageBox.Show("Confirmar Operacion", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    PasajeRepositorio pasaje = new PasajeRepositorio();

                    Pasaje oPasaje = new Pasaje();

                    oPasaje.cli_dni = txtDniCliente.Text;
                    oPasaje.pas_asiento = Convert.ToInt32(txtAsiento.Text);
                    oPasaje.pas_precio = Convert.ToDecimal(txtPrecio.Text);
                    oPasaje.pas_fechaHora = day;
                    oPasaje.ser_codigo = servicioCodigo;

                    pasaje.AgrgarPasaje(oPasaje);

                    Document.FixedDoc.DetallePasaje detalle = new Document.FixedDoc.DetallePasaje();
                    detalle.CodigoServicio = servicioCodigo;
                    detalle.FechaOperacion = txtFecha.Text;
                    detalle.Precio = Convert.ToDouble(txtPrecio.Text);
                    detalle.NumeroAsiento = Convert.ToInt32(txtAsiento.Text);
                    detalle.CodigoPasaje = _pasajeRepositorio.ultimoPasaje().pas_codigo;
                    detalle.DniCliente = txtDniCliente.Text;
                    detalle.NombreUsuario = nombreUsuario;
                    detalle.Show();
                    Close();
                }
            }
            else {
                MessageBox.Show("Completar todos los campos", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtAsiento.Text = Convert.ToString(NumeroAsietnto);
            txtFecha.Text = day.ToString("d");
            list_clientes.ItemsSource = _clienteRepositorio.listarClientes();
        }

        private void list_clientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cliente cliente = list_clientes.SelectedItem as Cliente;

            txtDniCliente.Text = cliente.cli_dni; 
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
