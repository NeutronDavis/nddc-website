using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class UsersInAccount
    {
        public int Uaid { get; set; }
        public string? Aid { get; set; }
        public string? Username { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
