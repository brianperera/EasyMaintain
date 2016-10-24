using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;

using EasyMaintain.CoreWebMVC.Utility;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using EasyMaintain.CoreWebMVC.DataEntities;
using System.IO;
using Microsoft.AspNetCore.Authorization;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        MaintenanceViewModel maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;
        MaintenanceCheckViewModel maintenanceCheckViewModel = SessionUtility.utilityMaintenanceCheckViewModel;
        CrewViewModel CrewViewModel = SessionUtility.utilityCrewViewModel;
        // GET: /<controller>/
        // [Route("api/[controller]")]
        public ActionResult Index()
        {

            //string test = User.Identity.Name;

            try
            {
                var uri = "api/Maintenance/Get ";

                List<Maintenance> maintenanceItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionUtility.utilityToken.AccessToken);
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
                }
                maintenanceViewModel.MaintenanceOrders = maintenanceItems;

            }
            catch (AggregateException e)
            {

            }
            maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;
            UpdateMaintenanceViewModel();
            return View(maintenanceViewModel);
        }

        public PartialViewResult CheckItems()
        {

            return PartialView("_CheckItems", maintenanceCheckViewModel);
        }

        public PartialViewResult NewMaintenanceOrder()
        {
            maintenanceViewModel.CrewMembers.Clear();
            maintenanceViewModel.CheckItems.Clear();
            maintenanceViewModel.FlightModel = null;
            maintenanceViewModel.FlightNumber = null;
            maintenanceViewModel.Description = null;
            maintenanceViewModel.CompletionDate = null;
            maintenanceViewModel.StartDate = null;
            maintenanceViewModel.WorkshopLocation = null;
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_1;

            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/SaveTempData")]
        public void SaveTempData([FromBody] Maintenance Model)
        {
            maintenanceViewModel.CompletionDate = Model.CompletionDate;
            maintenanceViewModel.Description = Model.Description;
            maintenanceViewModel.FlightModel = Model.FlightModel;
            maintenanceViewModel.FlightNumber = Model.FlightNumber;
            maintenanceViewModel.StartDate = Model.StartDate;
            maintenanceViewModel.WorkshopLocation = Model.Location;
        }

        [Authorize]
        [HttpPost, Route("/maintenance/CreateMaintenanceOrder")]
        public PartialViewResult CreateMaintenanceOrder([FromBody] Maintenance Model)
        {
            Model.CheckItems = maintenanceViewModel.CheckItems;
            Model.CrewMembers = maintenanceViewModel.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            try
            {

                string maintenanceData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8961/api/Maintenance/", maintenanceData);
                maintenanceViewModel.MaintenanceOrders.Add(Model);
            }
            catch (AggregateException e)
            {
            }
            //maintenanceViewModel.MaintenanceOrders.Add(Model);
            return PartialView("_Search", maintenanceViewModel);
        }

        public void PostAsync(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";

            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }


        [HttpPost, Route("/maintenance/SaveMaintenanceOrder")]
        public PartialViewResult SaveMaintenanceOrder([FromBody] Maintenance Model)
        {
            Model.CheckItems = new List<MaintenanceChecks>();
            Model.CheckItems.AddRange(maintenanceViewModel.CheckItems);
            Model.CrewMembers = new List<Crew>();
            Model.CrewMembers.AddRange(maintenanceViewModel.CrewMembers);
            Model.WorkID = maintenanceViewModel.WorkID;
            int index = maintenanceViewModel.WorkID - 1;
            try
            {
                string maintenanceData = JsonConvert.SerializeObject(Model);
                this.PostAsync("http://localhost:8961/api/Maintenance/", maintenanceData);
                maintenanceViewModel.MaintenanceOrders[index] = Model;
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_Search", maintenanceViewModel);
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




        public PartialViewResult Search()
        {

            return PartialView("_Search", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCheckItem")]
        public PartialViewResult AddCheckItem([FromBody] MaintenanceChecks CheckDiscription)
        {


            maintenanceViewModel.CheckItems.Add(new MaintenanceChecks() { Description = CheckDiscription.Description });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCheckItem")]
        public PartialViewResult DeleteCheckItem([FromBody] MaintenanceChecks CheckDiscription)
        {


            var itemToRemove = maintenanceViewModel.CheckItems.Single(r => r.Description == CheckDiscription.Description);
            maintenanceViewModel.CheckItems.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCrewMember")]
        public PartialViewResult AddCrewMember([FromBody] Crew Model)
        {

            UpdateMaintenanceViewModel();
            Crew Member = maintenanceViewModel.CrewViewModelObj.CrewList.FirstOrDefault(r => r.CrewID == Model.CrewID);

            maintenanceViewModel.CrewMembers.Add(new Crew() { Name = Member.Name, Designation = Member.Designation });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCrewMember")]
        public PartialViewResult DeleteCrewMember([FromBody]Crew CrewMember)
        {



            var itemToRemove = maintenanceViewModel.CrewMembers.Single(r => r.Name == CrewMember.Name);
            maintenanceViewModel.CrewMembers.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/EditMaintenanceOrder")]
        public PartialViewResult EditMaintenanceOrder([FromBody]Maintenance ID)
        {
            Maintenance item;
            //search in the db withn "ID" and put to Object with that ID to "Item" obj

            item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == ID.WorkID);

            try
            {

                string maintenanceID = JsonConvert.SerializeObject(ID.WorkID);

                this.PostAsync("http://localhost:8961/api/Maintenance/5", maintenanceID);

            }
            catch (AggregateException e)
            {
            }


            maintenanceViewModel.WorkID = item.WorkID;
            maintenanceViewModel.CompletionDate = item.CompletionDate;
            maintenanceViewModel.Description = item.Description;
            maintenanceViewModel.FlightModel = item.FlightModel;
            maintenanceViewModel.FlightNumber = item.FlightNumber;
            maintenanceViewModel.StartDate = item.StartDate;
            maintenanceViewModel.WorkshopLocation = item.Location;
            maintenanceViewModel.CrewMembers = item.CrewMembers;
            maintenanceViewModel.CheckItems = item.CheckItems;
            return PartialView("_EditMaintenanceOrder", maintenanceViewModel);

        }


        public void GetAsyncID(string uri, string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            //model.PostData = "Test";
            request.ContentType = "application/json";

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(id);
                sw.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }


        [HttpPost, Route("/maintenance/createNewCheck")]
        public PartialViewResult createNewCheck([FromBody]MaintenanceChecks Model)
        {
            int finalIndex = (maintenanceCheckViewModel.Checks.Count) - 1;

            try
            {
                Model.MaintenanceCheckID = maintenanceCheckViewModel.Checks[finalIndex].MaintenanceCheckID + 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Model.MaintenanceCheckID = 1;
            }
            //maintenanceCheckViewModel.Checks.Add(Model);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;

            try
            {

                string maintenanceCheckData = JsonConvert.SerializeObject(Model);

                this.PostAsync("http://localhost:8961/api/MaintenanceCheck/", maintenanceCheckData);
                maintenanceCheckViewModel.Checks.Add(Model);
            }
            catch (AggregateException e)
            {
            }
            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        [HttpPost, Route("/maintenance/LoadCheck")]
        public PartialViewResult LoadCheck([FromBody]MaintenanceChecks ID)
        {

            MaintenanceChecks item = maintenanceCheckViewModel.Checks.Single(r => r.MaintenanceCheckID == ID.MaintenanceCheckID);
            maintenanceCheckViewModel.currentIndex = maintenanceCheckViewModel.Checks.FindIndex(r => r.MaintenanceCheckID == ID.MaintenanceCheckID);
            maintenanceCheckViewModel.MaintenanceCheckID = item.MaintenanceCheckID;
            maintenanceCheckViewModel.Description = item.Description;
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;

            try
            {
                var uri = "api/MaintenanceCheck/Get ";

                List<MaintenanceChecks> maintenanceCheckItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:8961");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    maintenanceCheckItems = JsonConvert.DeserializeObject<List<MaintenanceChecks>>(response.Result);
                }
                maintenanceCheckViewModel.Checks = maintenanceCheckItems;

            }
            catch (AggregateException e)
            {

            }

            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        [HttpPost, Route("/maintenance/saveEditedCheck")]
        public PartialViewResult saveEditedCheck([FromBody]MaintenanceChecks Model)
        {
            Model.MaintenanceCheckID = maintenanceCheckViewModel.MaintenanceCheckID;
            maintenanceCheckViewModel.Checks[maintenanceCheckViewModel.currentIndex] = Model;
            ClearSession();

            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;

            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        [HttpPost, Route("/maintenance/deleteCheck")]
        public PartialViewResult deleteCheck()
        {

            for (int x = maintenanceCheckViewModel.currentIndex; x <= maintenanceCheckViewModel.Checks.Count - 2; x++)
            {
                int nextIndex = x + 1;
                maintenanceCheckViewModel.Checks[x] = maintenanceCheckViewModel.Checks[nextIndex];
            }

            int finalIndex = maintenanceCheckViewModel.Checks.Count - 1;
            maintenanceCheckViewModel.Checks.RemoveAt(finalIndex);

            ClearSession();
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        [HttpPost, Route("/maintenance/cancel")]
        public PartialViewResult cancel()
        {
            ClearSession();
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        public void UpdateMaintenanceViewModel()
        {
            maintenanceViewModel.AircraftModelModelObj = SessionUtility.utilityAircraftModelModel;
            maintenanceViewModel.Workshops = SessionUtility.utilityWorkshopModel;
            maintenanceViewModel.CrewViewModelObj = SessionUtility.utilityCrewViewModel;
            maintenanceViewModel.MaintenanceCheckViewModelObj = SessionUtility.utilityMaintenanceCheckViewModel;
            maintenanceViewModel.token = SessionUtility.utilityToken;

        }

        public void ClearSession()
        {
            maintenanceCheckViewModel.MaintenanceCheckID = 0;
            maintenanceCheckViewModel.Description = null;
        }
    }
}
