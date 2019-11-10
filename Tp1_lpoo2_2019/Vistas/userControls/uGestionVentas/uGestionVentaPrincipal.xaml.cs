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

namespace Vistas.userControls.uGestionVentas
{
    /// <summary>
    /// Lógica de interacción para uGestionVentaPrincipal.xaml
    /// </summary>
    public partial class uGestionVentaPrincipal : UserControl
    {
        private String nombreUsuario;

        public String NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private int codigoServicio;

        public int CodigoServicio
        {
            get { return codigoServicio; }
            set { codigoServicio = value; }
        }

        private int codigoEmpresa;

        public int CodigoEmpresa
        {
            get { return codigoEmpresa; }
            set { codigoEmpresa = value; }
        }

        private int pisos;

        public int Pisos
        {
            get { return pisos; }
            set { pisos = value; }
        }

        public uGestionVentaPrincipal()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            /*if(band){
                scrol.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                scrol.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }*/
            
            if (pisos == 2)
            {
                gridPrincipalMain.Children.Clear();
                userControls.uGestionVentas.uPasajeDosPisos pasajes2 = new userControls.uGestionVentas.uPasajeDosPisos();
                pasajes2.CodigoServicio = codigoServicio;
                pasajes2.NombreUsuario = nombreUsuario;
                pasajes2.CodigoEmpresa = codigoEmpresa;
                pasajes2.Pisos = pisos;
                gridPrincipalMain.Children.Add(pasajes2);
            }
            else {
                gridPrincipalMain.Children.Clear();
                userControls.uGestionVentas.uPasajeUnPiso pasajes1 = new userControls.uGestionVentas.uPasajeUnPiso();
                pasajes1.CodigoServicio = codigoServicio;
                pasajes1.NombreUsuario = nombreUsuario;
                pasajes1.CodigoEmpresa = codigoEmpresa;
                pasajes1.Pisos = pisos;
                gridPrincipalMain.Children.Add(pasajes1);
            }
        }
    }
}
