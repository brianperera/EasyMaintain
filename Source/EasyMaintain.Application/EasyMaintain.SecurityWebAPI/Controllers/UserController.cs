using EasyMaintain.SecurityWebAPI.Utility;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EasyMaintain.SecurityWebAPI.Controllers
{
   public class UserController :ApiController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public AuthContext context { get; private set; }

        //ApplicationUser appUser = new ApplicationUser();

        public UserController()
        {

            context = new AuthContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        [HttpGet]
      //GET api/User
        public IHttpActionResult Userdata()
        {

            var user = this.UserManager.Users;

            return Ok(user);

            if (user != null)
            {
                var props = new Dictionary<string, string>
                {

                    {
                        "Name", SessionUtility.user.FirstName
                    },
                    {
                        "Email", SessionUtility.user.Email
                    },
                    {
                        "PhoneNumber", SessionUtility.user.PhoneNumber
                    }

               };

                return Ok(props);
            }
            else
            {
                return Ok("NO USER LOGGEDIN");
            }

        }

        //[HttpPost]
        //[Route("CustomUserdata")]
        //public IHttpActionResult CustomUserdata()
        //{
        //    if (SessionUtility.user != null)
        //    {
        //        var props = new Dictionary<string, string>
        //        {

        //            {
        //                "FirstName", SessionUtility.user.FirstName
        //            },
        //            {
        //                "LastName", SessionUtility.user.LastName
        //            },
        //            {
        //                "Email", SessionUtility.user.Email
        //            },
        //            {
        //                "UserID", SessionUtility.user.Id
        //            }

        //       };

        //        return Ok(props);
        //    }
        //    else
        //    {
        //        return Ok("NO USER LOGGEDIN");
        //    }
        

    }
}
