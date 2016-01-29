using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFactory1
{
    class Program
    {   // Демонстрация работы с файбрикрй провайдеров
        static void Main(string[] args)
        {
            int selIndex = 0;
            // Получение списка доступных  поставщиков данных!
            DataTable dataTable= DbProviderFactories.GetFactoryClasses();
            Console.WriteLine("Список доступных поставщиков данных!");
            // Вывод на экран полученного списка
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {   // Отображение свойств Name и InvariantName каждого поставщика
                String info = String.Format("{0}.{1} {2}",i+1, dataTable.Rows[i]["Name"], dataTable.Rows[i]["InvariantName"]);
                Console.WriteLine(info);
			}
           Console.Write("Введите номер поставщика данных: ");
           selIndex = Convert.ToInt32(Console.ReadLine())-1;
           
           // Создание фабрики провайдера по выбранному провайдеру! 
           // DbProviderFactory dbFactory = DbProviderFactories.GetFactory(dataTable.Rows[selIndex]);
           DbProviderFactory dbFactory = DbProviderFactories.GetFactory(dataTable.Rows[selIndex]["InvariantName"].ToString());
          
           // Создание подключения на основе выбранной фабрики 
           DbConnection dbConnection=null;
           try
           {
             string ConnString = @"Data Source=(localdb)\v11.0;AttachDbFilename=D:\KIN\DB\People.mdf;Integrated Security=True";
             dbConnection = dbFactory.CreateConnection();
             dbConnection.ConnectionString=ConnString;
             dbConnection.Open();
             // Создание подключения на основе подключения  
             DbCommand dbCommand=dbConnection.CreateCommand();
             dbCommand.CommandText=@"Insert Into Persons(NAME, SUBJECT, SALARY) Values ('Anna', 'VB.NET', 180.2 )";
             
             // Выполнение оператора SQL
             int rows = dbCommand.ExecuteNonQuery();
             Console.WriteLine("Данные успешно внесены: {0}", rows);
           }
           catch(Exception ex)
           {
              Console.Write(ex.Message);
           }
           finally
           {
            dbConnection.Close(); // закрытие подключения!
           }
            
           Console.ReadLine();
        }
    }
}
