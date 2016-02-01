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

        List<Orders> orders_info = new List<Orders>();

        public MainWindow()
        {
            InitializeComponent();
        }

        async private void btn_Orders_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                dg_Orders.Items.Clear();

                connection.ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=Northwind;Integrated Security=True";

                await connection.OpenAsync();

                pb_Orders.IsIndeterminate = true;

                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = "WAITFOR DELAY '0:0:05' SELECT Customers.CompanyName, Customers.ContactName, Customers.Address, Customers.City, Customers.Country, Customers.Phone, "
                +"Orders.OrderDate, Orders.ShippedDate, Orders.Freight, Orders.ShipCity, Orders.ShipCountry, Orders.ShipRegion, "
                +"[Order Details].UnitPrice, [Order Details].Quantity, [Order Details].Discount "
                +"FROM Orders INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID INNER JOIN [Order Details] ON Orders.OrderID=[Order Details].OrderID";

                SqlDataReader reader = await cmdSelect.ExecuteReaderAsync();

                

                while (await reader.ReadAsync())
                {
                    Orders orders = new Orders();
                    orders.CompanyName = reader[0].ToString();
                    orders.ContactName = reader[1].ToString();
                    orders.Adress = reader[2].ToString();
                    orders.City = reader[3].ToString();
                    orders.Country = reader[4].ToString();
                    orders.Phon = reader[5].ToString();
                    orders.Date_of_order = (DateTime)reader[6];
                    orders.Date_of_supply = reader[7] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader[7].ToString());

                    if (reader[8] == DBNull.Value)
                    {
                        orders.Transit_cost = 0;
                    }
                    else
                    {
                        int temp = 0;
                        Int32.TryParse(reader[8].ToString(), out temp);
                        orders.Transit_cost = temp;
                    }

                    orders.City_of_supply = reader[9].ToString();
                    orders.Country_of_supply = reader[10].ToString();
                    orders.Region_of_supply = reader[11].ToString();
                   
                    if (reader[12] == DBNull.Value)
                    {
                        orders.Price = 0;
                    }
                    else
                    {
                        int temp=0;
                        Int32.TryParse(reader[12].ToString(), out temp);
                        orders.Price = temp;
                    }

                    if (reader[13] == DBNull.Value)
                    {
                        orders.Count = 0;
                    }
                    else
                    {
                        int temp = 0;
                        Int32.TryParse(reader[13].ToString(), out temp);
                        orders.Count = temp;
                    }

                    if (reader[14] == DBNull.Value)
                    {
                        orders.Cost = 0;
                    }
                    else
                    {
                        int temp = 0;
                        Int32.TryParse(reader[14].ToString(), out temp);
                        orders.Cost = temp;
                    }
                    
                    orders_info.Add(orders);
                }

                foreach (var obj in orders_info)
                {
                    dg_Orders.Items.Add(obj);
                }

                pb_Orders.IsIndeterminate = false;
                

                //MessageBox.Show("Типо все загрузилось");

            }
        }

    }
}
