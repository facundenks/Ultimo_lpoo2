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
using System.Text.RegularExpressions;
using ClasesBase;
using ClasesBase.DAO.Repositorio;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Interaction logic for UserControlABMUsuario.xaml
    /// </summary>
    public partial class UserControlABMCliente : UserControl
    {
        Cliente oCliente = new Cliente();
        ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

        public UserControlABMCliente()
        {
            InitializeComponent();
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
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

                    if (MessageBox.Show("Mensaje", "Guardar Cliente", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        oCliente.cli_dni = txtDNI.Text;
                        oCliente.cli_nombre = txtNombre.Text;
                        oCliente.cli_apellido = txtApellido.Text;
                        oCliente.cli_email = txtEmail.Text;
                        oCliente.cli_telefono = txtTelefono.Text;

                        _clienteRepositorio.AgrgarCliente(oCliente);

                        limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Completar todos los campos");
                }
            }
        }

        private void limpiar()
        {
            txtApellido.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void btnLimpiarUsuario_Click_1(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
    }
}
