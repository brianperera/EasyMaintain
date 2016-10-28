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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class UsersController : Controller
    {
        UsersViewModel UsersViewModel = SessionUtility.utilityUsersModel;
        // GET: /<controller>/
        public IActionResult Index()
        {
            Update();
            return View(UsersViewModel);
        }

        [HttpPost, Route("/Users/createNewMember")]
        public PartialViewResult createNewMember([FromBody]Users Model)
        {
            int finalIndex = (UsersViewModel.Users.Count) - 1;
            Role buffer = UsersViewModel.Roles.Single(r => r.Name == Model.Role.Name);
            Model.Role = buffer;
            Model.UserID = UsersViewModel.Users[finalIndex].UserID + 1;
            // CrewViewModel.CrewList.Add(Model);
            try
            {

                string crewData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8961/api/Crew/", crewData);
                UsersViewModel.Users.Add(Model);
            }
            catch (AggregateException e)
            {
            }

            return PartialView("_EditUserModel", UsersViewModel);

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
            Role buffer = UsersViewModel.Roles.Single(r => r.Name == Model.Role.Name);
            Model.Role = buffer;
            Model.UserID = UsersViewModel.UserID;
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

        [HttpPost, Route("/Users/EditMember")]
        public PartialViewResult EditMember([FromBody]Users ID)
        {

            Users item = UsersViewModel.Users.Single(r => r.UserID == ID.UserID);
            UsersViewModel.currentIndex = UsersViewModel.Users.FindIndex(r => r.UserID == ID.UserID);
            UsersViewModel.UserID = item.UserID;
            UsersViewModel.FirstName = item.FirstName;
            UsersViewModel.LastName = item.LastName;
            UsersViewModel.Role = item.Role;

            return PartialView("_EditUserModel", UsersViewModel);

        }

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
