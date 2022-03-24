using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class PostPaid
    {
        public PostPaid()
        {
            PostPaidHistories = new HashSet<PostPaidHistory>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PostPaidHistory> PostPaidHistories { get; set; }
    }
}
