using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class PostPaidHistory
    {
        public int Id { get; set; }
        public int PostPaidId { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        public int AccountId { get; set; }
        public string Code { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Phone { get; set; } = null!;

        public virtual Account? Account { get; set; } = null!;
        public virtual PostPaid? PostPaid { get; set; } = null!;
    }
}
