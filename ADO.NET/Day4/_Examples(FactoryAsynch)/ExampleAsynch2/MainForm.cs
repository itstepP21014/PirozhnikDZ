using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.Common;



namespace ExampleAsynch1
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }



        private void btnGetData_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            // Получение данных в синхронном режиме!
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\Shop.mdf;Integrated Security=True";
                connection.Open();

                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = " WAITFOR DELAY '0:0:05' SELECT * FROM Customers";

                SqlDataReader reader = cmdSelect.ExecuteReader();
                listInfo.Items.Clear();
                listInfo.Items.Add("Данные получены в синхронном режиме");
                while (reader.Read())
                {
                    String info = String.Format("{0} {1} {2} {3} {4} {5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    listInfo.Items.Add(info);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
            finally 
            { connection.Close();
            }
        }

        async private void btnGetDataAsynch_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection connection = new SqlConnection())
            {

                connection.ConnectionString = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\Shop.mdf;Integrated Security=True";
          
                await connection.OpenAsync();   // асинхронное открытие соединения

                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = " WAITFOR DELAY '0:0:05' SELECT * FROM Customers";

                SqlDataReader reader = await cmdSelect.ExecuteReaderAsync();

                listInfo.Items.Clear();
                listInfo.Items.Add("Данные получены в асинхронном режиме");
                while (await reader.ReadAsync())
                {
                    String info = String.Format("{0} {1} {2} {3} {4} {5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    listInfo.Items.Add(info);
                }

            }
          
        }
    }
}
