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

namespace Vistas.Document.Doc
{
    /// <summary>
    /// Lógica de interacción para UsuariosDoc.xaml
    /// </summary>
    public partial class UsuariosDoc : Window
    {
        private List<ClassUsuario> usuarios;

        public List<ClassUsuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        public UsuariosDoc()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if(pdlg.ShowDialog()== true){
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            usuariosList.ItemsSource = usuarios;
        }
    }
}
