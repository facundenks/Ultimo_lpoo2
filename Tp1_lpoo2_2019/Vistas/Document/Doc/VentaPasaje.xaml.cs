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

        public VentaPasaje()
        {
            InitializeComponent();
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            ServicioRepositorio servicio = new ServicioRepositorio();
            PasajeRepositorio pasaje = new PasajeRepositorio();

            Servicio oServicio = new Servicio();

            oServicio.aut_codigo = CodigoAutobus;
            oServicio.ser_estado = "Pagado";
            oServicio.ser_fecha = new DateTime();
            oServicio.ter_codigo_destino = 1;
            oServicio.ter_codigo_origen = 2;

            servicio.AgrgarServicio(oServicio);

            Pasaje oPasaje = new Pasaje();

            oPasaje.cli_dni = txtDniCliente.Text;
            oPasaje.pas_asiento = Convert.ToInt32(txtAsiento.Text);
            oPasaje.pas_precio = Convert.ToDecimal(txtPrecio.Text);
            oPasaje.pas_fechaHora = new DateTime();
            oPasaje.ser_codigo = servicio.ultimoServicio().ser_codigo;

        }
    }
}
