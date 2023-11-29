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
using static System.Net.Mime.MediaTypeNames;

namespace Tретьяков_Васильковский_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, slave> slaves = new Dictionary<string, slave>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void newslave(object sender, RoutedEventArgs e)
        {
            slavegenerator SG = new slavegenerator();
            SG.ShowDialog();
            slave slave1 = new slave(SG.isource, SG.name1.Text, SG.name2.Text, SG.otdel.Text, SG.job.Text, (bool)SG.status.IsChecked);
            slaves.Add(slave1.who() + " " + slave1.who2(), slave1);
            cbusers.SelectedIndex = cbusers.Items.Add(slave1.who() + " " + slave1.who2());
            showslave();
        }
        private void showslave()
        {
            if (cbusers.SelectedIndex != -1)
            {
                BitmapImage a = new BitmapImage();
                a.BeginInit();
                a.UriSource = new Uri(slaves[(string)cbusers.SelectedValue].image());
                a.DecodePixelWidth = 200;
                a.EndInit();
                ealo.Source = a;
                lname.Content = slaves[(string)cbusers.SelectedValue].who();
                lname2.Content = slaves[(string)cbusers.SelectedValue].who2();
                lotdel.Content = slaves[(string)cbusers.SelectedValue].gde();
                ljob.Content = slaves[(string)cbusers.SelectedValue].chto();
                if (slaves[(string)cbusers.SelectedValue].state()) lstatus.Content = "Alive";
                else lstatus.Content = "Dead";
            }
        }

        private void changeslave(object sender, SelectionChangedEventArgs e)
        {
            showslave();
        }
    }
    public class slave
    {
        string imsource = "";
        string name = "";
        string name2 = "";
        string otdel = ""; 
        string job = "";
        bool status = false;
        public slave(string img, string n1, string n2, string o, string j, bool s)
        {
            imsource = img;
            name = n1;
            name2 = n2;
            otdel = o;
            job = j;
            status = s;
        }
        public string image()
        {
            return imsource;
        }
        public string who()
        {
            return name;
        }
        public string who2()
        {
            return name2;
        }
        public string gde()
        {
            return otdel;
        }
        public string chto()
        {
            return job;
        }
        public bool state()
        {
            return status;
        }
    }
}
