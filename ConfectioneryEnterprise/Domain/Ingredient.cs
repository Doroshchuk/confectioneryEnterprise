using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    [DataContract]
    public class Ingredient : BaseId<int>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Units { get; set; }
    }
}
