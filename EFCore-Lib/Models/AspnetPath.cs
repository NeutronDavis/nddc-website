using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class AspnetPath
    {
        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        public string Path { get; set; } = null!;
        public string LoweredPath { get; set; } = null!;
    }
}
