using ConfectionaryEnterprise.WcfService.Contract.IngredientContract;
using ConfectioneryEnterprise.WcfService.Contract.PastryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [ServiceContract]
    public interface IGeneralService : IPastryService, IIngredientService
    {
    }
}
