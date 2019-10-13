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

        public userControlABMCiudad()
        {
            InitializeComponent();
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
                if (MessageBox.Show("Mensaje", "Guardar Ciudad", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
                {

                    oCiudad.ciu_codigo = Convert.ToInt32(txtIdCiudad.Text);
                    oCiudad.ciu_nombre = txtNombreCiudad.Text;

                    _ciudadRepositorio.AgregarCiudad(oCiudad);

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
            txtIdCiudad.Clear();
            txtNombreCiudad.Clear();
        }
    }
}
