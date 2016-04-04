using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string FreeSpace(string str);

        [OperationContract]
        string TotalSpace(string str);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyDiskInfo> cf = new ChannelFactory<IMyDiskInfo>(new BasicHttpBinding(), "http://localhost/MyMath/Ep1");


            IMyDiskInfo cg = cf.CreateChannel();

            while (true)
            {
                Console.WriteLine("Введите букву диска");
                var dr = Console.ReadLine();

                if (dr == "Exit")
                    break;
                try
                {
                    Console.WriteLine("Free space: {0}\nTotal Size: {1}", cg.FreeSpace(dr), cg.TotalSpace(dr));
                }
                catch(System.ServiceModel.FaultException)
                {
                    Console.WriteLine("Неправильная буква диска");
                }

                Console.ReadLine();
            }
        }
    }
}
