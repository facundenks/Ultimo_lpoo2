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

namespace Vistas.Document.FixedDoc
{
    /// <summary>
    /// Lógica de interacción para DetallePasaje.xaml
    /// </summary>
    public partial class DetallePasaje : Window
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        TerminalRepositorio _terminalRepositorio = new TerminalRepositorio();
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
        EmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private String dniCliente;

        public String DniCliente
        {
            get { return dniCliente; }
            set { dniCliente = value; }
        }

        private int codigoServicio;

        public int CodigoServicio
        {
            get { return codigoServicio; }
            set { codigoServicio = value; }
        }

        private String fechaOperacion;

        public String FechaOperacion
        {
            get { return fechaOperacion; }
            set { fechaOperacion = value; }
        }

        private int codigoPasaje;

        public int CodigoPasaje
        {
            get { return codigoPasaje; }
            set { codigoPasaje = value; }
        }

        private Double precio;

        public Double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int numeroAsiento;

        public int NumeroAsiento
        {
            get { return numeroAsiento; }
            set { numeroAsiento = value; }
        }

        private int codigoEmpresa;

        public int CodigoEmpresa
        {
            get { return codigoEmpresa; }
            set { codigoEmpresa = value; }
        }

        public DetallePasaje()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Servicio oServicio = _servicioRepositorio.buscarServicio(codigoServicio);
            Terminal oDestino = _terminalRepositorio.buscarTerminal((int)oServicio.ter_codigo_destino);
            Terminal oOrigen = _terminalRepositorio.buscarTerminal((int)oServicio.ter_codigo_origen);
            Autobus oAutobus = _autobusRepositorio.buscarAutobus((int)oServicio.aut_codigo);
            Empresa oEmpresa = _empresaRepositorio.buscarEmpresa((int)codigoEmpresa);

            txtEmplesa.Text = oEmpresa.emp_nombre;
            txtDireccion.Text = oEmpresa.emp_direccion;
            txtTelefono.Text = oEmpresa.emp_telefono;
            txtEmail.Text = oEmpresa.emp_email;
            txtFechaOperacion.Text = Convert.ToString(fechaOperacion);
            txtNumeroPasaje.Text = Convert.ToString(codigoPasaje);
            txtfechaHoraSalida.Text = Convert.ToString(oServicio.ser_fecha);
            txtOrigen.Text = oOrigen.ter_nombre;
            txtDestino.Text = oDestino.ter_nombre;
            txtTipoServicio.Text = oAutobus.aut_tiposervicio;
            txtPrecio.Text = Convert.ToString(precio);
            txtButaca.Text = Convert.ToString(numeroAsiento);
            txtCliente.Text = _clienteRepositorio.buscarCliente(dniCliente).cli_nombre +" "+
                              _clienteRepositorio.buscarCliente(dniCliente).cli_apellido;
            txtUsuario.Text = nombreUsuario;
        }
    }
}
