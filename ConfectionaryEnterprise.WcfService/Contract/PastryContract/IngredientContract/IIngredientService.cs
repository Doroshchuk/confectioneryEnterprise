using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract.PastryContract.IngredientContract
{
    [ServiceContract]
    public interface IIngredientService
    {
        [OperationContract]
        Ingredient GetIngredient(int id);

        [OperationContract]
        void SetIngredient(Ingredient ingredient);
    }
}
