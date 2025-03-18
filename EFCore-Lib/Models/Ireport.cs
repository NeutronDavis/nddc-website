using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Ireport
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? State { get; set; }
        public string? Location { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }
    }
}
