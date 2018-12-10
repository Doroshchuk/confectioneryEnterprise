using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectioneryEnterprise.WcfService.Contract.PastryService
{
    public class PastryService : IBaseService, IPastryService
    {
        private string FileName => "filePastries";

        public void SetPastry(Pastry pastry)
        {
            var document = LoadDocument(FileName);
            //consistency ??
            document.Root.Add(new XElement("Pastry", new XAttribute("Id", pastry.Id), new XElement("Type", pastry.Type),
                new XElement("Name", pastry.Name), new XElement("Brand", pastry.Brand), new XElement("ShelfLife", pastry.ShelfLife),
                new XElement("DateOfManufacture", pastry.DateOfManufacture)));
            document.Save(FileName);
        }

        public Pastry GetPastry(int id)
        {
            var document = LoadDocument(FileName);
            var result = new Pastry();
            var pastry = document.Descendants("Pastry").FirstOrDefault(x => x.Attribute("Id").Value == id.ToString());
            result.Id = int.Parse(pastry.Element("Id").Value);
            result.Type = pastry.Element("Type").Value;
            result.Name = pastry.Element("Name").Value;
            result.Brand = pastry.Element("Brand").Value;
            result.Consistency = new List<Ingredient>(); //??
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
