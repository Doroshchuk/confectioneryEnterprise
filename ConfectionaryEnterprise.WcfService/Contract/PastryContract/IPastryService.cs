using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryService
{
    [ServiceContract]
    public interface IPastryService
    {
        [OperationContract]
        bool IsFresh(int id);

        [OperationContract]
        Pastry GetPastry(int id);

        [OperationContract]
        void SetPastry(Pastry pastry);
    }
}
