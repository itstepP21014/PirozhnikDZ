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

namespace Example3BindingToElement_InCode_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding();             // создание объекта привязки данных 
            binding.Source = sliderFontSize;             // указываем источник привязки (объект с которым связываемся) 
            binding.Path = new PropertyPath("Value");    // указываем свойство, к которому привязываемся
            binding.Mode = BindingMode.TwoWay;           // указываем тип привязки
            tbText.SetBinding(TextBlock.FontSizeProperty, binding); // устанавливаем целевой объект и целевое свойство


        }

        public void ClickButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            tbText.FontSize = Convert.ToDouble(button.Tag);
        }
    }
}
