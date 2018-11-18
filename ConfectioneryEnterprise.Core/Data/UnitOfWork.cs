using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryEnterprise.Domain;

namespace ConfectioneryEnterprise.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Confectioner> _confectionerRepository;
        private IRepository<Pastry> _pastryRepository;
        private IRepository<Ingredient> _ingredientRepository;
        private IRepository<Client> _clientRepository;
        private IRepository<Recipe> _recipeRepository;
        private IRepository<PlanComponent> _planComponentRepository;
        private IRepository<Plan> _planRepository;
        private IRepository<Production> _productionRepository;

        public IRepository<Confectioner> ConfectionerRepository => 
            _confectionerRepository ?? (_confectionerRepository = new Repository<Confectioner>("Confectioners"));

        public IRepository<Pastry> PastryRepository =>
            _pastryRepository ?? (_pastryRepository = new Repository<Pastry>("Pastiers"));

        public IRepository<Recipe> RecipeRepository =>
            _recipeRepository ?? (_recipeRepository = new Repository<Recipe>("Recipes"));

        public IRepository<PlanComponent> PlanComponentRepository =>
            _planComponentRepository ?? (_planComponentRepository = new Repository<PlanComponent>("PlanComponents"));

        public IRepository<Plan> PlanRepository =>
            _planRepository ?? (_planRepository = new Repository<Plan>("Plans"));

        public IRepository<Production> ProductionRepository =>
            _productionRepository ?? (_productionRepository = new Repository<Production>("Productions"));

        public IRepository<Ingredient> IngredientRepository =>
            _ingredientRepository ?? (_ingredientRepository = new Repository<Ingredient>("Ingredients"));

        public IRepository<Client> ClientRepository => 
            _clientRepository ?? (_clientRepository = new Repository<Client>("Clients"));
    }
}
