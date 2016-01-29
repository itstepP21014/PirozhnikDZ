using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Example2Factory
{
    class Program
    {   // Демонстрация работы с файбрикрй провайдеров
        static void Main(string[] args)
        {

            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings["MainConnectionString"];
            
            // Создание фабрики провайдера по заданному провайдеру
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(config.ProviderName);

            // Создание подключения на основе выбранной фабрики 
            DbConnection dbConnection = null;
            try
            {
                dbConnection = dbFactory.CreateConnection();
                dbConnection.ConnectionString = config.ConnectionString;
                dbConnection.Open();
                // Создание команды на основе подключения  
                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = @"Insert Into Persons(NAME, SUBJECT, SALARY) Values ('Anna', 'VB.NET', 180.2 )";

                // Выполнение оператора SQL
                int rows = dbCommand.ExecuteNonQuery();
                Console.WriteLine("Данные успешно внесены: {0}", rows);
            }
            catch (Exception ex)
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
