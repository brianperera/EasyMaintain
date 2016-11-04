using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using EasyMaintain.CoreWebMVC.Utility;
using Newtonsoft.Json;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class UsersController : Controller
    {
        public UserManager<ApplicationUser> Usermanager { get; private set; }
       
        UsersViewModel UsersViewModel = SessionUtility.utilityUsersModel;
        // GET: /<controller>/
        public IActionResult Index()
        {
            UsersViewModel.Username = SessionUtility.utilityUserdataModel.Username;
            UsersViewModel.ID = SessionUtility.utilityUserdataModel.ID;
            UsersViewModel.Name = SessionUtility.utilityUserdataModel.Name;
            UsersViewModel.Email = SessionUtility.utilityUserdataModel.Email;
            UsersViewModel.PhoneNumber = SessionUtility.utilityUserdataModel.PhoneNumber;


            try
            {
                var uri = "api/User/Userdata ";

                List<Users> userList;

                using (HttpClient httpClient = new HttpClient())
                {
                    // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionUtility.utilityToken.AccessToken);
                    httpClient.BaseAddress = new Uri("http://localhost:8533");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    userList = JsonConvert.DeserializeObject<List<Users>>(response.Result);
                }
                UsersViewModel.Users = userList;

            }
            catch (AggregateException e)
            {

            }

            Update();
            UsersViewModel = SessionUtility.utilityUsersModel;
            UsersViewModel.token = SessionUtility.utilityToken;
            return View(UsersViewModel);
        }

 

        [HttpPost, Route("/Users/createNewMember")]
        public PartialViewResult createNewMember([FromBody]Users Model)
        {
            int finalIndex = (UsersViewModel.Users.Count) - 1;
           // Role buffer = UsersViewModel.Roles.Single(r => r.Name == Model.Role.Name);
           // Model.Role = buffer;
          // Model.UserID = UsersViewModel.Users[finalIndex].UserID + 1;

            try
            {

                string userID = JsonConvert.SerializeObject(Model.UserID);

                this.PutAsync("http://localhost:8533/api/AssignRoles/AssignRolesToUser", userID);

            }
            catch (AggregateException e)
            {
            }
            return PartialView("_EditUserModel", UsersViewModel);

        }


        public void PutAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PUT";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }





        public void PostAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        [HttpPost, Route("/Users/saveEditedMember")]
        public PartialViewResult saveEditedMember([FromBody]Users Model)
        {
            Update();
            //Role buffer = UsersViewModel.Roles.Single(r => r.Name == Model.Role.Name);
            //Model.Role = buffer;
            //Model.UserID = UsersViewModel.UserID;
            UsersViewModel.Users[UsersViewModel.currentIndex] = Model;
            ClearSession();
            return PartialView("_EditUserModel", UsersViewModel);

        }

        [HttpPost, Route("/Users/deleteMember")]
        public PartialViewResult deleteMember()
        {

            for (int x = UsersViewModel.currentIndex; x <= UsersViewModel.Users.Count - 2; x++)
            {
                int nextIndex = x + 1;
                UsersViewModel.Users[x] = UsersViewModel.Users[nextIndex];
            }

            int finalIndex = UsersViewModel.Users.Count - 1;
            UsersViewModel.Users.RemoveAt(finalIndex);

            ClearSession();

            return PartialView("_EditUserModel", UsersViewModel);

        }

        //[HttpPost, Route("/Users/EditMember")]
        //public PartialViewResult EditMember([FromBody]Users ID)
        //{

        //    Users item = UsersViewModel.Users.Single(r => r.UserID == ID.UserID);
        //    UsersViewModel.currentIndex = UsersViewModel.Users.FindIndex(r => r.UserID == ID.UserID);
        //    UsersViewModel.UserID = item.UserID;
        //    UsersViewModel.FirstName = item.FirstName;
        //    UsersViewModel.LastName = item.LastName;
        //    UsersViewModel.Role = item.Role;

        //    return PartialView("_EditUserModel", UsersViewModel);

        //}

        [HttpPost, Route("/Users/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();

            return PartialView("_EditUserModel", UsersViewModel);

        }


        public void ClearSession()
        {
            UsersViewModel.UserID = 0;
            UsersViewModel.FirstName = null;
            UsersViewModel.LastName = null;
            UsersViewModel.Role = null;

        }
        public void Update()
        {
             UsersViewModel.Roles = SessionUtility.utilityRoleModel.Roles;
        }

    }
}
