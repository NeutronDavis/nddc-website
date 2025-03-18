using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class NewsDepartment
    {
        public int Ndid { get; set; }
        public string? DeptName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
