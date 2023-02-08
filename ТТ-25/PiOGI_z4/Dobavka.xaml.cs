using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PiOGI_z4
{
    /// <summary>
    /// Логика взаимодействия для Dobavka.xaml
    /// </summary>
    public partial class Dobavka : Window
    {
        public Dobavka()
        {
            InitializeComponent();
        }
        private void zakruvaaay(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void pravda(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
