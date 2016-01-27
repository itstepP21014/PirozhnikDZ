using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace ExampleODBCControlPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём объект для соединения с базой
            OdbcConnection connection = new OdbcConnection();
            try
            {
                // Прописываем строку соединения 
                // Указываем параметры необходимые для MS Access
                // Предварительно создаем в Панели управления 
                connection.ConnectionString = @"Dsn=SampleDB";
                
                // Открываем соединение 
                connection.Open();
                // Создаём объект для исполнения запроса
                // Указываем ему в качестве параметра запрос и объект открытого соединения
                OdbcCommand command = new OdbcCommand("SELECT * FROM People", connection);
                // Исполняем запрос и сохраняем ссылку на объект результата
                OdbcDataReader reader = command.ExecuteReader();
                // Проходимся по результатам работы запроса строка за строкой
                // Когда данные кончатся метод Read вернет false
                while (reader.Read() != false)
                {
                    // Так как в таблице три столбца в результате в строке будет тоже три столбца
                    // Для обращения к столбцу используется индексатор 
                    // Возможен доступ как по имени столбца так и по индексу
                    Console.WriteLine("{0,-10} {1,-10} {2,-10}", reader["id"], reader["firstname"], reader["lastname"]);
                    // Console.WriteLine("{0,-10} {1,-10} {2,-10}", reader[0], reader[1], reader[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Закрываем соединение
                connection.Close();
            }

            Console.ReadKey();


        }
    }
}
