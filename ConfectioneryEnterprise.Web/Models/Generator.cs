using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ConfectioneryEnterprise.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            string jsonClients = JsonConvert.SerializeObject(clients);
            string jsonConfectioners = JsonConvert.SerializeObject(confectioners);

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Clients.json", jsonClients);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Data\\Confectioners.json", jsonConfectioners);
        }
    }
}