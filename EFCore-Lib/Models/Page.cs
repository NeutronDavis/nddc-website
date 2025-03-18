using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        public string? PageName { get; set; }
        public string? PageContent { get; set; }
        public string? RedirectUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
