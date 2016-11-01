using EasyMaintain.SecurityWebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static EasyMaintain.SecurityWebAPI.Models.RoleBindingModels;
using Microsoft.AspNet.Identity.Owin;



using System.Web;

using System.Data.Entity;

using System.Threading;
using System.Net;


namespace EasyMaintain.SecurityWebAPI.Controllers
{
     //[Authorize(Roles="Superadmin")]
    [RoutePrefix("api/roles")]
    public class RolesController : ApiController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public AuthContext context { get; private set; }

        

        public RolesController()
        {
            context = new AuthContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        //GET:api/Roles
       // [Route("", Name = "GetAllRoles")]
        [HttpGet]
        public IHttpActionResult GetAllRoles()
        {
            var roles = this.RoleManager.Roles;

            return Ok(roles);
        }
        // POST: api/roles
       // [Route("Post")]
        [HttpPost]
        public async Task<IHttpActionResult> Create(RoleBindingModels roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First().ToString());
                    return BadRequest(ModelState);
                }
               
            }
            return CreatedAtRoute("DefaultApi", new { id = 100 }, roleViewModel);

        }








        // POST api/roles
        //[Route("create")]
        //[HttpPost]
        //public async Task<IHttpActionResult> Post(RoleBindingModels model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var role = new IdentityRole { Name = model.Name };

        //    var result = await this.RoleManager.CreateAsync(role);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id }));

        //    return Created(locationHeader, TheModelFactory.Create(role));

        //}

        //[Route("{id:guid}")]
        //public async Task<IHttpActionResult> DeleteRole(string Id)
        //{

        //    var role = await this.AppRoleManager.FindByIdAsync(Id);

        //    if (role != null)
        //    {
        //        IdentityResult result = await this.AppRoleManager.DeleteAsync(role);

        //        if (!result.Succeeded)
        //        {
        //            return GetErrorResult(result);
        //        }

        //        return Ok();
        //    }

        //    return NotFound();

        //}

        //[Route("ManageUsersInRole")]
        //[HttpGet]
        //public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        //{
        //    var role = await this.RoleManager.FindByIdAsync(model.Id);

        //    if (role == null)
        //    {
        //        ModelState.AddModelError("", "Role does not exist");
        //        return BadRequest(ModelState);
        //    }

        //    foreach (string user in model.EnrolledUsers)
        //    {
        //        var appUser = await this.UserManager.FindByIdAsync(user);

        //        if (appUser == null)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
        //            continue;
        //        }

        //        if (!this.UserManager.IsInRole(user, role.Name))
        //        {
        //            IdentityResult result = await this.UserManager.AddToRoleAsync(user, role.Name);

        //            if (!result.Succeeded)
        //            {
        //                ModelState.AddModelError("", String.Format("User: {0} could not be added to role", user));
        //            }

        //        }
        //    }

        //    foreach (string user in model.RemovedUsers)
        //    {
        //        var appUser = await this.UserManager.FindByIdAsync(user);

        //        if (appUser == null)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
        //            continue;
        //        }

        //        IdentityResult result = await this.UserManager.RemoveFromRoleAsync(user, role.Name);

        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} could not be removed from role", user));
        //        }
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return Ok();
        //}



    }
}
