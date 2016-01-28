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

namespace Exampe7BindingToObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Person newperson;
        public MainWindow()
        {
            InitializeComponent();
            
            newperson = new Person() 
            { 
                EmployeeNumber=1, 
                FirstName="Ivan", 
                LastName="Ivanov", 
                Department="MicroSoft",   
                Post="Developer С#", 
                Date=DateTime.Now.AddYears(-10), 
                Salory=3500
            } ;

            gridInfo.DataContext = newperson;
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(newperson.FirstName);
        }

    }

    public class Person
     {
         public int EmployeeNumber {get; set;}
         public string FirstName {get; set;}
         public string LastName { get; set; }
         public string Department { get; set; }
         public string Post { get; set; }
         public DateTime Date { get; set; }
         public double Salory { get; set; }

      }
    
   
}
