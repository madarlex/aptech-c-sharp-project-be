using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class FeedBack
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
    }
}
