using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string? Subject { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string KeyGuide { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
