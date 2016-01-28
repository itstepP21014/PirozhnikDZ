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

namespace Заправка
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Fuel> fuel = new List<Fuel>() { new Fuel("A-92", 11100), new Fuel("A-95", 11900), new Fuel("A-98", 13000), new Fuel("ДТ", 12300), new Fuel("ГАЗ", 6200) };
        public List<Goods> goods = new List<Goods>() { new Goods("Вода 'Бонаква' н/г 0,5 л.", 9000), new Goods("Вода 'Бонаква' н/г 1 л.", 16000),
                                                        new Goods("Шок. батончик 'Сникерс' 140 гр.", 14000), new Goods("Шок. батончик 'Баунти' 120 гр.", 15000) };
        public List<Wash> wash = new List<Wash>() { new Wash("Пена + сушка", 75000), new Wash("Пена + сушка + воск", 90000), new Wash("Пена + мойка днища + сушка + воск", 95000) };
        int cleaning_cost = 90000;
        int total_sum = 0;
        
        public MainWindow()
        {
            InitializeComponent();

            foreach (var f in fuel)
            {
               fuel_combobox.Items.Add(f.name);
            }

            foreach (var g in goods)
            {
                stuff_combobox.Items.Add(g.name);
            }

            foreach (var w in wash)
            {
                wash_combobox.Items.Add(w.name);
            }

            total_lable.Content = total_sum.ToString();
           
           
        }

        private void cleaning_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            bill_listbox.Items.Add("Чистка пылесосом     " + cleaning_cost.ToString());
            total_sum += cleaning_cost;
            total_lable.Content = total_sum.ToString();
        }

        private void cleaning_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= bill_listbox.Items.Count; ++i )
            {
                if (bill_listbox.Items[i].ToString() == "Чистка пылесосом     " + cleaning_cost.ToString())
                {
                    bill_listbox.Items.Remove(bill_listbox.Items[i]);
                    total_sum -= cleaning_cost;
                    total_lable.Content = total_sum.ToString();
                }
            }
        }

        private void settings_button_1_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("Skin1.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void settings_button_2_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("Skin2.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;
        }

        private void settings_button_3_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = new Uri("MySkin.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries[0] = newDictionary;

        }

        private void staff_add_button_Click(object sender, RoutedEventArgs e)
        {
            int j = goods[stuff_combobox.SelectedIndex].cost * int.Parse(stuff_count_textbox.Text);
            bill_listbox.Items.Add(stuff_combobox.SelectedItem + "     " + j.ToString());
            total_sum += j;
            total_lable.Content = total_sum.ToString();
        }


        //private void element_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ((Button)sender).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
        //}

        //private void element_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    ((Button)sender).Background = null;
        //}
        

    }
}
