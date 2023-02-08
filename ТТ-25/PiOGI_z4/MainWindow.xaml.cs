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
using System.Data.SQLite;

namespace PiOGI_z4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string db_name;
        public MainWindow()
        {
            InitializeComponent();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".db";
            dlg.Filter = "Bazu dannux (.bd)|*.bd";
            if (dlg.ShowDialog() == true)
            {
                db_name = dlg.FileName;
            }
        }
        private void dbv(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connectdb;
            connectdb = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            connectdb.Open();
            Dobavka U = new Dobavka();
            if (U.ShowDialog() == true)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT Cod FROM Chair1 ORDER BY Cod DESC LIMIT 1", connectdb);
                command = new SQLiteCommand("INSERT INTO Chair1 VALUES (FIO, eblan)", connectdb);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("INSERT INTO Chair2 DEFAULT VALUES", connectdb);
                command.ExecuteNonQuery();
            }
            connectdb.Close();
        }
    }
}
