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

namespace Example9BindingToList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> persons;

        public MainWindow()
        {
            InitializeComponent();

            persons = new List<Person>();
            persons.Add(new Person()
            {
                EmployeeNumber = 1,
                FirstName = "Alex",
                LastName = "Petrov",
                Department = "MicroSoft",
                Post = "Developer C#",
                Date = DateTime.Now.AddYears(-10),
                Salory = 3500
            });
            persons.Add(new Person()
            {
                EmployeeNumber = 2,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Department = "Google",
                Post = "Developer C++",
                Date = DateTime.Now.AddYears(-50),
                Salory = 2900
            });
            persons.Add(new Person()
            {
                EmployeeNumber = 3,
                FirstName = "Petr",
                LastName = "Petrov",
                Department = "Yandex",
                Post = "Developer PhP",
                Date = DateTime.Now.AddYears(-3),
                Salory = 1500
            });

            dgPersons.ItemsSource = persons;  // привязка данных к таблице

        }
    }

    public class Person
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public double Salory { get; set; }

    }
}
