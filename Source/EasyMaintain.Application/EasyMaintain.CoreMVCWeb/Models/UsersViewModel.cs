using EasyMaintain.CoreWebMVC.DataEntities;
using EasyMaintain.CoreWebMVC.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMaintain.CoreWebMVC.Models
{
    public class UsersViewModel
    {
        [Required]
        [Display(Name = "First Name")] 
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public Role Role { get; set; }

        public int UserID { get; set; }

        public int currentIndex { get; set; }

        public List<Users> Users { get; set; }
        public List<Role> Roles { get; set; }


        public UsersViewModel()
        {
            Users = new List<Users>();
            Users.Add(new Users()
            {
                UserID = 1,
                FirstName = "Test Role",
                Role = new Role()
            });
            Roles = SessionUtility.utilityRoleModel.Roles;
        }
    }
}
