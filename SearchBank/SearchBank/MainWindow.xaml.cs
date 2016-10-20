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
using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsPresentation;
using SearchBank.CustomMarkers;


namespace SearchBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GMapMarker currentMarker;
        BusinessLogic.Logic logic;

        public MainWindow()
        {
            InitializeComponent();
            logic = new BusinessLogic.Logic();
            logic.LoadDate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.Bearing = 0;
            gMapControl.MaxZoom = 20;
            gMapControl.MinZoom = 2;
            gMapControl.Zoom = 17;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.CanDragMap = true;
            gMapControl.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);
            gMapControl.CanDragMap = true;
            gMapControl.ShowCenter = false;
            addMarker();

        }

        private void addMarker()
        {
            currentMarker = new GMapMarker(gMapControl.Position);
            {
                currentMarker.Shape = new CustomMarkerRed(this, currentMarker, "");
                currentMarker.Offset = new System.Windows.Point(53.902800, 27.561759);
                currentMarker.ZIndex = int.MaxValue;
            }
            SetBranch();
            gMapControl.Markers.Add(currentMarker);
        }

        private void SetBranch()
        {
            foreach(var item in logic.ReturnInfoBranchs())
            {
                GMapMarker marker = new GMapMarker(gMapControl.Position);
                {
                    marker.Shape = new CustomMarkerDemo(this, marker, item.info);
                    marker.Position = new GMap.NET.PointLatLng(item.coordX, item.coordY);
                    marker.ZIndex = int.MaxValue;
                }
                gMapControl.Markers.Add(marker);
            }
            
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(gMapControl);
            currentMarker.Position = gMapControl.FromLocalToLatLng((int)p.X, (int)p.Y);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowAddBranch win = new WindowAddBranch(logic);
                win.ShowDialog();
                if (win.Brch != null)
                {
                    win.Brch.CoordX = currentMarker.Position.Lat;
                    win.Brch.CoordY = currentMarker.Position.Lng;
                    logic.AddObject(win.Brch, win.Index, win.SelectedServices);
                    MessageBox.Show("Добавленно!", "Добавленно", MessageBoxButton.OK, MessageBoxImage.Information);
                    SetBranch();
                }
                else
                    MessageBox.Show("Ошибка добавления! Данные не добавленны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Критическая ошибка!", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try {
                WindowAddReview win = new WindowAddReview(logic);
                win.ShowDialog();
                logic.AddReview(win.Review, win.IndexBranch);
                MessageBox.Show("Добавленно!", "Добавленно", MessageBoxButton.OK, MessageBoxImage.Information);
                SetBranch();
            }
            catch(Exception)
            {
                MessageBox.Show("Критическая ошибка!", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }
    }
}
