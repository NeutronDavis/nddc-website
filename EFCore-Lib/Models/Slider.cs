using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Slider
    {
        public int Slid { get; set; }
        public string? Subject { get; set; }
        public string? Details { get; set; }
        public string? SlideId { get; set; }
        public string? ImageUrl { get; set; }
        public bool? Enabled { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? TimeStamp { get; set; }
    }
}
