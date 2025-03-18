using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Video
    {
        public int Id { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoDesc { get; set; }
        public string? YoutubeUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}
