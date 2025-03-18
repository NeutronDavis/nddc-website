using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Program
    {
        public int Nid { get; set; }
        public string? Subject { get; set; }
        public string? Summary { get; set; }
        public string? Details { get; set; }
        public string? NewsId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? TimeStamp { get; set; }
        public bool? Enabled { get; set; }
        public string? Type { get; set; }
        public bool? SetAsSlide { get; set; }
        public string? Tags { get; set; }
        public bool? Archive { get; set; }
        public int? Views { get; set; }
        public int? Clicks { get; set; }
        public int? Ndid { get; set; }
        public int? Cmid { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
