using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Example8BindingProperty
{
   
    public partial class MainWindow : Window
    {
       public Person PersonInfo { get; set; }
  
        public MainWindow()
        {
            // Создание объекта привязки
            PersonInfo = new Person();

            InitializeComponent();
 
            PersonInfo.Name = "Ivan";
            PersonInfo.Age = 30;
           
            // привязка к свойству класса в коде
            // this.DataContext = PersonInfo;
                     
        }

        // Изменение значения в коде 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo.Name = "Иван";
            PersonInfo.Age = 25;
        }
    }



    // уведомление элемента управления об изменении свойства в коде
    // необходимо для окна реализовать интерфейс INotifyPropertyChanged
    public class Person: INotifyPropertyChanged 
    {
        // интерфейс INotifyPropertyChanged предоставляет событие
        // PropertyChanged, которое обеспечивает передачу информации элементу 
        // управления при изменении значения свойства в коде
        public event PropertyChangedEventHandler PropertyChanged;

        // метод, вызывающий событие об изменении свойства
        // в данный метод передаем имя изененнного свойства 
        // для уведомления привязки данных 
        void OnPropertyChanged(string NameProperty)
        {
            PropertyChangedEventHandler PropertyChanged = this.PropertyChanged; 
            if (PropertyChanged != null)
              PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
        }

        string name;
        public string Name
        {   get { return name; }
            set 
            {   name = value;
                OnPropertyChanged("Name"); 
            } 
        }

        int age;
        public int Age
        {   get { return age; }
            set 
            {   age = value;
                OnPropertyChanged("Age"); 
            } 
        }
     }
    

}
