using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class ProjectList
    {
        public int Pid { get; set; }
        public string? Description { get; set; }
        public string? Contractor { get; set; }
        public string? Location { get; set; }
        public string? Lga { get; set; }
        public string? State { get; set; }
        public string? Type { get; set; }
        public string? DateOfAward { get; set; }
        public decimal? ContractSum { get; set; }
        public string? Status { get; set; }
    }
}
