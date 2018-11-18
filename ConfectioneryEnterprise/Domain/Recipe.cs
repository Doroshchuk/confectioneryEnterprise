using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Recipe : BaseId<int>
    {
        public string Name { get; set; }
        public IList<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
