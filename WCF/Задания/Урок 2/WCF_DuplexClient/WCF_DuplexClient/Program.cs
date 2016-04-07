using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_DuplexClient.ServiceReference1;


namespace WCF_DuplexClient
{
    public class CallbackHandler : WCF_DuplexClient.ServiceReference1.IDuplexSvcCallback
    {
        static InstanceContext site = new InstanceContext(new CallbackHandler());
        public static DuplexSvcClient proxy = new DuplexSvcClient(site);
  
        public void ReciveTime(string str)
        {
            Console.WriteLine("Получено сообщение:\n" + str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CallbackHandler.proxy.ReturnTime(5, 10);
            Console.ReadKey();
        }
    }
}
