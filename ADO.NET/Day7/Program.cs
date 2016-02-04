using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExampleXMLSerializati
{
    class Program
    {
        static void Main(string[] args)
        {
            // коллекция для сериализации
            List<CBook> books = new List<CBook>()
		        { new CBook(1, "Война и мир", 1500, 2.6),
		          new CBook(2, "Отцы и дети", 800,  5.1),
		          new CBook(3, "Анна Каренина",860, 7.3)
		        };
            List<CBook> newBooks; // объект для десериализации
            // сериализация объекта
            using (FileStream file = new FileStream("file.xml", FileMode.Create))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CBook>));
                xmlFormat.Serialize(file, books); // сериализация
            }
            // десериализация объекта	
            using (FileStream file = new FileStream("file.xml", FileMode.Open))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<CBook>));
                newBooks = (List<CBook>)xmlFormat.Deserialize(file); // десериализация ! Обязательнао должно быть приведение типа
            }

            // вывод на экран newBook - десериализованного объекта
            foreach (CBook book in newBooks) // вывод на экран коллекции
                Console.WriteLine(book.ToString());

            Console.ReadKey(true);
        }
    }

        // XmlRoot - Переименовывает рутовую ноду.
        [XmlRoot("Book")]     
        public class CBook  
        {
            // переименовываем и делаем XML атрибутом.
            [XmlAttribute("Number")]   
            public int Num { get; set; }
            //XML элемент.
            [XmlElement("Title")]  
            public string Name { get; set; }
            // Исключаем свойство из процесса сериализации/десериализации.
            [XmlIgnore]
            public int Pages { get; set; }
            public double Price { get; set; }
       
        
            // Обязательный конструктор!
            public CBook()
            {    }
        
            public CBook(int n, string name, int pages, double price)
            { Num = n; Name = name; Price = price; Pages = Pages; }
            public override string ToString()
            { return string.Format("{0}. {1}, {2} стр. {3}", Num, Name, Pages, Price); }
        }
}
