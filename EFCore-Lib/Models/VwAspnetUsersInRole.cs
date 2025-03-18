using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class VwAspnetUsersInRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
