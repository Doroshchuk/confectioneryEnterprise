using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Pastry : BaseId<int>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Brand { get; } = "DDV";
        public IList<Ingredient> Consistency { get; set; }
        public int ShelfLife { get; set; }
        public DateTime DateOfManufacture { get; set; }

        public Pastry()
        {
            Consistency = new List<Ingredient>();
            Brand = "DDV";
        }
    }
}
