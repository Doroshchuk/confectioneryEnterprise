using ConfectionaryEnterprise.WcfService.Contract.IngredientContract;
using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryContract
{
    [ServiceContract]
    public interface IPastryService : IIngredientService
    {
        [OperationContract]
        bool IsFresh(int id);

        [OperationContract]
        Pastry GetPastry(int id);

        [OperationContract]
        void SetPastry(Pastry pastry);
    }
}
