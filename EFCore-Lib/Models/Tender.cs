using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Tender
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Details { get; set; }
        public string? DocumentUrl { get; set; }
        public DateTime? AdvertDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string? AddedBy { get; set; }
    }
}
