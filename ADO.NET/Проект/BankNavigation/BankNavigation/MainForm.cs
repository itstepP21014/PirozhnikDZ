using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankNavigation
{
    public partial class MainForm : Form
    {
        GMapControl gMapControl1;
        double mousePositionX;
        double mousePositionY;
        GMap.NET.WindowsForms.GMapOverlay markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker");
        
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetParamsMap();
        }

        void ShowObjects(List<Branch> objs)
        {
            gMapControl1.Overlays.Clear();
            markersOverlay.Clear();
            foreach (var item in objs)
            {
                ShowMarker(item);
            }
        }

        public void ShowMarker(Branch obj)
        {
            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(obj.XPosition, obj.YPositon), GMarkerGoogleType.yellow);
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = "№" + obj.Id.ToString() + "\n"
                               + obj.Name.ToString() + "\n"
                //+ "Bank: " + item.Bank.Name.ToString() + "\n"
                //+ "$ sell: " + item.Bank.DollarSell.ToString() + "\n"
                //+ "$ buy: " + item.Bank.DollarBuy.ToString() + "\n"
                //+ "Э sell: " + item.Bank.EuroSell.ToString() + "\n"
                //+ "Э buy: " + item.Bank.EuroBuy.ToString() + "\n"
                //+ "R sell: " + item.Bank.RussSell.ToString() + "\n"
                //+ "R buy: " + item.Bank.RussBuy.ToString() + "\n"
                               + "Phone: " + obj.Phone.ToString() + "\n"
                //+ item.Adress.City + ", " + item.Adress.City + ", " + item.Adress.Build + "/" + item.Adress.Body + "-" + item.Adress.Cabinet + "\n"
                               + "Working time: " + obj.Time.ToString() + "\n"
                //+ "Cashier: " + item.Cashier.FirstName.ToString() + " " + item.Cashier.LastName.ToString() + "\n"
                //+ "Provided services: ";
                               ;
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);    
        }

        void SetParamsMap()
        {
            gMapControl1 = new GMapControl();
            gMapControl1.Dock = DockStyle.Fill;
            this.Controls.Add(gMapControl1);

            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            gMapControl1.Bearing = 0;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.Zoom = 17;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);
            gMapControl1.MarkersEnabled = true;

            ShowObjects(DBHandler.getObjects());

            gMapControl1.MouseClick += gMapControl1_MouseClick;

        }

        void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mousePositionX = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
                mousePositionY = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
                cmsCreate_Delete.Show(MousePosition);
                
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateObjectForm createObjectForm = new CreateObjectForm();
            createObjectForm.PositionX = mousePositionX;
            createObjectForm.PositionY = mousePositionY;
            createObjectForm.ShowDialog();
            ShowObjects(DBHandler.getObjects());
        }

        private void deteteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int marker = 0; marker < markersOverlay.Markers.Count; ++marker )
            {
                if (markersOverlay.Markers[marker].IsMouseOver == true)
                {
                    double x = markersOverlay.Markers[marker].Position.Lat;
                    double y = markersOverlay.Markers[marker].Position.Lng;
                    Branch obj = DBHandler.getObjects().FirstOrDefault(b => (b.XPosition == x && b.YPositon == y));
                    DBHandler.deleteObject(obj);
                    ShowObjects(DBHandler.getObjects());
                    break;
                }
            }
            
        }

    }
}
