using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class SightsAndIcon
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set; }
        public string? Details { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
