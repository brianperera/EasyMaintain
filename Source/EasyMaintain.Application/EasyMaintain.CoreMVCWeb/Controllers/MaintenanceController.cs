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



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        MaintenanceViewModel maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;
        MaintenanceCheckViewModel maintenanceCheckViewModel = SessionUtility.utilityMaintenanceCheckViewModel;
        // GET: /<controller>/
        // [Route("api/[controller]")]
        public ActionResult Index()
        {
            //try
            //{
            //    var uri = "api/values/Maintenance ";

            //    List<Maintenance> maintenanceItems;

            //    using (HttpClient httpClient = new HttpClient())
            //    {
            //        httpClient.BaseAddress = new Uri("http://localhost:172.204.144");
            //        Task<String> response = httpClient.GetStringAsync(uri);
            //        maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            //    }
            //    maintenanceViewModel.MaintenanceOrders =  maintenanceItems;

            //}
            //catch (AggregateException e)
            //{

            //}
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

        [HttpPost, Route("/maintenance/CreateMaintenanceOrder")]
        public PartialViewResult CreateMaintenanceOrder([FromBody] Maintenance Model)
        {
            try
            {
                var uri = "api/values/5  ";

                List<Maintenance> maintenanceItems;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:9000/");
                    Task<String> response = httpClient.GetStringAsync(uri);
                    maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
                }
                maintenanceViewModel.MaintenanceOrders = maintenanceItems;

            }
            catch (AggregateException e)
            {

            }

            Model.CheckItems = maintenanceViewModel.CheckItems;
            Model.CrewMembers = maintenanceViewModel.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            maintenanceViewModel.MaintenanceOrders.Add(Model);
            return PartialView("_Search", maintenanceViewModel);
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
            maintenanceViewModel.MaintenanceOrders[index] = Model;
            return PartialView("_Search", maintenanceViewModel);
        }

        public PartialViewResult Search()
        {
            //var uri = "api/Engine/EngineTypes";
            //List<Maintenance> maintenanceItems;

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            //}
            //maintenanceViewModel.MaintenanceOrders = maintenanceItems;


            //var maintenanceViewModel = new MaintenanceViewModel();
            return PartialView("_Search", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCheckItem")]
        public PartialViewResult AddCheckItem([FromBody] MaintenanceChecks CheckDiscription)
        {
            //var uri = "api/Engine/MaintenanceAdd/5";
            //List<MaintenanceChecks> maintenanceChecks;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceChecks = JsonConvert.DeserializeObject<List<MaintenanceChecks>>(response.Result);
            //}

            //maintenanceViewModel.CheckItems = maintenanceChecks;

            maintenanceViewModel.CheckItems.Add(new MaintenanceChecks() { Description = CheckDiscription.Description });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCheckItem")]
        public PartialViewResult DeleteCheckItem([FromBody] MaintenanceChecks CheckDiscription)
        {
            //var uri = "api/Engine/MaintenanceDelete/5";
            //List<MaintenanceChecks> maintenanceChecks;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceChecks = JsonConvert.DeserializeObject<List<MaintenanceChecks>>(response.Result);
            //}
            //maintenanceViewModel.CheckItems = maintenanceChecks;

            var itemToRemove = maintenanceViewModel.CheckItems.Single(r => r.Description == CheckDiscription.Description);
            maintenanceViewModel.CheckItems.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCrewMember")]
        public PartialViewResult AddCrewMember([FromBody] Crew Model)
        {
            //var uri = "api/CrewAdd/5";
            //List<Crew> maintenanceCrew;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceCrew = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
            //}
            //maintenanceViewModel.CrewMembers = maintenanceCrew;

            UpdateMaintenanceViewModel();
            Crew Member = maintenanceViewModel.CrewViewModelObj.CrewList.Single(r => r.CrewID == Model.CrewID);

            maintenanceViewModel.CrewMembers.Add(new Crew() { Name = Member.Name, Designation = Member.Designation });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCrewMember")]
        public PartialViewResult DeleteCrewMember([FromBody]Crew CrewMember)
        {

            //var uri = "api/Crew/CrewDelete/5";
            //List<Crew> maintenanceCrew;
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceCrew = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
            //}
            //maintenanceViewModel.CrewMembers = maintenanceCrew;

            var itemToRemove = maintenanceViewModel.CrewMembers.Single(r => r.Name == CrewMember.Name);
            maintenanceViewModel.CrewMembers.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/EditMaintenanceOrder")]
        public PartialViewResult EditMaintenanceOrder([FromBody]Maintenance ID)
        {

            //var uri = "api/Engine/EngineTypeUpdate";
            //List<Maintenance> maintenanceItems;

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    Task<String> response = httpClient.GetStringAsync(uri);
            //    maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            //}
            //maintenanceViewModel.MaintenanceOrders = maintenanceItems;

            Maintenance item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == ID.WorkID);

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

        [HttpPost, Route("/maintenance/createNewCheck")]
        public PartialViewResult createNewCheck([FromBody]MaintenanceChecks Model)
        {
            int finalIndex = (maintenanceCheckViewModel.Checks.Count) - 1;
            try {
                Model.MaintenanceCheckID = maintenanceCheckViewModel.Checks[finalIndex].MaintenanceCheckID + 1;
            }
            catch(ArgumentOutOfRangeException) {
                Model.MaintenanceCheckID = 1;
            }
            maintenanceCheckViewModel.Checks.Add(Model);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;

            return PartialView("_CheckItems", maintenanceCheckViewModel);

        }

        [HttpPost, Route("/maintenance/LoadCheck")]
        public PartialViewResult LoadCheck([FromBody]MaintenanceChecks ID)
        {

            MaintenanceChecks item = maintenanceCheckViewModel.Checks.Single(r => r.MaintenanceCheckID == ID.MaintenanceCheckID);
            maintenanceCheckViewModel.currentIndex= maintenanceCheckViewModel.Checks.FindIndex(r => r.MaintenanceCheckID == ID.MaintenanceCheckID);
            maintenanceCheckViewModel.MaintenanceCheckID = item.MaintenanceCheckID;
            maintenanceCheckViewModel.Description = item.Description;
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;

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

        }

        public void ClearSession()
        {
            maintenanceCheckViewModel.MaintenanceCheckID = 0;
            maintenanceCheckViewModel.Description= null;
        }
    }
}
