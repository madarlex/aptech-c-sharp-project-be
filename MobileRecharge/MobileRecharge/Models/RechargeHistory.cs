using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [RegularExpression(@"\d{10}", ErrorMessage = "Wrong Mobile Number")]
        public string Phone { get; set; } = null!;

        public virtual Account? Account { get; set; } = null!;
        public virtual Recharge? Recharge { get; set; } = null!;
    }
}
