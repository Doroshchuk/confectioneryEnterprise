using ConfectioneryEnterprise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectionaryEnterprise.WcfService.Contract
{
    [DataContract]
    public class NullElementFault : BaseId<int>
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public int ShelfLife { get; set; }

        [DataMember]
        public DateTime DateOfManufacture { get; set; }

        [DataMember]
        public int StorageTemperature { get; set; }
    }
}
