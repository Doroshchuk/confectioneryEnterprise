using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Shop : BaseId<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Pastry> Assortment { get; set; }

        public Shop()
        {
            Assortment = new List<Pastry>();
        }
    }
}
