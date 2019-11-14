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

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Interaction logic for userControlABMCiudad.xaml
    /// </summary>
    public partial class userControlABMCiudad : UserControl
    {
        Ciudad oCiudad = new Ciudad();
        CiudadRepositorio _ciudadRepositorio = new CiudadRepositorio();
        Terminal oTerminal = new Terminal();
        TerminalRepositorio _terminalRepositorio = new TerminalRepositorio();
        Servicio oServicio = new Servicio();
        ServicioRepositorio _servicioReporsitorio = new ServicioRepositorio();
        ClassTrabajarCiudadString listaCiudades = new ClassTrabajarCiudadString();


        public userControlABMCiudad()
        {
            InitializeComponent();
            btnModificarUsuario.IsEnabled = false;
        }

        private void txtIdCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnLimpiarUsuario_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCiudad.Text != "" && txtNombreCiudad.Text != "")
            {
                if (MessageBox.Show("¿Agregar Ciudad?", "Guardar Ciudad", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {

                    oCiudad.ciu_codigo = Convert.ToInt32(txtIdCiudad.Text);
                    oCiudad.ciu_nombre = txtNombreCiudad.Text;

                    _ciudadRepositorio.AgregarCiudad(oCiudad);

                    MessageBox.Show("Ciudad agregada correctamente!", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    limpiar();
                    Ciudades.ItemsSource = listaCiudades.CiudadStringList();

                }
            }
            else
            {
                MessageBox.Show("Completar todos los campos");
            }
        }

        private void limpiar()
        {
            txtIdCiudad.Clear();
            txtNombreCiudad.Clear();
            txtIdCiudad.IsEnabled = true;
            btnModificarUsuario.IsEnabled = false;
        }

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var v = ((Ciudad)Ciudades.SelectedItem);
            var resultado = MessageBox.Show("¿Modificar Ciudad?", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Question);
            if (resultado.Equals(MessageBoxResult.OK))
            {
                if (v.ciu_nombre != txtNombreCiudad.Text)
                {
                    oCiudad.ciu_codigo = Convert.ToInt32(txtIdCiudad.Text);
                    oCiudad.ciu_nombre = Convert.ToString(txtNombreCiudad.Text);
                    _ciudadRepositorio.modificarCiudad(oCiudad);

                    MessageBox.Show("Ciudad modificada correctamente!", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    limpiar();
                    //Ciudades.ItemsSource = _ciudadRepositorio.getCiudades();
                    Ciudades.ItemsSource = listaCiudades.CiudadStringList();
                }else{
                    MessageBox.Show("No se Realizaron cambios!", "Gestion Autobus", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    limpiar();
                    //Ciudades.ItemsSource = _ciudadRepositorio.getCiudades();
                    Ciudades.ItemsSource = listaCiudades.CiudadStringList();
                    btnModificarUsuario.IsEnabled = false;
                }
                
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Ciudades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtIdCiudad.IsEnabled = false;
            var v = ((ClassCiudadString)Ciudades.SelectedItem);
            if (v != null)
            {
                txtIdCiudad.Text = v.Ciu_codigo.ToString();
                txtNombreCiudad.Text = v.Ciu_nombre.ToString();
                btnModificarUsuario.IsEnabled = true;
            }
        }
       

       /* private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdCiudad.Text != "" && txtNombreCiudad.Text != "")
            {
                var resultado = MessageBox.Show("¿Eliminar ciudad?", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Question);
                if (resultado.Equals(MessageBoxResult.OK))
                {
                    bool encontrado1 = false;
                    bool encontrado2 = false;
                    oCiudad.ciu_codigo = Convert.ToInt32(txtIdCiudad.Text);
                    List<Terminal> terminales = new List<Terminal>();
                    terminales = _terminalRepositorio.listarTerminalCiudad(oCiudad.ciu_codigo);

                    foreach (Terminal ter in terminales)
                    {
                        //bool coso = _servicioReporsitorio.servicioValidarOrigen(ter.ter_codigo);
                        if (_servicioReporsitorio.servicioValidarOrigen(ter.ter_codigo))
                        {
                            encontrado1 = true;
                        }
                    }
                    foreach (Terminal termi in terminales)
                    {
                        if (_servicioReporsitorio.servicioValidarDestino(termi.ter_codigo))
                        {
                            encontrado2 = true;
                        }
                    }
                    
                    if (encontrado1 && encontrado2 )
                    {
                        _ciudadRepositorio.removeCiudad(oCiudad.ciu_codigo);
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar la ciudad con un servicio en uso");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }*/

       
    }
}
