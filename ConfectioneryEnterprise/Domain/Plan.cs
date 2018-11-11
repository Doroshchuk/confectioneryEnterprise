using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Domain
{
    public class Plan : BaseId<int>
    {
        public IList<PlanComponent> Components { get; set; }

        public Plan()
        {
            Components = new List<PlanComponent>();
        }
    }
}
