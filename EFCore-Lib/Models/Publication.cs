using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Publication
    {
        public int PubId { get; set; }
        public string? PubTitle { get; set; }
        public string? PubSummary { get; set; }
        public string? PubThumbImage { get; set; }
        public string? PubUploadUrl { get; set; }
        public DateTime? DateUploaded { get; set; }
        public string? UploadedBy { get; set; }
    }
}
