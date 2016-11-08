using EasyMaintain.SecurityWebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EasyMaintain.SecurityWebAPI.Controllers
{
    public class AssignRolesController : ApiController
    {
        // ApplicationUserManager AppUserManager = new ApplicationUserManager();


        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        //public RoleBindingModels<RoleBindingModels> RoleBinding { get; private set; }
        public AuthContext context { get; private set; }



        public AssignRolesController()
        {
            context = new AuthContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public AssignRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        //GET:api/AssignRoles
        [Authorize]
        [Route("user/{id}/GetAssignedRoles")]
        [HttpGet]
        public IHttpActionResult GetAssignedRoles([FromUri] string id)
        {
            var roles = this.UserManager.GetRolesAsync(id);

            return Ok(roles);
        }

        //[HttpPut]
        //public async Task<IHttpActionResult> Put(ApplicationUser id, string RoleId, [FromBody]ApplicationUser user)
        //{


        //    if (id == null)
        //    {

        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        var rolesForUser =await  UserManager.GetRolesAsync(id.ToString());

        //        if (!String.IsNullOrEmpty(RoleId))
        //        {
        //            //Find Role
        //            var role = await RoleManager.FindByIdAsync(RoleId);
        //            //Add user to new role
        //            var result = await  UserManager.AddToRoleAsync(id.ToString(), role.Name);
        //            if (!result.Succeeded)
        //            {
        //                ModelState.AddModelError("", result.Errors.First().ToString());
        //                return BadRequest(ModelState);

        //            }
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);



        //}












        // PUT api/AssignRoles

        //[HttpPut]
        //public async Task<IHttpActionResult> AssignRolesToUser(ApplicationUser Reguser, string id, string RoleId)
        //{
        //    if (id == null)
        //    {

        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        var rolesForUser = await UserManager.GetRolesAsync(id);

        //        if (!String.IsNullOrEmpty(RoleId))
        //        {
        //            //Find Role
        //            var role = await RoleManager.FindByIdAsync(RoleId);
        //            //Add user to new role
        //            var result = await UserManager.AddToRoleAsync(id, role.Name);
        //            if (!result.Succeeded)
        //            {
        //                ModelState.AddModelError("", result.Errors.First().ToString());
        //                return BadRequest(ModelState);

        //            }
        //        }
        //    }

        //        return StatusCode(HttpStatusCode.NoContent);



        //}




        [Authorize]
        [Route("user/{id}/rolesToAssign")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.UserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.UserManager.GetRolesAsync(appUser.Id);



            var rolesNotExists = rolesToAssign.Except(this.RoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            if (currentRoles.Count>0)
            {
                IdentityResult removeResult = await this.UserManager.RemoveFromRoleAsync(appUser.Id, currentRoles[0]);
                if (!removeResult.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove user roles");
                    return BadRequest(ModelState);
                }
            }

            string role = rolesToAssign[0];
            IdentityResult addResult = await this.UserManager.AddToRoleAsync(appUser.Id, role);
            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }






    }
}
