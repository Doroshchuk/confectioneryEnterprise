using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ConfectioneryEnterprise.Domain;
using Newtonsoft.Json;

namespace ConfectioneryEnterprise.Web.Models
{
    public static class Generator
    {
        public static void Generate()
        {
            List<Client> clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    FirstName = "Valera",
                    LastName = "Petrovich",
                    Login = "test@example.com",
                    Password = "12345",
                    Phone = "123456789"
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Test",
                    LastName = "Testovich",
                    Login = "admin@example.com",
                    Password = "12345",
                    Phone = "123456789"
                }
            };

            List<Confectioner> confectioners = new List<Confectioner>()
            {
                new Confectioner()
                {
                    Id = 1,
                    FirstName = "Valera",
                    LastName = "Petrovich",
                    WorkNumber = 100,
                    Password = "12345",
                    Phone = "123456789"
                },
                new Confectioner()
                {
                    Id = 2,
                    FirstName = "Test",
                    LastName = "Testovich",
                    WorkNumber = 200,
                    Password = "12345",
                    Phone = "123456789"
                }
            };

            List<Ingredient> ingredients = new List<Ingredient>()
            {
                new Ingredient() {
                    Id = 1,
                    Name = "egg",
                    Quantity = 4,
                    Units = "units"
                },
                new Ingredient() {
                    Id = 2,
                    Name = "sugar",
                    Quantity = 130,
                    Units = "grams"
                },
                new Ingredient() {
                    Id = 3,
                    Name = "apple",
                    Quantity = 600,
                    Units = "grams"
                },
                new Ingredient() {
                    Id = 4,
                    Name = "cinnamon",
                    Quantity = 7,
                    Units = "grams"
                },
                new Ingredient() {
                    Id = 5,
                    Name = "flour",
                    Quantity = 130,
                    Units = "grams"
                }
            };

            List<Pastry> pastiers = new List<Pastry>()
            {
                new Pastry()
                {
                    Id = 1,
                    Type = "cake",
                    Name = "Lasunka",
                    Consistency = new List <Ingredient>(){
                        ingredients.First(x => x.Id == 1),
                        ingredients.First(x => x.Id == 2),
                        ingredients.First(x => x.Id == 3),
                        ingredients.First(x => x.Id == 4),
                        ingredients.First(x => x.Id == 5)
                    },
                    ShelfLife = 2,
                    DateOfManufacture = new DateTime(2018, 11, 18, 15, 20, 50)
                }
            };

            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Name = "cake 'Lasunka'",
                    Ingredients = new List<Ingredient>()
                    {
                        ingredients.First(x => x.Id == 1),
                        ingredients.First(x => x.Id == 2),
                        ingredients.First(x => x.Id == 3),
                        ingredients.First(x => x.Id == 4),
                        ingredients.First(x => x.Id == 5)
                    }
                }
            };

            List<PlanComponent> planComponents = new List<PlanComponent>()
            {
                new PlanComponent()
                {
                    Id = 1,
                    Recipe = recipes.First(x => x.Id == 1),
                    Quantity = 5
                }
            };

            List<Plan> plans = new List<Plan>()
            {
                new Plan()
                {
                    Id = 1,
                    Components = new List<PlanComponent>
                    {
                        planComponents.First(x => x.Id == 1)
                    }
                }
            };

            List<Production> productions = new List<Production>()
            {
                new Production()
                {
                    Id = 1,
                    Ingredients = ingredients,
                    Confectioners = confectioners,
                    Plan = plans.First(x => x.Id == 1)
                }
            };

            string jsonClients = JsonConvert.SerializeObject(clients);
            string jsonConfectioners = JsonConvert.SerializeObject(confectioners);
            string jsonPastiers = JsonConvert.SerializeObject(pastiers);
            string jsonIngredients = JsonConvert.SerializeObject(ingredients);
            string jsonRecipes = JsonConvert.SerializeObject(recipes);
            string jsonPlanComponents = JsonConvert.SerializeObject(planComponents);
            string jsonPlans = JsonConvert.SerializeObject(plans);
            string jsonProductions = JsonConvert.SerializeObject(productions);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Clients.json", jsonClients);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Confectioners.json", jsonConfectioners);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Pastiers.json", jsonPastiers);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Ingredients.json", jsonIngredients);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Recipes.json", jsonRecipes);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\PlanComponents.json", jsonPlanComponents);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Plans.json", jsonPlans);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Productions.json", jsonProductions);
        }
    }
}