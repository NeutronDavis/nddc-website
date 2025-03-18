using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Announcement
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Details { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
