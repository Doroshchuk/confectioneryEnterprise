using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public abstract class Recipe : BaseId<int>
    {
        public IList<Ingredient> Ingredients { get; set; }

        protected Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
