using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PiOGI_z2_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer t;
        int sec, min, chas;
        bool o;
        public MainWindow()
        {
            sec = 0;
            min = 0;
            chas = 0;
            o = true;
            t = new System.Windows.Threading.DispatcherTimer();
            t.Tick += new EventHandler(dispatcherTimer_Tick);
            t.Interval = new TimeSpan(0, 0, 0, 0, 500);
            InitializeComponent();

        }
        public void output()
        {
            if (((bool)se.IsChecked) && ((bool)mi.IsChecked) && ((bool)ch.IsChecked)) res.Content = chas.ToString() + ":" + min.ToString() + ":" + sec.ToString();
            if (((bool)se.IsChecked) && ((bool)mi.IsChecked) && (!(bool)ch.IsChecked)) res.Content = (min + (chas * 60)).ToString() + ":" + sec.ToString();
            if (((bool)se.IsChecked) && (!(bool)mi.IsChecked) && (!(bool)ch.IsChecked)) res.Content = (sec + (min * 60) + (chas * 3600)).ToString();
            if ((!(bool)se.IsChecked) && ((bool)mi.IsChecked) && ((bool)ch.IsChecked)) res.Content = chas.ToString() + ":" + min.ToString();
            if ((!(bool)se.IsChecked) && (!(bool)mi.IsChecked) && ((bool)ch.IsChecked)) res.Content = chas.ToString();
            if ((!(bool)se.IsChecked) && ((bool)mi.IsChecked) && (!(bool)ch.IsChecked)) res.Content = (min + (chas * 60)).ToString();
            if (((bool)se.IsChecked) && (!(bool)mi.IsChecked) && ((bool)ch.IsChecked)) res.Content = chas.ToString() + ":" + (sec + (min * 60)).ToString();
            if ((!(bool)se.IsChecked) && (!(bool)mi.IsChecked) && (!(bool)ch.IsChecked)) res.Content = "";
        }

        private void neo(object sender, RoutedEventArgs e)
        {
            o = false;
        }

        private void noooo(object sender, RoutedEventArgs e)
        {
            t.Stop();
            sec = 0;
            min = 0;
            chas = 0;
            res.Content = "";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            sec += 1;
            if (sec == 60) { sec = 0; min += 1; }
            if (min == 60) { min = 0; chas += 1; }
            if (o) output();
        }
        private void zap(object sender, RoutedEventArgs e)
        {
            o = true;
            t.Start();
        }
    }
}