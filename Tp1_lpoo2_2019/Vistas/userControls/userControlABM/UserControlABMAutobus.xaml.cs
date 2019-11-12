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
        ObservableCollection<string> list = new ObservableCollection<string>();

        public UserControlABMAutobus()
        {
            InitializeComponent();
            cargar_combo();
        }

        private void txtCapacidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtCapacidad.Text != "" && cmbServicio.SelectedIndex != -1 && txtPatente.Text != "")
            {
                var resultado = MessageBox.Show("Mensaje", "Guardar Autobus", MessageBoxButton.OK, MessageBoxImage.Question);
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
                MessageBox.Show("Completar todos los campos");
            }
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
    }
}
