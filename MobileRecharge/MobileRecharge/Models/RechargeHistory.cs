using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class RechargeHistory
    {
        public int Id { get; set; }
        public int RechargeId { get; set; }
        public int AccountId { get; set; }
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Recharge Recharge { get; set; } = null!;
    }
}
