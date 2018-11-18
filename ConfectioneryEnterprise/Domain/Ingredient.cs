using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Ingredient : BaseId<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
    }
}
