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
        SQLiteConnection connectdb;
        public MainWindow()
        {
            InitializeComponent();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".db";
            dlg.Filter = "Bazu dannux (.db)|*.db";
            if (dlg.ShowDialog() == true)
            {
                db_name = dlg.FileName;
            }
            connectdb = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            connectdb.Open();
            TheBox();
        }
        void TheBox()
        {
            while (cb.Items.Count > 0)
            {
                cb.Items.RemoveAt(cb.Items.Count - 1);
            }
            SQLiteCommand command = new SQLiteCommand("SELECT Cod FROM Chair1 ORDER BY Cod DESC LIMIT 1;", connectdb);
            ent.Content = command.ExecuteScalar();
            for (int i = cb.Items.Count; i < (System.Int64)ent.Content; i++)
            {
                cb.Items.Add(i + 1);
            }
            cb.SelectedIndex = 0;
        }
        void Delete()
        {
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Chair1 LIMIT " + cb.SelectedIndex + ",1", connectdb);
            command.ExecuteNonQuery();
            command = new SQLiteCommand("DELETE FROM Chair2 LIMIT " + cb.SelectedIndex + ",1", connectdb);
            command.ExecuteNonQuery();
            TheBox();
            FiO.Content = "";
            Phu.Content = "";
            Mat.Content = "";
        }
        void pokaz()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT FIO FROM Chair1 LIMIT " + cb.SelectedIndex + ",1", connectdb);
            FiO.Content = command.ExecuteScalar();
            command = new SQLiteCommand("SELECT Ph FROM Chair2 LIMIT " + cb.SelectedIndex + ",1", connectdb);
            Phu.Content = command.ExecuteScalar();
            command = new SQLiteCommand("SELECT Ma FROM Chair2 LIMIT " + cb.SelectedIndex + ",1", connectdb);
            Mat.Content = command.ExecuteScalar();
        }
        private void dbv(object sender, RoutedEventArgs e)
        {
            
            Dobavka U = new Dobavka();
            if (U.ShowDialog() == true)
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO Chair1 (Cod, FIO) VALUES (" + ((System.Int64)ent.Content + 1) + ", '" + U.FIO.Text +"');", connectdb);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("INSERT INTO Chair2 (Cod, Ph, Ma) VALUES (" + ((System.Int64)ent.Content + 1) + ", '" + U.Fizz.Text + "', '" + U.Matt.Text + "');", connectdb);
                command.ExecuteNonQuery();
                TheBox();
            }
        }
        private void pkz(object sender, RoutedEventArgs e)
        {
            pokaz();
        }

        private void dlt(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void izm(object sender, RoutedEventArgs e)
        {
            Dobavka U = new Dobavka();
            U.FIO.Text = (string)FiO.Content;
            int meh = (int)(long)Phu.Content;
            U.Fizz.Text = meh.ToString();
            meh = (int)(long)Mat.Content;
            U.Matt.Text = meh.ToString();
            int thecod = (int)cb.SelectedItem;
            if (U.ShowDialog() == true)
            {
                Delete();
                SQLiteCommand command = new SQLiteCommand("INSERT INTO Chair1 (Cod, FIO) VALUES (" + thecod + ", '" + U.FIO.Text + "');", connectdb);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("INSERT INTO Chair2 (Cod, Ph, Ma) VALUES (" + thecod + ", '" + U.Fizz.Text + "', '" + U.Matt.Text + "');", connectdb);
                command.ExecuteNonQuery();
                pokaz();
            }
        }
    }
}
