using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Subscription
    {
        public int SubId { get; set; }
        public string? Email { get; set; }
    }
}
