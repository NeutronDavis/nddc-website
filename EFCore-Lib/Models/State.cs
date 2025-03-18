using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class State
    {
        public int Sid { get; set; }
        public string? StateName { get; set; }
        public string? StateType { get; set; }
    }
}
