using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    [DataContract]
    public class Pastry : BaseId<int>
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public List<Ingredient> Consistency { get; set; }
        [DataMember]
        public int ShelfLife { get; set; }
        [DataMember]
        public DateTime DateOfManufacture { get; set; }

        public Pastry()
        {
            Consistency = new List<Ingredient>();
        }
    }
}
