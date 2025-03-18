using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class MngtStaff
    {
        public int Msid { get; set; }
        public string? StaffName { get; set; }
        public string? Position { get; set; }
        public string? ImageUrl { get; set; }
        public int? PositionCount { get; set; }
    }
}
