using Microsoft.Win32;
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

namespace Tретьяков_Васильковский_3
{
    /// <summary>
    /// Логика взаимодействия для slavegenerator.xaml
    /// </summary>
    public partial class slavegenerator : Window
    {
        public string isource;
        public slavegenerator()
        {
            InitializeComponent();
        }

        private void ok(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void choose_your_character(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "c";
            dlg.Filter = "mages|*.jpg;*.jpeg;*.png;";
            if (dlg.ShowDialog() == true)
            {
                isource = dlg.FileName;
                BitmapImage a = new BitmapImage();
                a.BeginInit();
                a.UriSource = new Uri(isource);
                a.DecodePixelWidth = 200;
                a.EndInit();
                mage.Source = a;
            }
        }
    }
}
