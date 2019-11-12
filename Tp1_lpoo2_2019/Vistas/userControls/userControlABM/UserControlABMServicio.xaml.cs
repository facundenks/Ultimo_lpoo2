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
using System.Collections.ObjectModel;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Lógica de interacción para UserControlABMServicio.xaml
    /// </summary>
    public partial class UserControlABMServicio : UserControl
    {
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();
        TerminalRepositorio _terminalRepositorio = new TerminalRepositorio();
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        ObservableCollection<int> listAutobus = new ObservableCollection<int>();
        ObservableCollection<int> listTerminalOrigen = new ObservableCollection<int>();
        ObservableCollection<int> listTerminalDestino = new ObservableCollection<int>();

        public UserControlABMServicio()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cargarAutobuses();
            cargarTerminalOrigen();
            cargarTerminalDestino();
            dateFecha.SelectedDate = DateTime.Today;
        }

        private void cargarTerminalOrigen()
        {
            List<Terminal> terminales1 = _terminalRepositorio.listarTerminales();
            foreach (Terminal t in terminales1)
            {
                listTerminalOrigen.Add(t.ter_codigo);
            }
            cmbOrigen.ItemsSource = listTerminalOrigen;
        }

        private void cargarTerminalDestino()
        {
            List<Terminal> terminales2 = _terminalRepositorio.listarTerminales();
            foreach (Terminal t in terminales2)
            {
                listTerminalDestino.Add(t.ter_codigo);
            }
            cmbDestino.ItemsSource = listTerminalDestino;
        }

        private void cargarAutobuses() {
            List<Autobus> autobuses = _autobusRepositorio.getAutobus();
            foreach(Autobus a in autobuses){
                listAutobus.Add(a.aut_codigo);
            }
            cmbAtobuses.ItemsSource = listAutobus;
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Servicio oServicio = new Servicio();

            oServicio.aut_codigo = (int)cmbAtobuses.SelectedValue;
            oServicio.ser_estado = Convert.ToString(((ComboBoxItem)cmbEstado.SelectedItem).Content);
            oServicio.ter_codigo_origen = (int)cmbOrigen.SelectedValue;
            oServicio.ter_codigo_destino = (int)cmbDestino.SelectedValue;

            DateTime fecha = Convert.ToDateTime(dateFecha.SelectedDate);
            int hora = Convert.ToInt32(((ComboBoxItem)cmbHora.SelectedItem).Content);
            int min = Convert.ToInt32(cmbMinutos.SelectedValue.ToString());
            TimeSpan ts = new TimeSpan(hora,min,0);
            fecha = fecha.Date + ts;

            oServicio.ser_fecha = fecha;

            _servicioRepositorio.AgrgarServicio(oServicio);

            Servicios.ItemsSource = _servicioRepositorio.listarServicios();
        }
    }
}
