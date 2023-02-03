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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiOGI_z2_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            res.Content = int.Parse(tA.Text) + int.Parse(tB.Text);
        }
        private void negative(object sender, RoutedEventArgs e)
        {
            res.Content = int.Parse(tA.Text) - int.Parse(tB.Text);
        }
        private void positive(object sender, RoutedEventArgs e)
        {
            res.Content = int.Parse(tA.Text) * int.Parse(tB.Text);
        }
        private void annigilator(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tB.Text) != 0)
                res.Content = int.Parse(tA.Text) / int.Parse(tB.Text);
            else res.Content = "NaN";
        }
    }
}
