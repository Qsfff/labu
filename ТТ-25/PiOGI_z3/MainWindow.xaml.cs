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

namespace PiOGI_z3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        struct timers
        {
            public int Chas;
            public int Minuta;
            public int Secunda;
            public int Day;
            public int Month;
            public int Year;
            public timers(int Chas = 0, int Minuta = 0, int Secunda = 0, int Day = 1, int Month = 1, int Year = 3000)
            {
                this.Chas = Chas;
                this.Minuta = Minuta;
                this.Secunda = Secunda;
                this.Day = Day;
                this.Month = Month;
                this.Year = Year;
            }
        }
        Dictionary<string, timers> list = new Dictionary<string, timers>();
        int chasu, minu, seci, dni;
        System.Windows.Threading.DispatcherTimer t;
        public MainWindow()
        {
            InitializeComponent();
            t = new System.Windows.Threading.DispatcherTimer();
            t.Tick += new EventHandler(dispatcherTimer_Tick);
            t.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }
        public void antitimer()
        {
            if (timeru.SelectedIndex != -1)
            {
                list.Remove((string)timeru.SelectedValue);
                timeru.Items.RemoveAt(timeru.SelectedIndex);
            }
            timeru.SelectedIndex = -1;
        }
        public void output()
        {
            if (cb.SelectedIndex == 0) res.Content = dni + ":" + chasu + ":" + minu + ":" + seci;
            if (cb.SelectedIndex == 1) res.Content = (dni * 24 + chasu) + ":" + minu + ":" + seci;
            if (cb.SelectedIndex == 2) res.Content = ((dni * 24 + chasu) * 60 + minu) + ":" + seci;
            if (cb.SelectedIndex == 3) res.Content = (((dni * 24 + chasu) * 60 + minu) * 60 + seci);
        }
        private void Udolil(object sender, RoutedEventArgs e)
        {
            antitimer();
        }

        private void ooknovulezlo(object sender, RoutedEventArgs e)
        {
            DateSelection add_ = new DateSelection();
            if (add_.ShowDialog() == true)
            {
                timers timEr = new timers(int.Parse(add_.Chasis.Text), int.Parse(add_.Minutis.Text), int.Parse(add_.Secundis.Text), int.Parse(add_.Denis.Text), int.Parse(add_.Mesyacis.Text), int.Parse(add_.Godis.Text));
                if ((DateTime.Now.Year < timEr.Year) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month < timEr.Month)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day < timEr.Day)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour < timEr.Chas)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour == timEr.Chas) && (DateTime.Now.Minute < timEr.Minuta)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour == timEr.Chas) && (DateTime.Now.Minute == timEr.Minuta) && (DateTime.Now.Second < timEr.Secunda)))
                {
                    list.Add(add_.Nazva.Text, timEr);
                    timeru.Items.Add(add_.Nazva.Text);
                }
                else MessageBox.Show("Ukazano proshloe", "Ashipka"/*, MessageBoxButton.OK*/);
            }

        }

        private void peremenu(object sender, RoutedEventArgs e)
        {
            if (timeru.SelectedIndex != -1)
            {
                DateSelection add_ = new DateSelection();
                add_.Nazva.Text = (string)timeru.SelectedValue;
                add_.Chasis.Text = list[(string)timeru.SelectedValue].Chas.ToString();
                add_.Minutis.Text = list[(string)timeru.SelectedValue].Minuta.ToString();
                add_.Secundis.Text = list[(string)timeru.SelectedValue].Secunda.ToString();
                add_.Denis.Text = list[(string)timeru.SelectedValue].Day.ToString();
                add_.Mesyacis.Text = list[(string)timeru.SelectedValue].Month.ToString();
                add_.Godis.Text = list[(string)timeru.SelectedValue].Year.ToString();
                if (add_.ShowDialog() == true)
                {
                    antitimer();
                    timers timEr = new timers(int.Parse(add_.Chasis.Text), int.Parse(add_.Minutis.Text), int.Parse(add_.Secundis.Text), int.Parse(add_.Denis.Text), int.Parse(add_.Mesyacis.Text), int.Parse(add_.Godis.Text));
                    if ((DateTime.Now.Year < timEr.Year) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month < timEr.Month)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day < timEr.Day)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour < timEr.Chas)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour == timEr.Chas) && (DateTime.Now.Minute < timEr.Minuta)) || ((DateTime.Now.Year == timEr.Year) && (DateTime.Now.Month == timEr.Month) && (DateTime.Now.Day == timEr.Day) && (DateTime.Now.Hour == timEr.Chas) && (DateTime.Now.Minute == timEr.Minuta) && (DateTime.Now.Second < timEr.Secunda)))
                    {
                        list.Add(add_.Nazva.Text, timEr);
                        timeru.Items.Add(add_.Nazva.Text);
                    }
                    else MessageBox.Show("Ukazano proshloe", "Ashipka"/*, MessageBoxButton.OK*/);
                }
            }
        }
        private void load(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "c";
            dlg.DefaultExt = ".tmr";
            dlg.Filter = "Sohranennue timeru (.tmr)|*.tmr";
            if (dlg.ShowDialog() == true)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);
                string name = file.ReadLine();
                timers timEr = new timers(int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                list.Add(name, timEr);
                timeru.Items.Add(name);
                file.Close();
            }
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (timeru.SelectedIndex != -1)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "c";
                dlg.DefaultExt = ".tmr";
                dlg.Filter = "Sohranennue timeru (.tmr)|*.tmr";
                if (dlg.ShowDialog() == true)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(dlg.FileName);
                    file.WriteLine((string)timeru.SelectedValue);
                    file.WriteLine(list[(string)timeru.SelectedValue].Chas.ToString());
                    file.WriteLine(list[(string)timeru.SelectedValue].Minuta.ToString());
                    file.WriteLine(list[(string)timeru.SelectedValue].Secunda.ToString());
                    file.WriteLine(list[(string)timeru.SelectedValue].Day.ToString());
                    file.WriteLine(list[(string)timeru.SelectedValue].Month.ToString());
                    file.WriteLine(list[(string)timeru.SelectedValue].Year.ToString());
                    file.Close();
                }
            }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            seci -= 1;
            if (seci < 0)
            {
                seci += 60;
                minu -= 1;
            }
            if (minu < 0)
            {
                minu += 60;
                chasu -= 1;
            }
            if (chasu < 0)
            {
                chasu += 24;
                dni -= 1;
            }
            if (dni < 0)
            {
                t.Stop();
                antitimer();
            }
            else output();
        }

        private void timeisrunningout(object sender, SelectionChangedEventArgs e)
        {
            if (timeru.SelectedIndex != -1)
            {
                t.Stop();
                dni = 0;
                for (int i = 1; i < list[(string)timeru.SelectedValue].Month; i++)
                {
                    if (i == 1) dni += 31;
                    if ((i == 2) && ((list[(string)timeru.SelectedValue].Year % 4) != 0)) dni += 28;
                    if ((i == 2) && ((list[(string)timeru.SelectedValue].Year % 4) == 0)) dni += 29;
                    if (i == 3) dni += 31;
                    if (i == 4) dni += 30;
                    if (i == 5) dni += 31;
                    if (i == 6) dni += 30;
                    if (i == 7) dni += 31;
                    if (i == 8) dni += 31;
                    if (i == 9) dni += 30;
                    if (i == 10) dni += 31;
                    if (i == 11) dni += 30;
                }
                dni += list[(string)timeru.SelectedValue].Day;
                for (int i = 1; i < DateTime.Now.Month; i++)
                {
                    if (i == 1) dni -= 31;
                    if ((i == 2) && ((DateTime.Now.Year % 4) != 0)) dni -= 28;
                    if ((i == 2) && ((DateTime.Now.Year % 4) == 0)) dni -= 29;
                    if (i == 3) dni -= 31;
                    if (i == 4) dni -= 30;
                    if (i == 5) dni -= 31;
                    if (i == 6) dni -= 30;
                    if (i == 7) dni -= 31;
                    if (i == 8) dni -= 31;
                    if (i == 9) dni -= 30;
                    if (i == 10) dni -= 31;
                    if (i == 11) dni -= 30;
                }
                dni -= DateTime.Now.Day;
                for (int i = DateTime.Now.Year; i < list[(string)timeru.SelectedValue].Year; i++)
                {
                    if ((i % 4) == 0) dni += 366;
                    else dni += 365;
                }
                chasu = list[(string)timeru.SelectedValue].Chas - DateTime.Now.Hour;
                minu = list[(string)timeru.SelectedValue].Minuta - DateTime.Now.Minute;
                seci = list[(string)timeru.SelectedValue].Secunda - DateTime.Now.Second;
                t.Start();
            }
        }
    }
}