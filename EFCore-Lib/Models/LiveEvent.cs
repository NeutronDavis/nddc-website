using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class LiveEvent
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Theme { get; set; }
        public string? Summary { get; set; }
        public string? Details { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public string? BannerImage { get; set; }
        public string? TrailerVideo { get; set; }
        public string? LiveEventLink { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public bool? ShowOnHomePage { get; set; }
    }
}
