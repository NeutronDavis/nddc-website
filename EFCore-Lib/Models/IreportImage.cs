using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class IreportImage
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public int? IreportId { get; set; }
    }
}
