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
using System.Text.RegularExpressions;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Lógica de interacción para UserControlAMBUsuarioSinTabla.xaml
    /// </summary>
    public partial class UserControlAMBUsuarioSinTabla : UserControl
    {
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();
        Cliente oCliente = new Cliente();

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

        public UserControlAMBUsuarioSinTabla()
        {
            InitializeComponent();
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                if (txtApellido.Text != "" && txtDNI.Text != "" && txtEmail.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "")
                {

                    if (MessageBox.Show("Guardar Cliente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        oCliente.cli_dni = txtDNI.Text;
                        oCliente.cli_nombre = txtNombre.Text;
                        oCliente.cli_apellido = txtApellido.Text;
                        oCliente.cli_email = txtEmail.Text;
                        oCliente.cli_telefono = txtTelefono.Text;

                        _clienteRepositorio.AgrgarCliente(oCliente);

                        gridPrincipalUsuarioSinTabla.Children.Clear();
                        userControls.userControlABM.UserControlAVenta venta = new userControls.userControlABM.UserControlAVenta();
                        venta.DniCliente = txtDNI.Text;
                        venta.NombreUsuario = nombreUsuario;
                        venta.NumeroAsietnto = numeroAsietnto;
                        venta.CodigoAutobus = codigoAutobus;
                        venta.CodigoEmpresa = codigoEmpresa;
                        venta.ServicioCodigo = servicioCodigo;
                        venta.Pisos = pisos;
                        gridPrincipalUsuarioSinTabla.Children.Add(venta);
                    }
                }
                else
                {
                    MessageBox.Show("Completar todos los campos");
                }
            }
        }
    }
}
