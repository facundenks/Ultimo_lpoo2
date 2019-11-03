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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para formVenta.xaml 
    /// </summary>
    //#FFD74A4A
    public partial class formVenta : Window
    {
        public formVenta()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn18.Background = Brushes.Red;
        }

        private void vender_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (sender as Button);
            

            if (bt.Background == Brushes.Green)
            {
                MessageBox.Show("Asiento Disponible, para la reserva de pasaje");
            }
            else {
                MessageBox.Show("Asiento no disponible"); 
            }
        }
    }
}
