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
        PasajeRepositorio _pasajeRepositorio = new PasajeRepositorio(); 
        ClassTrabajarServicioFormat _classTrabajarServicioFormat = new ClassTrabajarServicioFormat();
        ObservableCollection<string> listAutobus = new ObservableCollection<string>();
        ObservableCollection<string> listTerminalOrigen = new ObservableCollection<string>();
        ObservableCollection<string> listTerminalDestino = new ObservableCollection<string>();

        int servicioCodigo;

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
            btnModificarServicio.IsEnabled = false;
        }

        private void cargarTerminalOrigen()
        {
            List<Terminal> terminales1 = _terminalRepositorio.listarTerminales();
            foreach (Terminal t in terminales1)
            {
                listTerminalOrigen.Add(t.ter_nombre);
            }
            cmbOrigen.ItemsSource = listTerminalOrigen;
        }

        private void cargarTerminalDestino()
        {
            List<Terminal> terminales2 = _terminalRepositorio.listarTerminales();
            foreach (Terminal t in terminales2)
            {
                listTerminalDestino.Add(t.ter_nombre);
            }
            cmbDestino.ItemsSource = listTerminalDestino;
        }

        private void cargarAutobuses() {
            List<Autobus> autobuses = _autobusRepositorio.getAutobus();
            foreach(Autobus a in autobuses){
                listAutobus.Add(a.aut_matricula);
            }
            cmbAtobuses.ItemsSource = listAutobus;
            btnModificarServicio.IsEnabled = true;
        }

        private void btnLimpiar(object sender, RoutedEventArgs e)
        {
            cmbHora.SelectedIndex = -1;
            cmbMinutos.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbAtobuses.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            cmbOrigen.SelectedIndex = -1;
            dateFecha.SelectedDate = DateTime.Today;
            btnModificarServicio.IsEnabled = false;
        }

        private void btnGuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOrigen.SelectedValue.ToString() != cmbDestino.SelectedValue.ToString())
            {
                DateTime fecha = Convert.ToDateTime(dateFecha.SelectedDate);
                int hora = Convert.ToInt32(((ComboBoxItem)cmbHora.SelectedItem).Content);
                int min = Convert.ToInt32(cmbMinutos.SelectedValue.ToString());
                TimeSpan ts = new TimeSpan(hora, min, 0);
                fecha = fecha.Date + ts;

                if (_servicioRepositorio.controlFechaHoraServicio(fecha, _autobusRepositorio.buscarAutobusMatricula(cmbAtobuses.SelectedValue.ToString()).aut_codigo))
                {
                    Servicio oServicio = new Servicio();

                    oServicio.aut_codigo = _autobusRepositorio.buscarAutobusMatricula(cmbAtobuses.SelectedValue.ToString()).aut_codigo;
                    oServicio.ser_estado = Convert.ToString(((ComboBoxItem)cmbEstado.SelectedItem).Content);
                    oServicio.ter_codigo_origen = _terminalRepositorio.buscarTerminalNombre(Convert.ToString(cmbOrigen.SelectedValue.ToString())).ter_codigo;
                    oServicio.ter_codigo_destino = _terminalRepositorio.buscarTerminalNombre(Convert.ToString(cmbDestino.SelectedValue.ToString())).ter_codigo;

                    oServicio.ser_fecha = fecha;

                    _servicioRepositorio.AgrgarServicio(oServicio);

                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServicios();
                }
                else {
                    MessageBox.Show("El servicio no puede tener la misma fecha, hora y choche que otro Servicio 'Abierto'");
                }
                    
            }else{
                MessageBox.Show("El Origen y Destino no pueden ser los mismos");
            }
            
        }

        private void Servicios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassServicioString servicio = Servicios.SelectedItem as ClassServicioString;
            btnModificarServicio.IsEnabled = true;
            btnGuardarUsuario.IsEnabled = false;
            if (servicio == null)
            {
                return;
            }
            if (_servicioRepositorio.buscarServicio(servicio.Ser_codigo) != null)
            {
                servicioCodigo = servicio.Ser_codigo;

                cmbAtobuses.SelectedValue = servicio.Aut_matricula;
                dateFecha.SelectedDate = Convert.ToDateTime(servicio.Ser_fecha);
                if (Convert.ToInt32(Convert.ToDateTime(servicio.Ser_fecha).Hour) == 0)
                {
                    cmbHora.SelectedIndex = 0;
                }
                else {
                    cmbHora.SelectedIndex = Convert.ToInt32(Convert.ToDateTime(servicio.Ser_fecha).Hour)-1;
                }
                
                cmbMinutos.SelectedIndex = Convert.ToInt32(Convert.ToDateTime(servicio.Ser_fecha).Minute);

                if (Convert.ToString(servicio.Ser_estado).Equals("Abierto"))
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else {
                    if (Convert.ToString(servicio.Ser_estado).Equals("Cancelado"))
                    {
                        cmbEstado.SelectedIndex = 1;
                    }
                    else {
                        cmbEstado.SelectedIndex = 2;
                    }
                }
    
                cmbOrigen.SelectedValue = servicio.Ter_origen;
                cmbDestino.SelectedValue = servicio.Ter_destino;
            }
            else
            {
                MessageBox.Show("Servicio no Disponible");
            }
        }

        private void btnModificarServicio_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOrigen.SelectedValue.ToString() != cmbDestino.SelectedValue.ToString())
            {
                DateTime fecha = Convert.ToDateTime(dateFecha.SelectedDate);
                int hora = Convert.ToInt32(((ComboBoxItem)cmbHora.SelectedItem).Content);
                int min = Convert.ToInt32(cmbMinutos.SelectedValue.ToString());
                TimeSpan ts = new TimeSpan(hora, min, 0);
                fecha = fecha.Date + ts;

                if (_servicioRepositorio.controlFechaHoraServicioExistente(fecha, _autobusRepositorio.buscarAutobusMatricula(cmbAtobuses.SelectedValue.ToString()).aut_codigo,servicioCodigo))
                {
                    Servicio oServicio = new Servicio();

                    oServicio.ser_codigo = servicioCodigo;
                    oServicio.aut_codigo = _autobusRepositorio.buscarAutobusMatricula(cmbAtobuses.SelectedValue.ToString()).aut_codigo;
                    oServicio.ser_estado = Convert.ToString(((ComboBoxItem)cmbEstado.SelectedItem).Content);
                    oServicio.ter_codigo_origen = _terminalRepositorio.buscarTerminalNombre(Convert.ToString(cmbOrigen.SelectedValue.ToString())).ter_codigo;
                    oServicio.ter_codigo_destino = _terminalRepositorio.buscarTerminalNombre(Convert.ToString(cmbDestino.SelectedValue.ToString())).ter_codigo;

                    oServicio.ser_fecha = fecha;

                    _servicioRepositorio.ModificarServicio(oServicio);

                    if(oServicio.ser_estado.Equals("Cancelado")){
                        _pasajeRepositorio.removerPasajes(oServicio.ser_codigo);
                        MessageBox.Show("Servicio Cancelado. Todos los pasajes fueron eliminados");
                    }

                    Servicios.ItemsSource = _classTrabajarServicioFormat.listarServicios();

                    btnModificarServicio.IsEnabled = false;
                    btnGuardarUsuario.IsEnabled = true;
                }
                else
                { 
                      MessageBox.Show("El servicio no puede tener la misma fecha, hora y choche que otro Servicio 'Abierto'");       
                }
            }
            else
            {
                MessageBox.Show("El Origen y Destino no pueden ser los mismos");
            }
        }
    }
}
