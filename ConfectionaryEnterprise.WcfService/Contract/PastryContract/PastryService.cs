using ConfectionaryEnterprise.WcfService.Contract;
using ConfectionaryEnterprise.WcfService.Contract.IngredientContract;
using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryContract
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class PastryService : IngredientService, IPastryService, IIngredientService, IOneWayService,  IDuplexControlService, ILockService, IInfoService // IDuplexFreshnessControlService
    {
        private string PastriesFileName => "filePastries";
        private int _counter = 0;

        public void SetPastry(Pastry pastry)
        {
            var file = ConfigurationManager.AppSettings[PastriesFileName];
            var document = XDocument.Load(file);

            XElement[] consistencyXML = new XElement[pastry.Consistency.Count];
            for (int i = 0; i < pastry.Consistency.Count; i++)
            {
                consistencyXML[i] = new XElement("Ingredient",
                                    new XAttribute("Id", pastry.Consistency[i].Id),
                                   new XElement("Name", pastry.Consistency[i].Name),
                                   new XElement("Quantity", pastry.Consistency[i].Quantity),
                                   new XElement("Units", pastry.Consistency[i].Units));
            }

            var pastryXMLElement = new XElement("Pastry",
                                      new XAttribute("Id", pastry.Id),
                                      new XElement("Type", pastry.Type),
                                      new XElement("Name", pastry.Name),
                                      new XElement("Brand", pastry.Brand),
                                      new XElement("Consistency", consistencyXML),
                                      new XElement("ShelfLife", pastry.ShelfLife),
                                      new XElement("DateOfManufacture", pastry.DateOfManufacture));

            if (pastry is Pie)
            {
                pastryXMLElement.Add(new XAttribute("Kind", "Pie"), 
                                        new XElement("Diameter", ((Pie) pastry).Diameter.ToString(CultureInfo.GetCultureInfo("en-US"))));
            }
            else
            {
                pastryXMLElement.Add(new XAttribute("Kind", "BoxOfCandies"),
                                        new XElement("QuantityOfCandies", ((BoxOfCandies)pastry).QuantityOfCandies.ToString(CultureInfo.GetCultureInfo("en-US"))));
            }

            document.Root.Add(pastryXMLElement);
            document.Save(file);
        }

        public Pastry GetPastry(int id)
        {
            var file = ConfigurationManager.AppSettings[PastriesFileName];
            var document = XDocument.Load(file);

            Pastry result;
            var pastry = document.Descendants("Pastry").FirstOrDefault(x => x.Attribute("Id").Value == id.ToString());

            var kind = pastry.Attribute("Kind").Value;

            switch (kind)
            {
                case "Pie":
                    result = new Pie();
                    ((Pie)result).Diameter = double.Parse(pastry.Element("Diameter").Value, CultureInfo.GetCultureInfo("en-US"));
                    break;
                case "BoxOfCandies":
                    result = new BoxOfCandies();
                    ((BoxOfCandies)result).QuantityOfCandies = int.Parse(pastry.Element("QuantityOfCandies").Value, CultureInfo.GetCultureInfo("en-US"));
                    break;
                default:
                    result = new Pastry();
                    break;
            }

            result.Id = int.Parse(pastry.Attribute("Id").Value);
            result.Type = pastry.Element("Type").Value;
            result.Name = pastry.Element("Name").Value;
            result.Brand = pastry.Element("Brand").Value;
            foreach(XElement ingredient in pastry.Element("Consistency").Descendants("Ingredient"))
            {
                result.Consistency.Add(new Ingredient
                {
                    Id = int.Parse(ingredient.Attribute("Id").Value),
                    Name = ingredient.Element("Name").Value,
                    Quantity = int.Parse(ingredient.Element("Quantity").Value),
                    Units = ingredient.Element("Units").Value
                });
            }
            result.ShelfLife = int.Parse(pastry.Element("ShelfLife").Value);
            result.DateOfManufacture = DateTime.Parse(pastry.Element("DateOfManufacture").Value);
            return result;
        }

        public bool IsFresh(int id)
        {
            Pastry pastry = GetPastry(id);
            bool isFresh = DateTime.Today.Subtract(pastry.DateOfManufacture).TotalDays <= pastry.ShelfLife;
            return isFresh;
        }

        public void IsFreshPastry(int pastryId)
        {
            Pastry pastry = GetPastry(pastryId);
            bool isFresh = DateTime.Today.Subtract(pastry.DateOfManufacture).TotalDays <= pastry.ShelfLife;
            OperationContext.Current.GetCallbackChannel<IDuplexFreshnessControlCallback>().SendResult(isFresh);
        }

        public void RequestOperation()
        {
            Thread.Sleep(5000);
        }

        public void RequestOperationException()
        {
            throw new NotImplementedException();
        }

        public void OneWayOperation()
        {
            Thread.Sleep(5000);
        }

        public void OneWayOperationException()
        {
            throw new NotImplementedException();
        }

        public void GetCounter()
        {
            OperationContext.Current.GetCallbackChannel<IDuplexControlCallback>().SendResult(_counter++);
            var sid = OperationContext.Current.SessionId;

            Console.WriteLine("Session: {0}\n Counter = {1}", sid, _counter);
        }

        public void Lock1()
        {
            Console.WriteLine("Thread {0} has started Lock1()", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("Thread {0} has completed Lock1()", Thread.CurrentThread.ManagedThreadId);
        }

        public void Lock2()
        {
            Console.WriteLine("Thread {0} has started Lock2()", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("Thread {0} has completed Lock2()", Thread.CurrentThread.ManagedThreadId);
        }

        public string DoWork()
        {
            string result = string.Empty;

            if (!ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated)
            {
                result = "Пльзователь не идентифицирован!!!\nОперация прервана.";
                Console.WriteLine(result);
                return result;
            }

            result = string.Format("Date: {0}\nAuth type: {1}\nUser: {2}", DateTime.Now.ToString(),
                ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType,
                ServiceSecurityContext.Current.PrimaryIdentity.Name);

            Console.WriteLine(result);

            return result;
        }
    }
}
