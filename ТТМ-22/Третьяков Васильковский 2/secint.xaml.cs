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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;

namespace Третьяков_Васильковский_2
{
    /// <summary>
    /// Логика взаимодействия для secint.xaml
    /// </summary>
    public partial class secint : Window
    {
        loc SP = null;
        public List<PointLatLng> points;
        public secint(PointLatLng b)
        {
            InitializeComponent();
            loc FP = new loc("First point", b);
            map.Markers.Add(FP.mark());
            points = new PointLatLng[] { FP.foc() }.ToList();
            map.Position = FP.foc();
        }
        private void MapLoaded(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.MapProvider = GoogleMapProvider.Instance;
            map.MinZoom = 1;
            map.MaxZoom = 17;
            map.Zoom = 10;
            map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            map.CanDragMap = true;
            map.DragButton = MouseButton.Middle;
            map.ShowCenter = false;
        }
        private void choskoor(object sender, MouseButtonEventArgs e)
        {
            if (SP != null) { map.Markers.Remove(SP.mark()); }
            PointLatLng a = map.FromLocalToLatLng((int)e.GetPosition(map).X, (int)e.GetPosition(map).Y);
            latude.Content = a.Lat.ToString("#.######");
            lontude.Content = a.Lng.ToString("#.######");
            SP = new loc("Selected point", new PointLatLng(Convert.ToDouble(latude.Content.ToString()), Convert.ToDouble(lontude.Content)));
            map.Markers.Add(SP.mark());
        }

        private void zeOk(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void plasplas(object sender, RoutedEventArgs e)
        {
            loc pts = new loc("Added point", SP.foc());
            map.Markers.Add(SP.mark());
            points.Add(pts.foc());
        }
    }
}
