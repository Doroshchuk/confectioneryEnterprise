using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [ServiceContract(CallbackContract = typeof(IDuplexControlCallback))]
    public interface IDuplexControlService
    {
        [OperationContract(IsOneWay = true)]
        void GetCounter();
    }

    public interface IDuplexControlCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendResult(int count);
    }
}
