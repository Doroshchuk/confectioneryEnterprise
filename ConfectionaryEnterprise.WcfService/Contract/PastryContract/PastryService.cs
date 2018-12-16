using ConfectionaryEnterprise.WcfService.Contract.IngredientContract;
using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryContract
{
    public class PastryService : IngredientService, IPastryService, IIngredientService
    {
        private string FileName => "filePastries";

        public void SetPastry(Pastry pastry)
        {
            var file = ConfigurationManager.AppSettings[FileName];
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
            document.Root.Add(new XElement("Pastry", 
                              new XAttribute("Id", pastry.Id),
                              new XElement("Type", pastry.Type),
                              new XElement("Name", pastry.Name),
                              new XElement("Brand", pastry.Brand),
                              new XElement("Consistency", consistencyXML),
                              new XElement("ShelfLife", pastry.ShelfLife),
                              new XElement("DateOfManufacture", pastry.DateOfManufacture)));
            document.Save(file);
        }

        public Pastry GetPastry(int id)
        {
            var file = ConfigurationManager.AppSettings[FileName];
            var document = XDocument.Load(file);

            var result = new Pastry();
            var pastry = document.Descendants("Pastry").FirstOrDefault(x => x.Attribute("Id").Value == id.ToString());
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
    }
}
