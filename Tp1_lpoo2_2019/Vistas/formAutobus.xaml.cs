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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para formAutobus.xaml
    /// </summary>
    public partial class formAutobus : Window
    {
        Autobus oAutobus = new Autobus();
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();

        public formAutobus()
        {
            InitializeComponent();
        }

        private void txtCapacidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCapacidad.Text != "" && cmbServicio.SelectedIndex != -1 && txtPatente.Text != "")
            {
                oAutobus.aut_capacidad = Convert.ToInt32(txtCapacidad.Text);
                oAutobus.aut_tiposervicio = Convert.ToString(((ComboBoxItem)cmbServicio.SelectedItem).Content);
                oAutobus.aut_matricula = txtPatente.Text;

                limpiar();

                _autobusRepositorio.AgrgarAutobus(oAutobus);
            }
            else
            {
                MessageBox.Show("Completar todos los campos");
            }
        }

        private void limpiar() {
            txtId.Clear();
            txtCapacidad.Clear();
            cmbServicio.SelectedIndex = -1;
            txtPatente.Clear();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
    }
}
