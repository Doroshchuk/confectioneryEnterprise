using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    [DataContract]
    public class BaseId<T> where T : struct
    {
        [DataMember]
        public T Id { get; set; }
    }
}
