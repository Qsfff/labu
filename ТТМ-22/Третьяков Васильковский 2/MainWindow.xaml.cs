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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace Третьяков_Васильковский_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        loc SP = null;
        List<mobj> mobjs = new List<mobj> { };
        Dictionary<string, mobj> LBD = new Dictionary<string, mobj>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void curse(PointLatLng a)
        {
            LBM.Items.Clear();
            LBD.Clear();
            if (SP != null) { map.Markers.Remove(SP.mark()); }
            latude.Content = a.Lat.ToString("#.######");
            lontude.Content = a.Lng.ToString("#.######");
            SP = new loc("Selected point", new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
            map.Markers.Add(SP.mark());
            Dictionary<mobj, double> rgs = new Dictionary<mobj, double>();
            for (int i = 0; i < mobjs.Count; i++)
            {
                rgs.Add(mobjs[i], mobjs[i].range(SP.foc()));
            }
            rgs = rgs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            mobj[] tmp = new mobj[rgs.Count];
            rgs.Keys.CopyTo(tmp, 0);
            mobjs = tmp.ToList();
            foreach (mobj item in mobjs)
            {
                LBM.Items.Add(item.myname());
                LBD.Add(item.myname(), item);
            }
        }
        private void MapLoaded(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.MapProvider = GoogleMapProvider.Instance;
            map.MinZoom = 1;
            map.MaxZoom = 17;
            map.Zoom = 13;
            map.Position = new PointLatLng(55.012965, 82.950468);
            curse(map.Position);
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            map.CanDragMap = true;
            map.DragButton = MouseButton.Middle;
            map.ShowCenter = false;
        }

        private void choskoor(object sender, MouseButtonEventArgs e)
        {
            curse(map.FromLocalToLatLng((int)e.GetPosition(map).X, (int)e.GetPosition(map).Y));
        }
        private void theCYM(object sender, MouseButtonEventArgs e)
        {
            CYM aCYM = new CYM();
            aCYM.ShowDialog();
            if (aCYM.YM == "h")
            {
                human A = new human(aCYM.name.Text.ToString(), new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
                mobjs.Add(A);
                map.Markers.Add(A.mark());
            }
            else if (aCYM.YM == "c")
            {
                car A = new car(aCYM.name.Text.ToString(), new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
                mobjs.Add(A);
                map.Markers.Add(A.mark());
            }
            else if (aCYM.YM == "a")
            {
                area A = new area(aCYM.name.Text.ToString(), new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
                mobjs.Add(A);
                map.Markers.Add(A.mark());
            }
            else if (aCYM.YM == "r")
            {
                route A = new route(aCYM.name.Text.ToString(), new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
                mobjs.Add(A);
                map.Markers.Add(A.mark());
            }
        }
        private void clr(object sender, RoutedEventArgs e)
        {
            foreach (mobj item in mobjs)
            {
                map.Markers.Remove(item.mark());
            }
        }
        private void teleport(object sender, SelectionChangedEventArgs e)
        {
            if (LBM.SelectedIndex != -1)
            {
                map.Position = LBD[LBM.SelectedValue.ToString()].foc();
                curse(map.Position);
            }
        }
    }
    abstract class mobj
    {
        protected string title;
        protected DateTime cdae = DateTime.Now;
        public mobj(string a)
        {
            title = a;
        }
        public mobj()
        {
            title = "new mobj";
        }
        public string myname() { return title; }
        public DateTime daob() { return cdae; }
        public abstract double range(PointLatLng a);
        public abstract PointLatLng foc();
        public abstract GMapMarker mark();
    }
    class human : mobj
    {
        PointLatLng poi;
        GMapMarker marker;
        public human(string a, PointLatLng b)
        {
            title = a + " " + cdae;
            poi = b;
            Thickness margin = new Thickness();
            margin.Left = -13;
            margin.Top = -32;
            marker = new GMapMarker(b)
            {
                Shape = new Image
                {
                    Width = 32,
                    Height = 32,
                    Margin = margin,
                    ToolTip = title,
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/uman.png")),
                }
            };
        }
        override public PointLatLng foc()
        {
            return poi;
        }
        override public double range(PointLatLng a)
        {
            GeoCoordinate c1 = new GeoCoordinate(poi.Lat, poi.Lng);
            GeoCoordinate c2 = new GeoCoordinate(a.Lat, a.Lng);
            return c1.GetDistanceTo(c2);
        }
        override public GMapMarker mark()
        {
            return marker;
        }
    }
    class car : mobj
    {
        PointLatLng poi;
        GMapMarker marker;
        public car(string a, PointLatLng b)
        {
            title = a + " " + cdae;
            poi = b;
            Thickness margin = new Thickness();
            margin.Left = -16;
            margin.Top = -16;
            marker = new GMapMarker(b)
            {
                Shape = new Image
                {
                    Width = 32,
                    Height = 32,
                    Margin = margin,
                    ToolTip = title,
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/car.png")),
                }
            };
        }
        override public PointLatLng foc()
        {
            return poi;
        }
        override public double range(PointLatLng a)
        {
            GeoCoordinate c1 = new GeoCoordinate(poi.Lat, poi.Lng);
            GeoCoordinate c2 = new GeoCoordinate(a.Lat, a.Lng);
            return c1.GetDistanceTo(c2);
        }
        override public GMapMarker mark()
        {
            return marker;
        }
    }
    class loc : mobj
    {
        PointLatLng poi;
        GMapMarker marker;
        public loc(string a, PointLatLng b)
        {
            title = a;
            poi = b;
            Thickness margin = new Thickness();
            margin.Left = -13;
            margin.Top = -24;
            marker = new GMapMarker(b)
            {
                Shape = new Image
                {
                    Width = 32,
                    Height = 32,
                    Margin = margin,
                    ToolTip = a,
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/loc.png")),
                }
            };
        }
        override public PointLatLng foc()
        {
            return poi;
        }
        override public double range(PointLatLng a)
        {
            GeoCoordinate c1 = new GeoCoordinate(poi.Lat, poi.Lng);
            GeoCoordinate c2 = new GeoCoordinate(a.Lat, a.Lng);
            return c1.GetDistanceTo(c2);
        }
        override public GMapMarker mark()
        {
            return marker;
        }
    }
    class area : mobj
    {
        PointLatLng poi;
        List<PointLatLng> pois;
        GMapMarker marker;
        public area(string a, PointLatLng b)
        {
            title = a + " " + cdae;
            secint Zecond = new secint(b);
            Zecond.ShowDialog();
            pois = Zecond.points;
            marker = new GMapPolygon(pois)
            {
                Shape = new Path
                {
                    Stroke = Brushes.Black, 
                    Fill = Brushes.Cornsilk,
                    ToolTip = title,
                    Opacity = 0.4
                }
            };
            double lt = 0;
            double ln = 0;
            foreach (PointLatLng item in pois)
            {
                lt += item.Lat;
                ln += item.Lng;
            }
            lt = lt / pois.Count;
            ln = ln / pois.Count;
            poi = new PointLatLng(lt, ln);
        }
        override public PointLatLng foc()
        {
            return poi;
        }
        override public double range(PointLatLng a)
        {
            GeoCoordinate c1 = new GeoCoordinate(poi.Lat, poi.Lng);
            GeoCoordinate c2 = new GeoCoordinate(a.Lat, a.Lng);
            return c1.GetDistanceTo(c2);
        }
        override public GMapMarker mark()
        {
            return marker;
        }
    }
    class route : mobj
    {
        PointLatLng poi;
        List<PointLatLng> pois;
        GMapMarker marker;
        public route(string a, PointLatLng b)
        {
            title = a + " " + cdae;
            secint Zecond = new secint(b);
            Zecond.ShowDialog();
            pois = Zecond.points;
            marker = new GMapRoute(pois)
            {
                Shape = new Path
                {
                    Stroke = Brushes.Black,
                    ToolTip = title,
                    Opacity = 0.4,
                    StrokeThickness = 4
                }
            };
            double lt = 0;
            double ln = 0;
            foreach (PointLatLng item in pois)
            {
                lt += item.Lat;
                ln += item.Lng;
            }
            lt = lt / pois.Count;
            ln = ln / pois.Count;
            poi = new PointLatLng(lt, ln);
        }
        override public PointLatLng foc()
        {
            return poi;
        }
        override public double range(PointLatLng a)
        {
            GeoCoordinate c1 = new GeoCoordinate(poi.Lat, poi.Lng);
            GeoCoordinate c2 = new GeoCoordinate(a.Lat, a.Lng);
            return c1.GetDistanceTo(c2);
        }
        override public GMapMarker mark()
        {
            return marker;
        }
    }
}