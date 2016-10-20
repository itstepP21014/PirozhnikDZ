using BusinessLogic;
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

namespace SearchBank
{
    /// <summary>
    /// Interaction logic for WindowServices.xaml
    /// </summary>
    public partial class WindowServices : Window
    {
        public WindowServices()
        {
            InitializeComponent();
            BusinessLogic.Context db = new BusinessLogic.Context();
            lbxServ.ItemsSource = db.Services.ToList();
        }

        public List<int> SelectedServices { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedServices = new List<int>();
            foreach(var item in lbxServ.SelectedItems)
            {
                SelectedServices.Add(((Service)item).Id);
            }
            MessageBox.Show("Добавленно!", "Добавленно", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}
