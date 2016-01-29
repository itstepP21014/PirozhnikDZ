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

namespace ExampleAsynch1
{
    public partial class MainForm : Form
    {

        SqlConnection connection = null;

        public MainForm()
        {
            InitializeComponent();
        }



        private void btnGetData_Click(object sender, EventArgs e)
        {
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
            finally { connection.Close(); }
        }

        private void btnGetDataAsynch_Click(object sender, EventArgs e)
        {
            // Получение данных в асинхронном режиме!
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\Shop.mdf;Integrated Security=True";           
                connection.Open();

                SqlCommand cmdSelect = connection.CreateCommand();
                cmdSelect.CommandText = " WAITFOR DELAY '0:0:05' SELECT * FROM Customers";

                // создание объекта - делегата для функции обратного вызова,
                // которая должна принимать в качестве параметра IAsyncResult
                AsyncCallback callBack = new AsyncCallback(MetodCallBack);

                // Вызов метода BeginExecuteReader с передачей объек-делегата и 
                // объекта, вызвавшего данный метод
                cmdSelect.BeginExecuteReader(callBack, cmdSelect); // или cmdSelect.BeginExecuteReader(MetodCallBack, cmdSelect);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
          
        }

        // метод, который выступает в качестве функции обратного вызова
        // данный метод вызовится, когда закончит выполнятся метод BeginExecuteReader
        void MetodCallBack(IAsyncResult  resAsynch)
        {
            try
            {
               SqlCommand command = (SqlCommand)resAsynch.AsyncState;

                            
                // Вызов метода для заврешения выполнения SQL-запроса в асинхронном режиме
               SqlDataReader reader = command.EndExecuteReader(resAsynch);

               // т.к. метод MetodCallBack() работает в другом потоке
               // то для обращения к элементам главного окна (работает в главном потоке)
               //  необходимо вызвать метод Invoke() для обновления интерфейса
               // метод Invoke() вызывает метод обновления интерфейса через 
               // пользовательский делегат DelUpdateInterface () с передачей объекта reader
                
               this.Invoke(new DelUpdateInterface(UpdateInterface), reader);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        // объявление делегата для обращения из вторичного потока
        // к элементам главног окна
        delegate void DelUpdateInterface(SqlDataReader reader);

        // метод заполнения ListBox полученными данными 
        void UpdateInterface(SqlDataReader reader)
        {
            listInfo.Items.Clear();
            listInfo.Items.Add("Данные получены в асинхронном режиме");
            while (reader.Read())
            {
                String info = String.Format("{0} {1} {2} {3} {4} {5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                listInfo.Items.Add(info);
            }
        }

      

    }

   

}
