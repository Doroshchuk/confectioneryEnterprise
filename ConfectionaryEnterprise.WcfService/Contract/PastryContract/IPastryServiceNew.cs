using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryContract
{
    [ServiceContract (Name = "IPastryService")]
    public interface IPastryServiceNew
    {
        [OperationContract]
        bool IsFresh(int id);

        [OperationContract (Name = "GetPastry")]
        Pastry ReceivePastry(int id);

        [OperationContract (Name = "SetPastry")]
        void AddPastry(Pastry pastry);
    }
}
