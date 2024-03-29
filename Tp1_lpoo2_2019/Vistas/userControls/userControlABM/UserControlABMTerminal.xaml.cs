﻿using System;
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
using ClasesBase.DAO.Repositorio;
using ClasesBase;
using System.Collections.ObjectModel;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Interaction logic for UserControlABMTerminal.xaml
    /// </summary>
    public partial class UserControlABMTerminal : UserControl
    {
        //Declaracion de variables
        Terminal terminal = new Terminal();
        TerminalRepositorio _TerminalRepositorio = new TerminalRepositorio();
        CiudadRepositorio _CiudadRepositorio = new CiudadRepositorio();
        ServicioRepositorio _ServicioReposiorio = new ServicioRepositorio();
        ObservableCollection<string> list = new ObservableCollection<string>();
        ClassTrabajarTerminalString listaTerminales = new ClassTrabajarTerminalString();

        public UserControlABMTerminal()
        {
            InitializeComponent();
            cargar_combo();
            btnModificarTerminal.IsEnabled = false;
        }


        //Metodo QUE SE EJECUTA AL HACER CLICK EN EL BOTON, VALIDAD QUE LOS CAMPOS ESTEN LLENADOS 
        //Y NO SE REPITA EL NOMBREDE LA TERMINAL. Si cumple esa validacion guarda una terminal en la bd
        private void btnGuardarTerminal_Click(object sender, RoutedEventArgs e)
        {
            if (nombreTerminal.Text != "" && cmbCiudad.SelectedIndex != -1)
            {
                var resultado = MessageBox.Show("¿Guardar Terminal?", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Question);
                if (resultado.Equals(MessageBoxResult.OK))
                {
                    if(!validacionNombreTerminal())
                    {
                        guardarTerminal();
                    }else{
                        MessageBox.Show("El Nombre de la Terminal ya EXISTE en el Sistema!", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
                        limpiar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Metodo que Guarda una terminal en la bd
        private void guardarTerminal()
        {
            terminal.ter_nombre = nombreTerminal.Text;
            terminal.ciu_codigo = _CiudadRepositorio.getCiudad(cmbCiudad.SelectedValue.ToString()).ciu_codigo;
            _TerminalRepositorio.agregarTerminal(terminal);
            limpiar();
            list_terminales.ItemsSource = listaTerminales.TerminalStringList();
        }
        
        //Metodo que retorna una variable boleada para saber si el nombre de terminal ya esta registrado en la bd
        private Boolean validacionNombreTerminal()
        {
            Boolean band = false;
            List<Terminal> terminales = _TerminalRepositorio.getTerminales();
            foreach (Terminal t in terminales)
            {
                if(t.ter_nombre.Equals(nombreTerminal.Text)){
                    band = true;
                }
            }

            return band;
        }


        private void btnLimpiarUsuario_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            btnModificarTerminal.IsEnabled = false;
        }

        private void cargar_combo()
        {
            List<Ciudad> ciudades = _CiudadRepositorio.getCiudades();
            foreach (Ciudad c in ciudades)
            {
                list.Add(c.ciu_nombre);
            }
            cmbCiudad.ItemsSource = list;
        }

        private void limpiar()
        {
            nombreTerminal.Clear();
            cmbCiudad.SelectedIndex = -1;
        }

        private void list_terminales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var v = ((ClassTerminalString)list_terminales.SelectedItem);
            if (v != null)
            {
                nombreTerminal.Text = v.Terminal_nombre;
                cmbCiudad.Text = v.Terminal_ciudad;
                btnModificarTerminal.IsEnabled = true;
            }
        }

        private void btnModificarTerminal_Click(object sender, RoutedEventArgs e)
        {
            Terminal unTerminal = new Terminal();
            Ciudad unCiudad = new Ciudad();

            if (MessageBox.Show("¿Modificar Terminal?", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                var v = ((ClassTerminalString)list_terminales.SelectedItem);
                unTerminal = _TerminalRepositorio.buscarTerminal(Convert.ToInt16(v.Terminal_codigo));
                unTerminal.ter_nombre = Convert.ToString(nombreTerminal.Text);

                _TerminalRepositorio.modificarTerminal(unTerminal);

                MessageBox.Show("Terminal modificada correctamente!", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                limpiar();

                list_terminales.ItemsSource = listaTerminales.TerminalStringList();
                btnModificarTerminal.IsEnabled = false;
            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var v = ((ClassTerminalString)list_terminales.SelectedItem);
            if (v.Terminal_codigo != "")
            {
                var resultado = MessageBox.Show("¿Eliminar terminal?", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Question);
                if (resultado.Equals(MessageBoxResult.OK))
                {
                    Boolean band = false;
                    List<Servicio> servicios = new List<Servicio>();
                    servicios = _ServicioReposiorio.listarServicios();

                    foreach (Servicio s in servicios)
                    {
                        //bool coso = _servicioReporsitorio.servicioValidarOrigen(ter.ter_codigo);
                        if (s.ter_codigo_destino == Convert.ToInt32(v.Terminal_codigo) || s.ter_codigo_origen == Convert.ToInt32(v.Terminal_codigo))
                        {
                            band = true;
                        }
                    }

                    if (band)
                    {
                        MessageBox.Show("La Terminal tiene un servicio Abierto, no se puede eliminar", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _TerminalRepositorio.eliminarTerminal(Convert.ToInt32(v.Terminal_codigo));
                        MessageBox.Show("Terminal dada de Baja", "Gestion Terminal", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        list_terminales.ItemsSource = listaTerminales.TerminalStringList();
                        limpiar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Gestion Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
