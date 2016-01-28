using System;
using System.IO;
using System.Text;

namespace FileStreamExample
{
    class Program
    {
        // Демонстрационный пример 
        // работы с классом FileStream
        static void Main(string[] args)
        {
            // Получаем путь к файлу

            //Console.WriteLine("Введите путь к файлу:");
            //string filePath = Console.ReadLine();

            // Создаем объект FileStream - 
            // коментарии к конструктору см. ниже в уроке
            // Использование блока using позволяет правильно
            // разрушить FileStream
            using (FileStream fs = new FileStream(@"c:\users\st\1.txt",
                FileMode.Open, FileAccess.Read))
            {
                // Теперь прочитаем данные из файла
                // для этого нужно сначала установить курсор 
                // на начало файла
                fs.Seek(15, SeekOrigin.Begin);
                // Теперь прочитаем данные в другой массив байт
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                // Преобразуем байты в строку
                string readText = Encoding.UTF8.GetString(readBytes);
                // Выведем ее на консоль
                Console.WriteLine("Данные, прочитанные из файла:\n{0}", readText);
            }
            Console.Read();
        }
    }
}
