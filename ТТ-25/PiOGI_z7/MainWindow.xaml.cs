using System;
using System.Collections.Generic;
using System.Linq;
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
using static System.Formats.Asn1.AsnWriter;

namespace PiOGI_z7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer t;
        int min, hour, sec;
        Line hourl, minl, secl;
        public void drawchas()
        {
            Ellipse chasu = new Ellipse();
            SolidColorBrush bruh = new SolidColorBrush();
            bruh.Color = Color.FromArgb(255, 47, 23, 249);
            chasu.StrokeThickness = 5;
            SolidColorBrush bruh2 = new SolidColorBrush();
            bruh2.Color = Color.FromArgb(255, 241, 234, 197);
            chasu.Fill = bruh2;
            chasu.Stroke = bruh;
            chasu.Width = 600;
            chasu.Height = 600;
            chasu.Margin = new Thickness(0, 0, 0, 0);
            scene.Children.Add(chasu);

            Ellipse center = new Ellipse();
            center.StrokeThickness = 5.7;
            center.Fill = System.Windows.Media.Brushes.Black;
            center.Stroke = System.Windows.Media.Brushes.Black;
            center.Width = 8;
            center.Height = 8;
            center.Margin = new Thickness(296, 296, 0, 0);
            scene.Children.Add(center);

            Ellipse[] chmetka = new Ellipse[12];
            Label[] chcifra = new Label[12];
            for (int i = 0; i < 12; i++)
            {
                chmetka[i] = new Ellipse();
                chmetka[i].Fill = System.Windows.Media.Brushes.Black;
                chmetka[i].Stroke = System.Windows.Media.Brushes.Black;
                chmetka[i].StrokeThickness = 5.7;
                chmetka[i].Width = 8;
                chmetka[i].Height = 8;
                chmetka[i].Margin = new Thickness(296 * Math.Sin(Math.PI / 6 * i) + 296, 296 * Math.Cos(Math.PI / 6 * i) + 296, 0, 0);
                scene.Children.Add(chmetka[i]);

                chcifra[i] = new Label();
                chcifra[i].Width = 40;
                chcifra[i].Height = 40;
                chcifra[i].Content = i;
                chcifra[i].FontSize = 24;
                chcifra[i].FontWeight = FontWeights.Bold;
                chcifra[i].HorizontalAlignment = HorizontalAlignment.Left;
                chcifra[i].VerticalAlignment = VerticalAlignment.Bottom;
                chcifra[i].Margin = new Thickness(-275 * Math.Sin(Math.PI / 6 * i) + 310, 275 * Math.Cos(Math.PI / 6 * i) + 320, 0, 0);
                RotateTransform rotate = new RotateTransform(180);
                chcifra[i].RenderTransform = rotate;
                scene.Children.Add(chcifra[i]);
            }
        }
        public MainWindow()
        {
            
            sec = DateTime.Now.Second;
            min = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;
            InitializeComponent();
            drawchas();

            hourl = new Line();
            hourl.Stroke = System.Windows.Media.Brushes.Black;
            hourl.HorizontalAlignment = HorizontalAlignment.Left;
            hourl.VerticalAlignment = VerticalAlignment.Bottom;
            hourl.X1 = 0+300;
            hourl.Y1 = 0+300;
            hourl.X2 = -180 * Math.Sin(Math.PI / 6 * hour) + 300;
            hourl.Y2 = 180 * Math.Cos(Math.PI / 6 * hour) + 300;
            hourl.StrokeThickness = 11;
            minl = new Line();
            minl.Stroke = System.Windows.Media.Brushes.CadetBlue;
            minl.HorizontalAlignment = HorizontalAlignment.Center;
            minl.VerticalAlignment = VerticalAlignment.Center;
            minl.X1 = 0 + 300;
            minl.Y1 = 0 + 300;
            minl.X2 = -225 * Math.Sin(Math.PI / 30 * min) + 300;
            minl.Y2 = 225 * Math.Cos(Math.PI / 30 * min) + 300;
            minl.StrokeThickness = 4;
            secl = new Line();
            secl.Stroke = System.Windows.Media.Brushes.DarkGreen;
            secl.HorizontalAlignment = HorizontalAlignment.Center;
            secl.VerticalAlignment = VerticalAlignment.Center;
            secl.X1 = 0 + 300;
            secl.Y1 = 0 + 300;
            secl.X2 = -260 * Math.Sin(Math.PI / 30 * sec) + 300;
            secl.Y2 = 260 * Math.Cos(Math.PI / 30 * sec) + 300;
            secl.StrokeThickness = 2;
            scene.Children.Add(secl);
            scene.Children.Add(minl);
            scene.Children.Add(hourl);
            t = new System.Windows.Threading.DispatcherTimer();
            t.Tick += new EventHandler(dispatcherTimer_Tick);
            t.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            t.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            sec = DateTime.Now.Second;
            min = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;
            hourl.X2 = -180 * Math.Sin(Math.PI / 6 * hour) + 300;
            hourl.Y2 = 180 * Math.Cos(Math.PI / 6 * hour) + 300;
            minl.X2 = -225 * Math.Sin(Math.PI / 30 * min) + 300;
            minl.Y2 = 225 * Math.Cos(Math.PI / 30 * min) + 300;
            secl.X2 = -260 * Math.Sin(Math.PI / 30 * sec) + 300;
            secl.Y2 = 260 * Math.Cos(Math.PI / 30 * sec) + 300;
        }
    }
}
