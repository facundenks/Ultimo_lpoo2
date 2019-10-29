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
            PasajeRepositorio pasaje = new PasajeRepositorio();

            Pasaje oPasaje = new Pasaje();

            oPasaje.cli_dni = txtDniCliente.Text;
            oPasaje.pas_asiento = Convert.ToInt32(txtAsiento.Text);
            oPasaje.pas_precio = Convert.ToDecimal(txtPrecio.Text);
            oPasaje.pas_fechaHora = new DateTime();
            oPasaje.ser_codigo = servicioCodigo;

            pasaje.AgrgarPasaje(oPasaje);
            MessageBox.Show("Pasaje agregado");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAsiento.Text = Convert.ToString(NumeroAsietnto);
        }
    }
}
