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
    /// Interaction logic for WindowAddBranch.xaml
    /// </summary>
    public partial class WindowAddBranch : Window
    {
        BusinessLogic.Logic logic;
        public WindowAddBranch(BusinessLogic.Logic logic_)
        {
            InitializeComponent();
            logic = logic_;
            cmbx.ItemsSource = logic.ReturnBanks();
            cmbx.SelectedIndex = 0;
        }

        public BusinessLogic.Branch Brch { get; set; }
        public int Index { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Index = cmbx.SelectedIndex;
            if (!String.IsNullOrEmpty(tbxNameObject.Text) && !String.IsNullOrEmpty(tbxPhone.Text) && !String.IsNullOrEmpty(tbxAddress.Text) &&
                !String.IsNullOrEmpty(dtpckDateOpen.Text) && tmpTimeOpen.Value != null && tmpTimeClose.Value != null && tmpBreakFrom.Value != null &&
                tmpBreakTo.Value != null)
            {
                Brch = new BusinessLogic.Branch()
                {
                    Name = tbxNameObject.Text,
                    Phone = tbxPhone.Text,
                    Address = tbxAddress.Text,
                    DateOpenObject = Convert.ToDateTime(dtpckDateOpen.Text),
                    TimeJobOpen = tmpTimeOpen.Value.Value,
                    TimeJobClose = tmpTimeClose.Value.Value,
                    BreakTimeFrom = tmpBreakFrom.Value.Value,
                    BreakTimeTo = tmpBreakTo.Value.Value
                };
                this.Close();
            }
            else
                MessageBox.Show("Не все поля заполненны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public List<int> SelectedServices { get; set; }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowServices win = new WindowServices();
            win.ShowDialog();
            SelectedServices = win.SelectedServices;
        }
    }
}
