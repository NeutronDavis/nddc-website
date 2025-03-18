using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Director
    {
        public int Id { get; set; }
        public string? DirectorName { get; set; }
        public string? Position { get; set; }
        public string? ImageUrl { get; set; }
        public string? Details { get; set; }
        public int? PositionCount { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
