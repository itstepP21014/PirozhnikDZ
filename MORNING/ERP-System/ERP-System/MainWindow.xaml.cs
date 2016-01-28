using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // список проектов для одного человека (пока общий для всех)
        static List<Project> projects = new List<Project>()
            {
                new Project("Имя проекта 1", "заказчик", new DateTime(2015, 10, 20), new DateTime(2015, 12, 21), 50, "Images/star.png"),
                new Project("Имя проекта 2", "заказчик", new DateTime(2015, 12, 19), new DateTime(2016, 06, 13), 35, "Images/snowflake.png"),
                new Project("Имя проекта 3", "заказчик", new DateTime(2015, 12, 1), new DateTime(2016, 04, 03), 95, "Images/flower.png")
            };
        static List<Project> projects_2 = new List<Project>()
            {
                new Project("Имя проекта 1", "заказчик", new DateTime(2015, 10, 18), new DateTime(2015, 09, 21), 35, "Images/star.png"),
                new Project("Имя проекта 2", "заказчик", new DateTime(2015, 02, 19), new DateTime(2016, 12, 13), 15, "Images/snowflake.png"),
                new Project("Имя проекта 3", "заказчик", new DateTime(2014, 12, 1), new DateTime(2016, 01, 03), 40, "Images/flower.png"),
                new Project("Имя проекта 4", "заказчик", new DateTime(2013, 04, 01), new DateTime(2016, 06, 09), 50, "Images/star.png"),
                new Project("Имя проекта 5", "заказчик", new DateTime(2015, 12, 1), new DateTime(2017, 11, 03), 90, "Images/snowflake.png"),
                new Project("Имя проекта 6", "заказчик", new DateTime(2013, 04, 01), new DateTime(2016, 06, 09), 50, "Images/flower.png"),
                new Project("Имя проекта 7", "заказчик", new DateTime(2015, 12, 1), new DateTime(2017, 11, 03), 90, "Images/star.png")
            };

        // показатели производительности сотрудника
        static List<string> metrics = new List<string>()
        {
            "Работа с клиентами",
            "Работа в команде",
            "Выполнение сроков",
            "Навыки управления",
            "Инновационность"
        };
        
        // список сотрудников
        List<Person> employees = new List<Person>()
        {
            new Person("Васильев Николай", "Images/chel.jpg", projects, Person.DEPARTMENT.Programmers, "Программист С#", new List<int>{2, 5, 8, 3, 9}, metrics, "...", 1500),
            new Person("Карбовская Ольга", "Images/conopushka.jpg", projects_2, Person.DEPARTMENT.Managers, "Менеджер", new List<int>{6, 7, 4, 9, 1}, metrics, "...", 1000),
            new Person("Дирюк Андрей", "Images/pacan.jpg", projects, Person.DEPARTMENT.Directors, "Начальник технического отдела", new List<int>{5, 6, 4, 9, 10}, metrics, "...", 800),
            new Person("Сорокина Ирина", "Images/disiner.jpg", projects_2, Person.DEPARTMENT.Disigners, "3D-дизайнер", new List<int>{2, 5, 7, 8, 9}, metrics, "...", 2200),
            new Person("Дуглас Илья", "Images/chel_2.jpg", projects, Person.DEPARTMENT.Programmers, "Программист PHP", new List<int>{8, 9, 10, 10, 7}, metrics, "...", 500)
        };

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Stuff_Loaded;
        }

        void Stuff_Loaded(object sender, RoutedEventArgs e)
        {
            lbStuff.ItemsSource = employees;
        }


    }
}
