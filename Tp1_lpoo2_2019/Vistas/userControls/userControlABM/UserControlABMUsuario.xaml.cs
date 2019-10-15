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
using System.Collections.ObjectModel;
using ClasesBase;
using ClasesBase.DAO.Repositorio;

namespace Vistas.userControls.userControlABM
{
    /// <summary>
    /// Interaction logic for UserControlABMUsuario.xaml
    /// </summary>
    public partial class UserControlABMUsuario : UserControl
    {
        UsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();
        
        public UserControlABMUsuario()
        {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuarios;


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listaUsuarios = odp.Data as ObservableCollection<Usuario>;

            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvasUsuarios.DataContext);
            codigoRol();
        }

        private void codigoRol() {
            if (labelCodigo.Content.ToString().Equals("1"))
            {
                textBox5.Text = "Administrador";
            }
            else
            {
                textBox5.Text = "Operador";
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
            codigoRol();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
            codigoRol();
        }

        private void btnPrevius_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
            codigoRol();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if(Vista.IsCurrentAfterLast){
                Vista.MoveCurrentToFirst();
            }
            codigoRol();
        }

        private void btnListarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipalUsuario.Children.Clear();
            userControls.userControlListados.userControlListadoUsuario usuarios = new userControlListados.userControlListadoUsuario();
            GridPrincipalUsuario.Children.Add(usuarios);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.usu_apellidoNombre = Convert.ToString(txtApellido.Text);
            oUsuario.usu_nombreUsuario = Convert.ToString(txtNombre.Text);
            oUsuario.usu_contraseña = Convert.ToString(txtContraseña.Text);
            int codigoRol = 0;
            if (cmbRol.SelectedValue.ToString() == "Administrador")
            {
                codigoRol = 1;
            }
            else {
                codigoRol = 2;
            }
            oUsuario.rol_codigo = codigoRol;

            _usuarioRepositorio.AgrgarUsuario(oUsuario);

            listaUsuarios.Add(oUsuario);

            MessageBox.Show("Usuario agregado correctamente");
            Vista.MoveCurrentToLast();

        }

        private void habilitar_Alta() { 
            
        }

        private void deshabilitar_text() {
            txtID.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtContraseña.IsEnabled = false;

        }

    }
}
