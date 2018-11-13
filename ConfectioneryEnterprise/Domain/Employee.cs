using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public abstract class Employee : Person
    {
        public int WorkNumber { get; set; }

        public string Password { get; set; }
    }
}
