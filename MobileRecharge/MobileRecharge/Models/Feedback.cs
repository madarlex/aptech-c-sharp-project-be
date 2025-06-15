using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
        public string Description { get; set; } = null!;
    }
}
