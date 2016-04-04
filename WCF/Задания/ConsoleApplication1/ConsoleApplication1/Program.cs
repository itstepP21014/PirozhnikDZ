using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace ConsoleApplication1
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string FreeSpace(string str);

        [OperationContract]
        string TotalSpace(string str);
    }


    public class MyDiskInfo : IMyDiskInfo
    {
        public string FreeSpace(string str)
        {
            return new DriveInfo(GetLetter(str)).TotalFreeSpace.ToString();
        }

        public string TotalSpace(string str)
        {
            return new DriveInfo(GetLetter(str)).TotalSize.ToString();
        }

        private string GetLetter(string str)
        {
            return str.ElementAt(0).ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyDiskInfo));

            sh.Open();

            Console.WriteLine("Служба запущена");
            Console.ReadLine();

            sh.Close();

            Console.WriteLine("Служба остановлена");
            
        }
    }
}
