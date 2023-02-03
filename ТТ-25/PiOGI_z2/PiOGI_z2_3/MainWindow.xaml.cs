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

namespace PiOGI_z2_3
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
        private void f1(object sender, RoutedEventArgs e)
        {
            res.Content = "Blizhayshaya k solncu";
        }
        private void f2(object sender, RoutedEventArgs e)
        {
            res.Content = "Ochen goryachaya";
        }
        private void f3(object sender, RoutedEventArgs e)
        {
            res.Content = "Prigodna dlya zhizni";
        }
        private void f4(object sender, RoutedEventArgs e)
        {
            res.Content = "est led";
        }
        private void f5(object sender, RoutedEventArgs e)
        {
            res.Content = "Bolshie kolca";
        }
        private void f6(object sender, RoutedEventArgs e)
        {
            res.Content = "Bolshoy";
        }
        private void f7(object sender, RoutedEventArgs e)
        {
            res.Content = "Uran";
        }
        private void f8(object sender, RoutedEventArgs e)
        {
            res.Content = "Neptun";
        }
        private void f9(object sender, RoutedEventArgs e)
        {
            res.Content = "Ne planeta";
        }
    }
}
