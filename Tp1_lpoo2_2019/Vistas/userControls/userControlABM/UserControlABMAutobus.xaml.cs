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
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Interaction logic for UserControlABMAutobus.xaml
    /// </summary>
    public partial class UserControlABMAutobus : UserControl
    {
        Autobus oAutobus = new Autobus();
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();
        EmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();
        ServicioRepositorio _ServicioRepositorio = new ServicioRepositorio();
        ObservableCollection<string> list = new ObservableCollection<string>();
        int idGlobal;

        public UserControlABMAutobus()
        {
            InitializeComponent();
            deshabilitarBotones();
            cargar_combo();
        }

        private void txtCapacidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void limpiar()
        {
            txtCapacidad.Clear();
            cmbServicio.SelectedIndex = -1;
            txtPatente.Clear();
            cmbEmpresa.SelectedIndex = -1;
            textBoxPisos.SelectedIndex = -1;
            imagen.Clear();
            foto.Source = new BitmapImage();
        }

        private void btnLimpiarUsuario_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void guardarImagen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                imagen.Text = filename;
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(filename);
                b.EndInit();
                foto.Source = b;
            }
        }

        private void cargar_combo()
        {
            List<Empresa> empresas = _empresaRepositorio.listarEmpresas();
            foreach (Empresa e in empresas)
            {
                list.Add(e.emp_nombre);
            }
            cmbEmpresa.ItemsSource = list;
        }

        private void btnGuardarAutobus_Click(object sender, RoutedEventArgs e)
        {
            if (txtCapacidad.Text != "" && cmbServicio.SelectedIndex != -1 && txtPatente.Text != "")
            {
                var resultado = MessageBox.Show("¿Dar de Alta un Autobus?", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Question);
                if (resultado.Equals(MessageBoxResult.OK))
                {
                    oAutobus.aut_capacidad = Convert.ToInt32(txtCapacidad.Text);
                    oAutobus.aut_tiposervicio = cmbServicio.SelectedValue.ToString();
                    oAutobus.aut_matricula = txtPatente.Text;
                    oAutobus.emp_codigo = _empresaRepositorio.buscarEmpresaPorNombre(cmbEmpresa.SelectedValue.ToString()).emp_codigo;
                    oAutobus.aut_cantidadPisos = Convert.ToInt32(textBoxPisos.Text);
                    oAutobus.aut_imagen = imagen.Text;

                    _autobusRepositorio.AgrgarAutobus(oAutobus);

                    Autobuses.ItemsSource = _autobusRepositorio.getAutobus();
                    
                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lista_Autobuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var v = ((Autobus)Autobuses.SelectedItem);
            if (v != null)
            {
                cargarAutobusSeleccionado(v.aut_codigo);    
            }
        }

        private void btnEliminarAutobus_click(object sender, RoutedEventArgs e)
        {

            var v = ((Autobus)Autobuses.SelectedItem);
            var resultado = MessageBox.Show("¿Eliminar Autobus?", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Question);
            if (resultado.Equals(MessageBoxResult.OK))
            {
                Boolean band = false;
                List<Servicio> servicios = new List<Servicio>();
                servicios = _ServicioRepositorio.listarServicios();

                foreach (Servicio s in servicios)
                {
                    if (s.aut_codigo == Convert.ToInt32(v.aut_codigo) && s.ser_estado.Equals("Abierto"))
                    {
                        band = true;
                    }
                }

                if (band)
                {
                    MessageBox.Show("El Autobus tiene un servicio Abierto", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _autobusRepositorio.eliminarAutobus(Convert.ToInt32(v.aut_codigo));
                    MessageBox.Show("Autobus dado de Baja", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Autobuses.ItemsSource = _autobusRepositorio.getAutobus();
                    deshabilitarBotones();
                    limpiar();
                }
            }
        }

        private void btnModificarAutobus_click(object sender, RoutedEventArgs e)
        {
            Autobus oAutobus = new Autobus();
            var v = ((Autobus)Autobuses.SelectedItem);
            var resultado = MessageBox.Show("¿Modificar Autobus?", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Question);
            if (resultado.Equals(MessageBoxResult.OK))
            {
                if (v.aut_capacidad != Convert.ToInt32(txtCapacidad.Text) || !v.aut_matricula.Equals(Convert.ToString(txtPatente.Text)) ||
                    !v.aut_tiposervicio.Equals(cmbServicio.SelectedValue) || v.aut_cantidadPisos != Convert.ToInt32(textBoxPisos.Text) ||
                    v.emp_codigo != _empresaRepositorio.buscarEmpresaPorNombre(Convert.ToString(cmbEmpresa.SelectedValue)).emp_codigo ||
                    !v.aut_imagen.Equals(Convert.ToString(imagen.Text)))
                {
                    oAutobus.aut_codigo = v.aut_codigo;
                    oAutobus.aut_capacidad = Convert.ToInt32(txtCapacidad.Text);
                    oAutobus.aut_matricula = Convert.ToString(txtPatente.Text);
                    oAutobus.aut_tiposervicio = Convert.ToString(cmbServicio.SelectedValue);
                    oAutobus.aut_cantidadPisos = Convert.ToInt32(textBoxPisos.Text);
                    oAutobus.emp_codigo = _empresaRepositorio.buscarEmpresaPorNombre(Convert.ToString(cmbEmpresa.SelectedValue)).emp_codigo;
                    oAutobus.aut_imagen = Convert.ToString(imagen.Text);

                    _autobusRepositorio.ModificarAutobus(oAutobus);
                    MessageBox.Show("Autobus modificado correctamente!", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                }
                else
                {
                    MessageBox.Show("No se Realizaron cambios!", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                
               limpiar();
               Autobuses.ItemsSource = _autobusRepositorio.getAutobus();
               deshabilitarBotones();
            }
        }

        private void cargarAutobusSeleccionado(int id)
        {
            Autobus a = _autobusRepositorio.buscarAutobus(id);
            idGlobal = a.aut_codigo;
            txtCapacidad.Text = a.aut_capacidad.ToString();
            cmbServicio.SelectedValue = a.aut_tiposervicio.ToString();
            txtPatente.Text = a.aut_matricula.ToString();
            imagen.Text = a.aut_imagen.ToString();
            textBoxPisos.Text = a.aut_cantidadPisos.ToString();
            cmbEmpresa.Text = _empresaRepositorio.buscarEmpresa(Convert.ToInt32(a.emp_codigo)).emp_nombre.ToString();

            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(imagen.Text);
            b.EndInit();
            foto.Source = b;

            habilitarBotones();
        }

        private void habilitarBotones()
        {
            btnModificarUsuario.IsEnabled = true;
            btnEliminarUsuario.IsEnabled = true;
        }

        private void deshabilitarBotones()
        {
            btnEliminarUsuario.IsEnabled = false;
            btnModificarUsuario.IsEnabled = false;
        }

    }
}
