using ConfectioneryEnterprise.WcfService.Contract.PastryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Host
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(PastryService)))
            {
                host.Open();
                Console.WriteLine("Host started...");
                Console.ReadLine();
            }
        }
    }
}
