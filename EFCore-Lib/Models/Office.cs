using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Office
    {
        public int OffId { get; set; }
        public string? OfficeName { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
    }
}
