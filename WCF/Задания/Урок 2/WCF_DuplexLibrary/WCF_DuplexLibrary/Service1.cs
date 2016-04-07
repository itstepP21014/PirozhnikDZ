using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_DuplexLibrary
{
    public class DuplexSvc : IDuplexSvc
    {
        public void ReturnTime(int period, int number)
        {
            MyDataValues src = new MyDataValues();
            src.callback = OperationContext.Current.GetCallbackChannel<IClientCallBack>();
            Thread t = new Thread(new ParameterizedThreadStart(src.SendTimeToClient));
            t.IsBackground = true;
            List<int> parameters = new List<int>();
            parameters.Add(period);
            parameters.Add(number);
            t.Start(parameters);
        }
    }

    public class MyDataValues
    {
        // член типа контракта обратного вызова
        public IClientCallBack callback = null;
        public void SendTimeToClient(object data)
        {
            // по условию задачи надо подождать до начала следующей минуты
            int s = 60 - DateTime.Now.Second;
            Thread.Sleep(s * 1000);
            DateTime start = DateTime.Now;
            // достать из object data наши два параметра типа int
            List<int> parameters = (List<int>)data;
            int period = parameters[0];
            int number = parameters[1];
            // каждое сообщение клиенту готовиться в цикле
            for (int i = 0; i < number; ++i)
            {
                try
                {
                    // задержка между сообщениями period секунд
                    Thread.Sleep(period * 1000);
                    TimeSpan result = DateTime.Now - start;
                    TimeSpan r = result.Add(new TimeSpan(0, 0, s));
                    callback.ReciveTime(DateTime.Now.ToLongTimeString().ToString() +
                         " время работы со службой - " +
                         r.Minutes.ToString() + ":" +
                         r.Seconds.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
