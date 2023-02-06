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

namespace PiOGI_z3
{
    /// <summary>
    /// Логика взаимодействия для DateSelection.xaml
    /// </summary>
    public partial class DateSelection : Window
    {
        public DateSelection()
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
