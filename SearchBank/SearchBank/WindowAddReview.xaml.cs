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
    /// Логика взаимодействия для WindowAddReview.xaml
    /// </summary>
    public partial class WindowAddReview : Window
    {
        public WindowAddReview(BusinessLogic.Logic logic)
        {
            InitializeComponent();
            cmbxBranchs.ItemsSource = logic.ReturnBranchs();
            cmbxBranchs.SelectedIndex = 0;
        }

        public BusinessLogic.Review Review { get; set; }
        public int IndexBranch { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(tbxCommentator.Text) && !String.IsNullOrEmpty(tbxReview.Text))
            {
                Review = new BusinessLogic.Review();
                Review.Commentator = tbxCommentator.Text;
                Review.Comment = tbxReview.Text;
                IndexBranch = cmbxBranchs.SelectedIndex;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполненны!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
