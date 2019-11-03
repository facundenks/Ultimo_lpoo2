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

namespace Vistas.userControls.userControlListados
{
    /// <summary>
    /// Interaction logic for UserControlListadoPasajes.xaml
    /// </summary>
    public partial class UserControlListadoPasajes : UserControl
    {
        private CollectionViewSource vistaColeccionFiltrada;//vista de coleccion filtrada
        public UserControlListadoPasajes()
        {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["Vista_Venta"] as CollectionViewSource;
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                //Se invoca al metodo eventVistaUser a medida que se escriba en el textBox
                vistaColeccionFiltrada.Filter += eventVistaUsuario_filter;
            }
        }

        private void eventVistaUsuario_filter(object sender, FilterEventArgs e)
        {
            ClassUsuario usuario = e.Item as ClassUsuario;

            try
            {
                if (usuario.NombreUsuario1.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    e.Accepted = true;
                }
                
                else
                {
                    e.Accepted = false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Document.Doc.UsuariosDoc usuDoc = new Document.Doc.UsuariosDoc();
            List<ClassUsuario> users = new List<ClassUsuario>();
            for (int i = 0; i < Usuarios.Items.Count; i++)
            {
                users.Add((ClassUsuario)Usuarios.Items[i]);
            }
            usuDoc.Usuarios = users;
            usuDoc.Show();
        }
    }
    }
}
