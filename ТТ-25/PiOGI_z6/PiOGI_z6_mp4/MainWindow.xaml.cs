using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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

namespace PiOGI_z6_mp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool times = true;
        System.Windows.Threading.DispatcherTimer t;
        public MainWindow()
        {
            InitializeComponent();
            roll.MediaEnded += theEnd;
            roll.MediaOpened += theBegin;
            t = new System.Windows.Threading.DispatcherTimer();
            t.Tick += new EventHandler(dispatcherTimer_Tick);
            t.Interval = new TimeSpan(0, 0, 0, 0, 700);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            tC.Content = roll.Position.Hours + ":" + roll.Position.Minutes + ":" + roll.Position.Seconds;
            double a = (roll.Position.Hours * 3600 + roll.Position.Minutes * 60 + roll.Position.Seconds);
            double b = (roll.NaturalDuration.TimeSpan.Hours * 3600 + roll.NaturalDuration.TimeSpan.Minutes * 60 + roll.NaturalDuration.TimeSpan.Seconds);
            a = a / b;
            times = false;
            time.Value = (int)(a * 100);
            times = true;
        }
        void theEnd(object sender, EventArgs e)
        {
            
        }
        private void theBegin(object sender, EventArgs e)
        {
            tF.Content = roll.NaturalDuration.TimeSpan.Hours + ":" + roll.NaturalDuration.TimeSpan.Minutes + ":" + roll.NaturalDuration.TimeSpan.Seconds;
            tC.Content = roll.Position.Hours + ":" + roll.Position.Minutes + ":" + roll.Position.Seconds;
        }
        private void opnfl(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "c";
            dlg.DefaultExt = ".mp4";
            dlg.Filter = "video documents (.mp4)|*.mp4";
            if (dlg.ShowDialog() == true)
            {
                SystemSounds.Beep.Play();
                roll.LoadedBehavior = MediaState.Manual;
                roll.UnloadedBehavior = MediaState.Manual;
                roll.Source = new Uri (dlg.FileName, UriKind.Relative);
                roll.Volume = (sond.Value / 100);
                roll.Play();
                t.Start();
            }
        }
        private void stoop(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            roll.Stop();
            tC.Content = "0:0:0";
            time.Value = 0;
        }

        private void strat(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            roll.Play();
            t.Start();
        }
        private void tormoz(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            roll.Pause();
            t.Stop();
        }

        private void sndcng(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            roll.Volume = sond.Value;
        }
        private void othertime(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (times)
            {
                double bc = (roll.NaturalDuration.TimeSpan.Hours * 3600 + roll.NaturalDuration.TimeSpan.Minutes * 60 + roll.NaturalDuration.TimeSpan.Seconds);
                bc = bc * time.Value / 100;
                roll.Position = new TimeSpan((int)(bc / 3600), (int)((bc - ((int)(bc / 3600)) * 3600) / 60), (int)(bc - ((int)(bc / 3600)) * 3600 - ((int)((bc - ((int)(bc / 3600)) * 3600) / 60)) * 60));
                tC.Content = roll.Position.Hours + ":" + roll.Position.Minutes + ":" + roll.Position.Seconds;
            }
        }
    }
}
