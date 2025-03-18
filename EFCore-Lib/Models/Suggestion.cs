using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Suggestion
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public string? Location { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
