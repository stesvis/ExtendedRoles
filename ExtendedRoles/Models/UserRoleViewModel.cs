using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtendedRoles.Models
{
    public class UserRoleViewModel
    {
        public bool IsSuperAdmin { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDriver { get; set; }
    }
}