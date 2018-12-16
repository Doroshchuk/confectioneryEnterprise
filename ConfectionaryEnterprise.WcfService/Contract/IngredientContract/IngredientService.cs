using ConfectioneryEnterprise.Domain;
using ConfectioneryEnterprise.WcfService.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfectionaryEnterprise.WcfService.Contract.IngredientContract
{
    public class IngredientService
    {
        private string FileName => "fileIngredients";

        public Ingredient GetIngredient(int id)
        {
            var file = ConfigurationManager.AppSettings[FileName];
            var document = XDocument.Load(file);

            var result = new Ingredient();
            var ingredient = document.Descendants("Ingredient").FirstOrDefault(x => x.Attribute("Id").Value == id.ToString());
            result.Id = int.Parse(ingredient.Attribute("Id").Value);
            result.Name = ingredient.Element("Name").Value;
            result.Quantity = int.Parse(ingredient.Element("Quantity").Value);
            result.Units = ingredient.Element("Units").Value;
            return result;
        }

        public void SetIngredient(Ingredient ingredient)
        {
            var file = ConfigurationManager.AppSettings[FileName];
            var document = XDocument.Load(file);

            document.Root.Add(new XElement("Ingredient",
                                new XAttribute("Id", ingredient.Id),
                              new XElement("Name", ingredient.Name),
                              new XElement("Quantity", ingredient.Quantity),
                              new XElement("Units", ingredient.Units)));
            document.Save(FileName);
        }
    }
}
