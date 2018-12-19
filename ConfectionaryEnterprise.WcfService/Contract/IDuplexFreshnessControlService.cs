using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [ServiceContract (CallbackContract = typeof(IDuplexFreshnessControlCallback))]
    public interface IDuplexFreshnessControlService
    {
        [OperationContract (IsOneWay = true)]
        void IsFreshPastry(int pastryId);
    }

    public interface IDuplexFreshnessControlCallback
    {
        [OperationContract (IsOneWay = true)]
        void SendResult(bool freshness);
    }
}
