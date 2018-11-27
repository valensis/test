using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureStudentManager.Models
{
    public class UserToRolesViewModel
    {
        public List<UsersViewModel> AllUsers { get; set; }
        public List<RolesViewModel> AllRoles { get; set; }
    }

    public class RolesViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UsersViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
