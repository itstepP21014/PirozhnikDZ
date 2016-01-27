using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Используем технологию пространство ODBC
using System.Data.Odbc;

namespace ExampleODBC
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
                // Их два: имя драйвера (Driver) зарегистрированное в системе 
                // и путь к файлу базы данных (Dbq) 
                connection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=D:\KIN\DB\simple.accdb";
                
                
                // Открываем соединение 
                connection.Open();


                // Создаём объект для исполнения запроса
                // Указываем ему в качестве параметра запрос и объект открытого соединения
                OdbcCommand command = new OdbcCommand("SELECT * FROM PEOPLE", connection);
                
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
