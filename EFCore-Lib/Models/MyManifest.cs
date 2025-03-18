using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class MyManifest
    {
        public int ManId { get; set; }
        public string? ManDesc { get; set; }
        public string? FileType { get; set; }
        public int? ItemId { get; set; }
        public DateTime? DateReceived { get; set; }
        public string? ReceivedBy { get; set; }
        public string? Flow { get; set; }
    }
}
