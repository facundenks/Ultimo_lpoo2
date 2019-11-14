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
            deshabilitarBotones();
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

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un email.", "Gestion Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Debe ingresar un email Valido.", "Gestion Cliente", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                if (txtApellido.Text != "" && txtDNI.Text != "" && txtEmail.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "")
                {
                    if (validarDNI(txtDNI.Text))
                    {
                        MessageBox.Show("El DNI ya existe en el sistema", "Gestion Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                        limpiar();
                    }
                    else
                    {
                        if (MessageBox.Show("Guardar Cliente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            oCliente.cli_dni = txtDNI.Text;
                            oCliente.cli_nombre = txtNombre.Text;
                            oCliente.cli_apellido = txtApellido.Text;
                            oCliente.cli_email = txtEmail.Text;
                            oCliente.cli_telefono = txtTelefono.Text;

                            _clienteRepositorio.AgrgarCliente(oCliente);

                            list_clientes.ItemsSource = _clienteRepositorio.listarClientes();
                            MessageBox.Show("Cliente dado de alta", "Gestion Clientes", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            limpiar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Gestion Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Boolean validarDNI(String dni)
        {
            Boolean band = false;
            List<Cliente> clientes = _clienteRepositorio.listarClientes();
            foreach (Cliente c in clientes)
            {
                if (c.cli_dni.Equals(dni))
                {
                    band = true;
                }
            }

            return band;
        }

        private void limpiar()
        {
            txtApellido.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            deshabilitarBotones();
        }

        private void btnLimpiarUsuario_Click_1(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void Line_Loaded(object sender, RoutedEventArgs e)
        {
            limpiar();
            list_clientes.ItemsSource = _clienteRepositorio.listarClientes();
            
        }

        private void list_clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var v = ((Cliente)list_clientes.SelectedItem);
            if (v != null)
            {
                txtDNI.IsEnabled = false;
                txtDNI.Text = v.cli_dni.ToString();
                txtNombre.Text = v.cli_nombre.ToString();
                txtApellido.Text = v.cli_apellido.ToString();
                txtTelefono.Text = v.cli_telefono.ToString();
                txtEmail.Text = v.cli_email.ToString();
                habilitarBotones();
            } 
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDNI.Text != "")
            {
                Cliente oCliente = new Cliente();
                oCliente = _clienteRepositorio.buscarCliente(txtDNI.Text);
                if (oCliente != null)
                {
                    txtDNI.IsEnabled = false;
                    txtNombre.Text = oCliente.cli_nombre.ToString();
                    txtApellido.Text = oCliente.cli_apellido.ToString();
                    txtTelefono.Text = oCliente.cli_telefono.ToString();
                    txtEmail.Text = oCliente.cli_email.ToString();
                }
                else {
                    txtDNI.IsEnabled = true;
                }
            }
            else
            {
                txtDNI.IsEnabled = true;
                limpiar();
            }
        }

        private void btnModificarUsuario_Click_1(object sender, RoutedEventArgs e)
        {
            Cliente unCliente = new Cliente();

            var resultado = MessageBox.Show("¿Modificar Cliente?", "Gestion Cliente", MessageBoxButton.OK, MessageBoxImage.Question);
            if (resultado.Equals(MessageBoxResult.OK))
            {
                unCliente.cli_dni = Convert.ToString(txtDNI.Text);
                unCliente.cli_nombre = Convert.ToString(txtNombre.Text);
                unCliente.cli_apellido = Convert.ToString(txtApellido.Text);
                unCliente.cli_telefono = Convert.ToString(txtTelefono.Text);
                unCliente.cli_email = Convert.ToString(txtEmail.Text);

                _clienteRepositorio.modificarCliente(unCliente);

                limpiar();

                list_clientes.ItemsSource = _clienteRepositorio.listarClientes();
            }
        }

        private void deshabilitarBotones()
        {
            btnEliminarUsuario.IsEnabled = false;
            btnModificarUsuario.IsEnabled = false;
        }

        private void habilitarBotones()
        {
            btnEliminarUsuario.IsEnabled = true;
            btnModificarUsuario.IsEnabled = true;
        }
    }
}
