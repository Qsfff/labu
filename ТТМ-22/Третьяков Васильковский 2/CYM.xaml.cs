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

namespace Третьяков_Васильковский_2
{
    /// <summary>
    /// Логика взаимодействия для CYM.xaml
    /// </summary>
    public partial class CYM : Window
    {
        public string YM;
        public CYM()
        {
            InitializeComponent();
        }

        private void crafthuman(object sender, RoutedEventArgs e)
        {
            YM = "h";
            this.Close();
        }

        private void carr(object sender, RoutedEventArgs e)
        {
            YM = "c";
            this.Close();
        }

        private void rea(object sender, RoutedEventArgs e)
        {
            YM = "a";
            this.Close();
        }

        private void oute(object sender, RoutedEventArgs e)
        {
            YM = "r";
            this.Close();
        }
    }
}
