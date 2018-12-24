﻿using ConfectioneryEnterprise.WcfService.Contract.PastryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;

namespace ConfectioneryEnterprise.Host
{
    class Program
    {
        static void Main()
        {
            //#Laboratorna #3
            using (var host = new ServiceHost(typeof(PastryService)))
            {
                host.Open();
                Console.WriteLine("Host started...");
                Console.ReadLine();
            }

            //Laboratorna #4
            //using (var host = new ServiceHost(typeof(PastryService)))
            //{
            //    var mexBehavior = new ServiceMetadataBehavior
            //    {
            //        HttpGetEnabled = true
            //    };
            //    host.Description.Behaviors.Add(mexBehavior);
            //    host.AddServiceEndpoint(typeof(IPastryService), new BasicHttpBinding(), "PastryService");
            //    host.AddServiceEndpoint(typeof(IIngredientService), new BasicHttpBinding(), "IngredientService");
            //    host.Open();

            //    Console.WriteLine("Host started...");
            //    Console.ReadLine();
            //}
        }
    }
}
