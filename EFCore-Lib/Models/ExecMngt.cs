using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class ExecMngt
    {
        public int Emid { get; set; }
        public string? ExecName { get; set; }
        public string? Position { get; set; }
        public string? Details { get; set; }
        public string? ImageUrl { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public int? PositionCount { get; set; }
    }
}
