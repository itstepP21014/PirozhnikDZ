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

namespace ERP_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //images for OrderTree
        string[] Images =
        {
            "Images/star.png",
            "Images/snowflake.png",
            "Images/flower.png"
        };

        // список проектов для одного человека (пока общий)
        static List<Project> projects = new List<Project>()
            {
                new Project("Имя проекта 1", "заказчик", new DateTime(2015, 10, 20), new DateTime(2015, 12, 21), 50),
                new Project("Имя проекта 2", "заказчик", new DateTime(2015, 12, 19), new DateTime(2016, 06, 13), 35),
                new Project("Имя проекта 3", "заказчик", new DateTime(2015, 12, 1), new DateTime(2016, 04, 03), 95)
            };

        // список сотрудников
        List<Person> employees = new List<Person>()
        {
            new Person("Васильев Николай", "Images/incognito.jpg", projects, Person.DEPARTMENT.Programmers, new QualityMetrics(2, 5, 8, 3, 9)),
            new Person("Карбовская Ольга", "Images/incognito.jpg", projects, Person.DEPARTMENT.Managers, new QualityMetrics(6, 7, 4, 9, 1)),
            new Person("Дирюк Андрей", "Images/incognito.jpg", projects, Person.DEPARTMENT.Directors, new QualityMetrics(5, 6, 4, 9, 10)),
            new Person("Сорока Ирина", "Images/incognito.jpg", projects, Person.DEPARTMENT.Disigners, new QualityMetrics(2, 5, 7, 8, 9)),
            new Person("Дуглас Илья", "Images/incognito.jpg", projects, Person.DEPARTMENT.Programmers, new QualityMetrics(8, 9, 10, 10, 7))
        };

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OrderContent_Loaded;
            this.Loaded += Stuff_Loaded;
            //this.Loaded += LoadPieChartData;
        }

        //private void LoadPieChartData()
        //{
        //    ((PieSeries)mcChart.Series[0]).ItemsSource =
        //        new KeyValuePair<string, int>[]{
        // newKeyValuePair<string,int>("Project Manager", 12),
        // newKeyValuePair<string,int>("CEO", 25),
        // newKeyValuePair<string,int>("Software Engg.", 5),
        // newKeyValuePair<string,int>("Team Leader", 6),
        // newKeyValuePair<string,int>("Project Leader", 10),
        // newKeyValuePair<string,int>("Developer", 4) };
        //}

        void Stuff_Loaded(object sender, RoutedEventArgs e)
        {
            lbStuff.ItemsSource = employees;
        }

        void OrderContent_Loaded(object sender, RoutedEventArgs e)
        {
            List<ContentOrderTree> content = new List<ContentOrderTree>();

            ContentOrderTree node_1 = new ContentOrderTree()
            {
                Text = "Коллекция 1",
                Logo = Images[0],
                Children = new List<ContentOrderTree>() 
                  {
                    new ContentOrderTree(){Text="Подкласс 1", Logo = Images[0]},
                    new ContentOrderTree(){Text="Подкласс 2", Logo = Images[0]},
                    new ContentOrderTree(){Text="Подкласс 3", Logo = Images[0]},
                  }
            };

            ContentOrderTree node_2 = new ContentOrderTree()
            {
                Text = "Коллекция 2",
                Logo = Images[1],
                Children = new List<ContentOrderTree>() 
                  {
                    new ContentOrderTree(){Text="Подкласс 1", Logo = Images[1]},
                    new ContentOrderTree(){Text="Подкласс 2", Logo = Images[1]},
                    new ContentOrderTree(){Text="Подкласс 3", Logo = Images[1]},
                  }
            };

            ContentOrderTree node_3 = new ContentOrderTree()
            {
                Text = "Коллекция 3",
                Logo = Images[2],
                Children = new List<ContentOrderTree>() 
                  {
                    new ContentOrderTree(){Text="Подкласс 1", Logo = Images[2]},
                    new ContentOrderTree(){Text="Подкласс 2", Logo = Images[2]},
                    new ContentOrderTree(){Text="Подкласс 3", Logo = Images[2]},
                  }
            };

            content.Add(node_1);
            content.Add(node_2);
            content.Add(node_3);
            tvOrdersGroup.ItemsSource = content;
        }
    

    }
}
