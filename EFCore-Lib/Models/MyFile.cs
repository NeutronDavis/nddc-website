using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class MyFile
    {
        public int FileId { get; set; }
        public string? FileNo { get; set; }
        public string? FileName { get; set; }
        public decimal? Figure { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
