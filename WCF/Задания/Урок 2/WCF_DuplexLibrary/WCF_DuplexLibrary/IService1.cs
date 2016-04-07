using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_DuplexLibrary
{
    [ServiceContract(CallbackContract = typeof(IClientCallBack))]
    public interface IDuplexSvc
    {
        [OperationContract(IsOneWay = true)]
        void ReturnTime(int period, int number);


    }

    public interface IClientCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ReciveTime(string str);
    }
}
