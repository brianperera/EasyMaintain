using EasyMaintain.SecurityWebAPI.Models;
using EasyMaintain.SecurityWebAPI.Utility;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EasyMaintain.SecurityWebAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }


        [Authorize]
        [HttpGet]
        [Route("Userdata")]
        public IHttpActionResult Userdata()
        {
            if (SessionUtility.user != null)
            {
                var props = new Dictionary<string, string>
                {
                    {
                        "Username", SessionUtility.user.UserName
                    },
                    {
                        "ID", SessionUtility.user.Id
                    },
                    {
                        "Name", SessionUtility.user.Name
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
