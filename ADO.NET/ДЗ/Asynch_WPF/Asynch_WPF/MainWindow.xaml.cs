using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Asynch_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                connection.ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=Northwind;Integrated Security=True";

                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine(connection.ServerVersion); // версия сервера
                    Console.WriteLine(connection.WorkstationId); // Имя ПЭВМ
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(connection.State);
            }
            finally
            {
                connection.Close();
                Console.WriteLine(connection.State);
            }
        }
    }
}
