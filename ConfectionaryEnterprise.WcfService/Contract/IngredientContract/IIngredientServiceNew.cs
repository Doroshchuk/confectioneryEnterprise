using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract.IngredientContract
{
    [ServiceContract (Name = "IIngredientService")]
    public interface IIngredientServiceNew
    {
        [OperationContract (Name = "GetIngredient")]
        Ingredient ReceiveIngredient(int id);

        [OperationContract (Name = "SetIngredient")]
        void AddIngredient(Ingredient ingredient);
    }
}
