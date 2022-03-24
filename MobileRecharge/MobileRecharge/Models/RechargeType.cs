using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class RechargeType
    {
        public RechargeType()
        {
            Recharges = new HashSet<Recharge>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Recharge> Recharges { get; set; }
    }
}
