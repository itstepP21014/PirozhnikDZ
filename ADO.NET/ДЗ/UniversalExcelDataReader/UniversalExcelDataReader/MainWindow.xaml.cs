using LinqToExcel;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace UniversalExcelDataReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //XDocument doc = new XDocument();
            //XElement catalog = new XElement("catalog");
            //doc.Add(catalog); 
            //List<string> sheets_collection = new List<string>();

            //string pathFile = "PriceProductBase1.xls";
            //var excelFile = new ExcelQueryFactory(pathFile);
            //foreach (var item in excelFile.GetWorksheetNames())
            //{
            //    sheets_collection.Add(item);
            //}

            //XElement prices = new XElement(sheets_collection[0]);
            //foreach (var itemRow in excelFile.GetColumnNames(sheets_collection[0]))
            //{
            //    prices.Add(new XElement(itemRow));
            //}

            //XElement orders = new XElement(sheets_collection[1]);
            //foreach (var itemRow in excelFile.GetColumnNames(sheets_collection[1]))
            //{
            //    orders.Add(new XElement(itemRow.ToString()));
            //}

            //doc.Root.Add(prices);
            //doc.Root.Add(orders);

            //doc.Save("PriceProductBase.xml");



            XDocument doc = XDocument.Load("PriceProductBase.xml");
            foreach (XElement el in doc.Root.Elements())
            {

            }

            string pathFile = "PriceProductBase1.xls";


            string sheetName = "Orders";

            var excelFile = new ExcelQueryFactory(pathFile);
            var infoOrders = from a in excelFile.Worksheet(sheetName)
                             select a;

            foreach (var item in infoOrders)
            {
                string pattern = "Дата заказа: {0};     Итого: {1}";

                // Вывод информации из столбцов OrderDate и Total
                Console.WriteLine(string.Format(pattern, item["OrderDate"], item["Total"]));
            }

            Console.ReadKey();


        }
    }
}
