using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class Account
    {
        public Account()
        {
            PostPaidHistories = new HashSet<PostPaidHistory>();
            RechargeHistories = new HashSet<RechargeHistory>();
        }

        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string IdentityCard { get; set; } = null!;
        public int Status { get; set; }
        public string Password { get; set; } = null!;
        public string? ActiveToken { get; set; }
        public string? ResetToken { get; set; }

        public virtual AccountType AccountType { get; set; } = null!;
        public virtual ICollection<PostPaidHistory> PostPaidHistories { get; set; }
        public virtual ICollection<RechargeHistory> RechargeHistories { get; set; }
    }
}
