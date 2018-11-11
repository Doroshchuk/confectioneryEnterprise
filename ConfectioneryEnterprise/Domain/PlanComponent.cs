using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class PlanComponent : BaseId<int>
    {
        public Recipe Recipe { get; set; }
        public int Quantity { get; set; }
    }
}
