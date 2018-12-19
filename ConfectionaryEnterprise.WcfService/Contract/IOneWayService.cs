using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [ServiceContract]
    public interface IOneWayService
    {
        [OperationContract]
        void RequestOperation();

        [OperationContract]
        void RequestOperationException();

        [OperationContract (IsOneWay = true)]
        void OneWayOperation();

        [OperationContract(IsOneWay = true)]
        void OneWayOperationException();
    }
}
