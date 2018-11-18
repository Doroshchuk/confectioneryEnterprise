using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Production : BaseId<int>
    {
        public IList<Ingredient> Ingredients { get; set; }
        public IList<Confectioner> Confectioners { get; set; }
        public Plan Plan { get; set; }

        public Production()
        {
            Ingredients = new List<Ingredient>();
            Confectioners = new List<Confectioner>();
        }
    }
}
