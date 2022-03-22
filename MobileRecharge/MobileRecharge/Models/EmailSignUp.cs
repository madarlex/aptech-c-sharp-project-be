using System;
using System.Collections.Generic;

namespace MobileRecharge.Models
{
    public partial class EmailSignUp
    {
        public string Email { get; set; } = null!;
        public string Otp { get; set; } = null!;
    }
}
