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

namespace ControlElements
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }

       static  int defaul = 0;
        int min, max;

        public static readonly DependencyProperty DataProperty;

        static NumericUpDown()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata((int)defaul);
            
            DataProperty = DependencyProperty.Register("Data", typeof(int), typeof(NumericUpDown), metadata,
                                                        new ValidateValueCallback(Validate));
        }

        public int Data
        {
            get
            {
                return (int)GetValue(DataProperty);
            }
            set
            {

                SetValue(DataProperty, (int)value);
            }
        }

        static bool Validate(object value)
        {
            if ((int)value < -1)
                return false;
            return true;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            this.Data += 1;
            tbData.Text = this.Data.ToString();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
          
            if (defaul<this.Data)
              this.Data -= 1;

            tbData.Text = this.Data.ToString();
        }

    }
}
