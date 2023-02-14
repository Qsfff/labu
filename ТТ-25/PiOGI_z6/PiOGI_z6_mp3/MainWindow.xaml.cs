using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Security.Policy;
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

namespace PiOGI_z6_mp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> snds = new Dictionary<string, string>();
        MediaPlayer player = new MediaPlayer();
        bool random = false;
        bool times = true;
        Random rnd = new Random();
        System.Windows.Threading.DispatcherTimer t;
        public MainWindow()
        {
            InitializeComponent();
            player.MediaEnded += theEnd;
            player.MediaOpened += theBegin;
            t = new System.Windows.Threading.DispatcherTimer();
            t.Tick += new EventHandler(dispatcherTimer_Tick);
            t.Interval = new TimeSpan(0, 0, 0, 0, 700);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            tC.Content = player.Position.Hours + ":" + player.Position.Minutes + ":" + player.Position.Seconds;
            double a = (player.Position.Hours * 3600 + player.Position.Minutes * 60 + player.Position.Seconds); 
            double b = (player.NaturalDuration.TimeSpan.Hours * 3600 + player.NaturalDuration.TimeSpan.Minutes * 60 + player.NaturalDuration.TimeSpan.Seconds);
            a = a / b;
            times = false;
            time.Value = (int)(a * 100);
            times = true;
        }
        void theEnd(object sender, EventArgs e)
        {
            if (!random)
            {
                int i = list.SelectedIndex;
                list.SelectedIndex = -1;
                if (i + 1 == snds.Count) list.SelectedIndex = 0;
                else list.SelectedIndex = i + 1;
            }
            else
            {
                list.SelectedIndex = -1;
                list.SelectedIndex = rnd.Next(0, snds.Count);
            }
        }
        private void theBegin(object sender, EventArgs e)
        {
            tF.Content = player.NaturalDuration.TimeSpan.Hours + ":" + player.NaturalDuration.TimeSpan.Minutes + ":" + player.NaturalDuration.TimeSpan.Seconds;
            tC.Content = player.Position.Hours + ":" + player.Position.Minutes + ":" + player.Position.Seconds;
        }

        private void usefile(object sender, SelectionChangedEventArgs e)
        {
            SystemSounds.Beep.Play();
            t.Stop();
            if (list.SelectedIndex != -1)
            {
                player.Open(new Uri(snds[(string)list.SelectedValue], UriKind.Relative));
                player.Volume = (soulnd.Value / 100);
                player.Play();
                t.Start();
            }
        }
        private void randomorder(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            random = true;
        }
        private void opnfl(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "c";
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "sound documents (.mp3)|*.mp3";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == true)
                foreach (String file in dlg.FileNames)
                    if (!snds.ContainsValue(file))
                    {
                        SystemSounds.Beep.Play();
                        string s = file.Remove(0, file.LastIndexOf('\\') + 1);
                        s = s.Remove(s.LastIndexOf("."));
                        if (snds.ContainsKey(s))
                        {
                            s += "1";
                        }
                        list.Items.Add(s);
                        snds.Add(s, file);
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        MessageBox.Show("Uzhe v spiske", "Ashipka");
                    }
        }
        private void stoop(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            player.Stop();
            tC.Content = "0:0:0";
            time.Value = 0;
            list.SelectedIndex = -1;
        }

        private void strat(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            player.Play();
            t.Start();
        }
        private void directorder(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            random = false;
        }
        private void tormoz(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            player.Pause();
            t.Stop();
        }
        private void othersound(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = (soulnd.Value / 100);
        }
        private void othertime(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (times)
            {
                double bc = (player.NaturalDuration.TimeSpan.Hours * 3600 + player.NaturalDuration.TimeSpan.Minutes * 60 + player.NaturalDuration.TimeSpan.Seconds);
                bc = bc * time.Value / 100;
                player.Position = new TimeSpan((int)(bc / 3600), (int)((bc - ((int)(bc / 3600)) * 3600) / 60), (int)(bc - ((int)(bc / 3600)) * 3600 - ((int)((bc - ((int)(bc / 3600)) * 3600) / 60)) * 60));
                tC.Content = player.Position.Hours + ":" + player.Position.Minutes + ":" + player.Position.Seconds;
            }
        }
    }
}
