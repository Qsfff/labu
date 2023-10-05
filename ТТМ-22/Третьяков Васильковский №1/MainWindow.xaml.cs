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
using static System.Formats.Asn1.AsnWriter;

namespace Третьяков_Васильковский__1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int form = 0;
        point4_90 rect;
        point3 trian;
        point poi;
        bool creating = true;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void ineedpoints(object sender, RoutedEventArgs e)
        {
            holst.Children.RemoveRange(0, holst.Children.Count);
            Ellipse pointa = new Ellipse();
            pointa.Fill = System.Windows.Media.Brushes.Black;
            pointa.Stroke = System.Windows.Media.Brushes.Black;
            pointa.Width = 5;
            pointa.Height = 5;
            point pt = new point((rnd.NextDouble() * 2 - 1) * 300, (rnd.NextDouble() * 2 - 1) * 150);
            pointa.Margin = new Thickness(pt.whereX(), pt.whereY(), 0, 0);
            holst.Children.Add(pointa);
            form = 1;
            creating = true;
            xpos.Value = pt.whereX();
            ypos.Value = pt.whereY();
            creating = false;
            poi = pt;
        }
        private void ineedlinus3(point a, point b)
        {
            Line line = new Line();
            line.StrokeThickness = 3;
            line.Stroke = System.Windows.Media.Brushes.Chartreuse;
            line.X1 = a.whereX();
            line.Y1 = a.whereY();
            line.X2 = b.whereX();
            line.Y2 = b.whereY();
            holst.Children.Add(line);
        }
        private void ineedlinus4(point a, point b)
        {
            Line line = new Line();
            line.StrokeThickness = 3;
            line.Stroke = System.Windows.Media.Brushes.CornflowerBlue;
            line.X1 = a.whereX();
            line.Y1 = a.whereY();
            line.X2 = b.whereX();
            line.Y2 = b.whereY();
            holst.Children.Add(line);
        }
        private void ineedtris(object sender, RoutedEventArgs e)
        {
            holst.Children.RemoveRange(0, holst.Children.Count);
            point a = new point((rnd.NextDouble() * 2 - 1) * 300 + 100, (rnd.NextDouble() * 2 - 1) * 150 + 50);
            point b = new point((rnd.NextDouble() * 2 - 1) * 300 + 100, (rnd.NextDouble() * 2 - 1) * 150 + 50);
            point c = new point((rnd.NextDouble() * 2 - 1) * 300 + 100, (rnd.NextDouble() * 2 - 1) * 150 + 50);
            point3 rec = new point3(a, b, c);
            ineedlinus3(a, b);
            ineedlinus3(a, c);
            ineedlinus3(c, b);
            creating = true;
            xpos.Value = a.whereX();
            ypos.Value = a.whereY();
            creating = false;
            form = 3;
            trian = rec;
            perim.Content = "Perimetr: " + trian.permet();
            plo.Content = "Plosad: " + trian.size();
        }
        private void ineedrectus(object sender, RoutedEventArgs e)
        {
            holst.Children.RemoveRange(0, holst.Children.Count);
            double h = rnd.NextDouble() * 100 + 1;
            double l = rnd.NextDouble() * 200 + 1;
            double px = (rnd.NextDouble() * 2 - 1) * 250 + 50;
            double py = (rnd.NextDouble() * 2 - 1) * 125 + 15;
            point4_90 rec = new point4_90(px, py, l, h);
            ineedlinus4(rec.theA(), rec.theB());
            ineedlinus4(rec.theA(), rec.theC());
            ineedlinus4(rec.theD(), rec.theB());
            ineedlinus4(rec.theD(), rec.theC());
            creating = true;
            xpos.Value = rec.theA().whereX();
            ypos.Value = rec.theA().whereY();
            creating = false;
            form = 4;
            rect = rec;
            perim.Content = "Perimetr: " + rect.permet();
            plo.Content = "Plosad: " + rect.size();
        }

        private void theRector(object sender, RoutedEventArgs e)
        {
            holst.Children.RemoveRange(0, holst.Children.Count);
            double h = double.Parse(hei.Text);
            double l = double.Parse(len.Text);
            double px = double.Parse(posx.Text);
            double py = double.Parse(posy.Text);
            point4_90 rec = new point4_90(px, py, l, h);
            ineedlinus4(rec.theA(), rec.theB());
            ineedlinus4(rec.theA(), rec.theC());
            ineedlinus4(rec.theD(), rec.theB());
            ineedlinus4(rec.theD(), rec.theC());
            creating = true;
            xpos.Value = rec.theA().whereX();
            ypos.Value = rec.theA().whereY();
            creating = false;
            form = 4;
            rect = rec;
            perim.Content = "Perimetr: " + rect.permet();
            plo.Content = "Plosad: " + rect.size();
        }

        private void xcha(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!creating)
            {
                if (form == 1)
                {
                    poi.move(xpos.Value - poi.whereX() + 100);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    Ellipse pointa = new Ellipse();
                    pointa.Fill = System.Windows.Media.Brushes.Black;
                    pointa.Stroke = System.Windows.Media.Brushes.Black;
                    pointa.Width = 5;
                    pointa.Height = 5;
                    pointa.Margin = new Thickness(poi.whereX(), poi.whereY(), 0, 0);
                    holst.Children.Add(pointa);
                }
                if (form == 3)
                {
                    trian.move(xpos.Value - trian.the1().whereX() + 100);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    ineedlinus3(trian.the1(), trian.the2());
                    ineedlinus3(trian.the1(), trian.the3());
                    ineedlinus3(trian.the3(), trian.the2());
                }
                if (form == 4)
                {
                    rect.move(xpos.Value - rect.theA().whereX() + 100);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    ineedlinus4(rect.theA(), rect.theB());
                    ineedlinus4(rect.theA(), rect.theC());
                    ineedlinus4(rect.theD(), rect.theB());
                    ineedlinus4(rect.theD(), rect.theC());
                }
            }
        }

        private void ycha(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!creating)
            {
                if (form == 1)
                {
                    poi.moveY(ypos.Value - poi.whereY() + 50);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    Ellipse pointa = new Ellipse();
                    pointa.Fill = System.Windows.Media.Brushes.Black;
                    pointa.Stroke = System.Windows.Media.Brushes.Black;
                    pointa.Width = 5;
                    pointa.Height = 5;
                    pointa.Margin = new Thickness(poi.whereX(), poi.whereY(), 0, 0);
                    holst.Children.Add(pointa);
                }
                if (form == 3)
                {
                    trian.moveY(ypos.Value - trian.the1().whereY() + 50);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    ineedlinus3(trian.the1(), trian.the2());
                    ineedlinus3(trian.the1(), trian.the3());
                    ineedlinus3(trian.the3(), trian.the2());
                }
                if (form == 4)
                {
                    rect.moveY(ypos.Value - rect.theA().whereY() + 50);
                    holst.Children.RemoveRange(0, holst.Children.Count);
                    ineedlinus4(rect.theA(), rect.theB());
                    ineedlinus4(rect.theA(), rect.theC());
                    ineedlinus4(rect.theD(), rect.theB());
                    ineedlinus4(rect.theD(), rect.theC());
                }
            }
        }
    }
    public class point // точка
    {
        private double x;
        private double y;
        public point(double a = 0, double b = 0)
        {
            x = a;
            y = b;
        }
        public double whereX() { return x; }
        public double whereY() { return y; }
        public double[] thepoint()
        {
            double[] q = { whereX(), whereY() };
            return q;
        }
        public void move(double a, double b)
        {
            x = x + a;
            y = y + b;
        }
        public void move(double a)
        {
            x = x + a;
        }
        public void moveY(double a)
        {
            y = y + a;
        }
        public double range(point b)
        {
            return Math.Abs(Math.Sqrt(((x - b.whereX()) * (x - b.whereX())) + ((y - b.whereY()) * (y - b.whereY()))));
        }
    }
    public class point3   // трёхточечник
    {
        private point x;
        private point y;
        private point z;
        public point3(double[] a, double[] b, double[] c)
        {
            x = new point(a[0], a[1]);
            y = new point(b[0], b[1]);
            z = new point(c[0], c[1]);
        }
        public point3(point a, point b, point c)
        {
            x = a;
            y = b;
            z = c;
        }
        public point the1() { return x; }
        public point the2() { return y; }
        public point the3() { return z; }
        public void move(double a, double b)
        {
            x.move(a, b);
            y.move(a, b);
            z.move(a, b);
        }
        public void move(double a)
        {
            x.move(a);
            y.move(a);
            z.move(a);
        }
        public void moveY(double a)
        {
            x.moveY(a);
            y.moveY(a);
            z.moveY(a);
        }
        public double permet()
        {
            return x.range(y) + z.range(y) + x.range(z);
        }
        public double size()
        {
            double q = permet() / 2;
            return Math.Sqrt(q * (q - x.range(y)) * (q - z.range(y)) * (q - x.range(z)));
        }
    }
    public class point4_90 // четырёхточечник с прямыми углами
    {
        private point x;
        private point y;
        private point z;
        private point f;
        public point4_90(double a, double b, double c, double d)
        {
            x = new point(a, b);
            y = new point(a + c, b);
            z = new point(a, b + d);
            f = new point(a + c, b + d);
        }
        public point4_90(double[] a, double[] b, double[] c, double[] d)
        {
            if ((a[1] == b[1]) && (a[0] == c[0]) && (c[1] == d[1]))
            {
                x = new point(a[0], a[1]);
                y = new point(b[0], b[1]);
                z = new point(c[0], c[1]);
                f = new point(d[0], d[1]);
            }
            else
            {
                x = new point(0, 0);
                y = new point(1, 0);
                z = new point(0, 1);
                f = new point(1, 1);
            }
        }
        public point4_90(point a, point b, point c, point d)
        {
            if ((a.whereY() == b.whereY()) && (a.whereX() == c.whereX()) && (c.whereY() == d.whereY()))
            {
                x = a;
                y = b;
                z = c;
                f = d;
            }
            else
            {
                x = new point(0, 0);
                y = new point(1, 0);
                z = new point(0, 1);
                f = new point(1, 1);
            }
        }
        public point theA() { return x; }
        public point theB() { return y; }
        public point theC() { return z; }
        public point theD() { return f; }
        public void move(double a, double b)
        {
            x.move(a, b);
            y.move(a, b);
            z.move(a, b);
            f.move(a, b);
        }
        public void move(double a)
        {
            x.move(a);
            y.move(a);
            z.move(a);
            f.move(a);
        }
        public void moveY(double a)
        {
            x.moveY(a);
            y.moveY(a);
            z.moveY(a);
            f.moveY(a);
        }
        public double permet()
        {
            return (x.range(y) + x.range(z)) * 2;
        }
        public double size()
        {
            return x.range(y) * x.range(z);
        }
    }
}