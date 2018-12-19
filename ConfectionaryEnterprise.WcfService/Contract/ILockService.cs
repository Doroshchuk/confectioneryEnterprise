using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [ServiceContract]
    public interface ILockService
    {
        [OperationContract]
        void Lock1();

        [OperationContract]
        void Lock2();
    }
}
