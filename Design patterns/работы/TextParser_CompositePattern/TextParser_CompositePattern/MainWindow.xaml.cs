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

namespace TextParser_CompositePattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string str = "Ее разбудил непонятный грохот. Элен Грэйнджер села в кровати в состоянии легкой паники. Едва взглянув на ярко-красный индикатор часов, она с облегчением рухнула назад. Проспала всего час — до утреннего такси еще полно времени.\n"
                + "Град ударов снова обрушился на дверь. Элен поднялась, накинула шелковый халат, сунула ноги в тапочки. Раз это не водитель, озабоченный перспективой не получить плату за доставку пассажирки в аэропорт Шарля де Голля, то кто? И какого дьявола ему нужно в это время суток? Хотя, может, у Агаты из соседней квартиры снова припадок…\n"
                  + "Элен заторопилась. Вдруг она упала? Эжен ее поднять не сможет.\n"
                    + "Забыв второпях о мерах предосторожности, Элен широко распахнула дверь и застыла в изумлении.";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_InputText.Text = str;
            Text t = new Text();
            t.parse(str);
            t.show();
            //tb_OutputText.Text = ;

        }
    }
}
