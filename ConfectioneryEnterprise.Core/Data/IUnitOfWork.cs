using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryEnterprise.Domain;

namespace ConfectioneryEnterprise.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<Confectioner> ConfectionerRepository { get; }

        IRepository<Pastry> PastryRepository { get; }

        IRepository<Ingredient> IngredientRepository { get; }

        IRepository<Recipe> RecipeRepository { get; }

        IRepository<PlanComponent> PlanComponentRepository { get; }

        IRepository<Plan> PlanRepository { get; }

        IRepository<Production> ProductionRepository { get; }

        IRepository<Client> ClientRepository { get; }
    }
}
