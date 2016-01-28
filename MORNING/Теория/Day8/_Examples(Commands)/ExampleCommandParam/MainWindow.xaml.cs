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

namespace ExampleCommandParam
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void CommandNewbinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           
        }

        private void CommandOpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда 'Open' была вызвана из " + e.Parameter);
        }
    }
}
