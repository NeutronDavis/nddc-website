using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class PhotoSpeak
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
