using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Position
    {
        public int PosId { get; set; }
        public string? PositionName { get; set; }
        public string? Category { get; set; }
        public int? Rank { get; set; }
    }
}
