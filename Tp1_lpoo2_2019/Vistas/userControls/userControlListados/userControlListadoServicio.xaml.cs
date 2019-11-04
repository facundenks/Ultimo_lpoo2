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

namespace Vistas.userControls.userControlListados
{
    /// <summary>
    /// Lógica de interacción para userControlListadoServicio.xaml
    /// </summary>
    public partial class userControlListadoServicio : UserControl
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public userControlListadoServicio()
        {
            InitializeComponent();
        }

        private void Servicios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassServicioString servicio = Servicios.SelectedItem as ClassServicioString;

            if (servicio == null)
            {
                return;
            }

            if (_servicioRepositorio.buscarServicio(servicio.Ser_codigo) != null)
            {
                GridAutobusesMain.Children.Clear();
                userControls.uGestionVentas.uPasaje pasajes = new userControls.uGestionVentas.uPasaje();
                pasajes.CodigoServicio = servicio.Ser_codigo;
                pasajes.NombreUsuario = nombreUsuario;
                pasajes.CodigoEmpresa = servicio.Emp_codigo;
                GridAutobusesMain.Children.Add(pasajes);
            }
            else
            {
                MessageBox.Show("Servicio no Disponible");
            }
        }
    }
}
