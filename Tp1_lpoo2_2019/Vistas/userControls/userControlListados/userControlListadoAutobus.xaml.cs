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
    /// Lógica de interacción para userControlListadoAutobus.xaml
    /// </summary>
    public partial class userControlListadoAutobus : UserControl
    {
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();

        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public userControlListadoAutobus()
        {
            InitializeComponent();
        }

        private void Autobuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Autobus auto = Autobuses.SelectedItem as Autobus;

            if(auto == null){
                return;
            }

            if (_servicioRepositorio.servicioCoche(auto.aut_codigo) != null)
            {
                GridAutobusesMain.Children.Clear();
                userControls.uGestionVentas.uPasajeUnPiso pasajes = new userControls.uGestionVentas.uPasajeUnPiso();
                //pasajes.CodigoAutobus = auto.aut_codigo;
                pasajes.NombreUsuario = nombreUsuario;
                GridAutobusesMain.Children.Add(pasajes);
            }
            else {
                MessageBox.Show("Coche sin servicio asignado!!!!!");
            }
                
        }
    }
}
