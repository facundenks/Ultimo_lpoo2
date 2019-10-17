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
        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

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
            codigoRolMet();
            deshabilitar_text();
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }

        private void codigoRolMet() {
            if (labelCodigo.Content.ToString().Equals("1"))
            {
                txtRolDes.Text = "Administrador";
            }
            else
            {
                txtRolDes.Text = "Operador";
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
            codigoRolMet();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
            codigoRolMet();
        }

        private void btnPrevius_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
            }
            codigoRolMet();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if(Vista.IsCurrentAfterLast){
                Vista.MoveCurrentToFirst();
            }
            codigoRolMet();
        }

        private void btnListarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipalUsuario.Children.Clear();
            userControls.userControlListados.userControlListadoUsuario usuarios = new userControlListados.userControlListadoUsuario();
            GridPrincipalUsuario.Children.Add(usuarios);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtContraseña.Text != "" && cmbRol.SelectedIndex != -1)
            {
                
                    Usuario oUsuario = new Usuario();
                    oUsuario.usu_apellidoNombre = Convert.ToString(txtApellido.Text);
                    oUsuario.usu_nombreUsuario = Convert.ToString(txtNombre.Text);
                    oUsuario.usu_contraseña = Convert.ToString(txtContraseña.Text);

                    int codigoRol = cmbRol.SelectedIndex + 1;

                    oUsuario.rol_codigo = codigoRol;


                    if (txtID.Text == "")
                    {
                        if (!_usuarioRepositorio.nombreUsuarioExiste(txtNombre.Text))
                        {
                            if (MessageBox.Show("Agregar usuario", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                _usuarioRepositorio.AgrgarUsuario(oUsuario);
                                listaUsuarios.Add(oUsuario);

                                MessageBox.Show("Usuario agregado correctamente");
                                Vista.MoveCurrentToLast();
                                codigoRolMet();
                            }
                        }else{
                            MessageBox.Show("Nombre de usuario no diponible", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Modificar usuario", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            oUsuario.usu_id = Convert.ToInt32(txtID.Text);

                            _usuarioRepositorio.ModificarUsuario(oUsuario);
                            int index = _usuarioRepositorio.ObtenerPosicion(oUsuario.usu_id);
                            listaUsuarios[index] = oUsuario;
                            codigoRolMet();

                            MessageBox.Show("Usuario modificado correctamente");
                            Vista.MoveCurrentToLast();
                            Vista.MoveCurrentToPosition(index);
                        }
                    }

                    btnGuardar.IsEnabled = false;
                    btnCancelar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                    btnNuevo.IsEnabled = true;
                    btnSeleccionar.IsEnabled = true;


                    limpiar();
                    deshabilitar_text();
            }
            else {
                MessageBox.Show("Debe completar todos los campos", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void limpiar() {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = -1;
        }

        private void habilitar_Alta() {
           
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtContraseña.IsEnabled = true;
            cmbRol.IsEnabled = true;
        }

        private void deshabilitar_text() {
            
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtContraseña.IsEnabled = false;
            cmbRol.IsEnabled = false;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            habilitar_Alta();
            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnNuevo.IsEnabled = false;
            btnSeleccionar.IsEnabled = false;
            txtID.Text = txtId.Text;
            txtNombre.Text = txtUsNom.Text;
            txtApellido.Text = txtApyNom.Text;
            txtContraseña.Text = txtPass.Text;
            cmbRol.SelectedItem = cmbRol.Items.GetItemAt(Convert.ToInt32(labelCodigo.Content.ToString())-1);
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            habilitar_Alta();
            btnSeleccionar.IsEnabled = false;
            btnCancelar.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnEliminar.IsEnabled = false;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            deshabilitar_text();
            btnSeleccionar.IsEnabled = true;
            btnNuevo.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != userName)
            {
                int index = _usuarioRepositorio.ObtenerPosicion(Convert.ToInt32(txtID.Text));
                
                if (MessageBox.Show("Eliminar usuario", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
                {
                    _usuarioRepositorio.eliminarUsuario(Convert.ToInt32(txtID.Text));
                    listaUsuarios.RemoveAt(index);
                    MessageBox.Show("Ususario eliminado correctamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }    
                despuesEliminacion();
            }
            else {
                MessageBox.Show("No puede eliminar usuario logeado", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void despuesEliminacion() {
            Vista.MoveCurrentToFirst();
            limpiar();
            deshabilitar_text();
            btnSeleccionar.IsEnabled = true;
            btnNuevo.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
        }
    }
}
