using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class Recharge
    {
        public Recharge()
        {
            RechargeHistories = new HashSet<RechargeHistory>();
        }

        public int Id { get; set; }
        public double? Minutes { get; set; }
        public double? Data { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int RechargeTypeId { get; set; }

        public virtual RechargeType RechargeType { get; set; } = null!;
        public virtual ICollection<RechargeHistory> RechargeHistories { get; set; }
    }
}
