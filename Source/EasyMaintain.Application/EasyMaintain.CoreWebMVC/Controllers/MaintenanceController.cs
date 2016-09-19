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


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        MaintenanceViewModel maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;
            return View(maintenanceViewModel);
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
            var uri = "api/Engine/MaintenanceAdd";

            List<Maintenance> maintenanceItems;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            }
            maintenanceViewModel.MaintenanceOrders = maintenanceItems;


            Model.CheckItems = maintenanceViewModel.CheckItems;
            Model.CrewMembers = maintenanceViewModel.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            maintenanceViewModel.MaintenanceOrders.Add(Model);
            return PartialView("_Search", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/SaveMaintenanceOrder")]
        public PartialViewResult SaveMaintenanceOrder([FromBody] Maintenance Model)
        {
            Model.CheckItems = new List<Check>();
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
            var uri = "api/Engine/EngineTypes";
            List<Maintenance> maintenanceItems;

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            }
            maintenanceViewModel.MaintenanceOrders = maintenanceItems;


            //var maintenanceViewModel = new MaintenanceViewModel();
            return PartialView("_Search", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCheckItem")]
        public PartialViewResult AddCheckItem([FromBody] Check CheckDiscription)
        {
            var uri = "api/Engine/MaintenanceAdd/5";
            List<Check> maintenanceChecks;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceChecks = JsonConvert.DeserializeObject<List<Check>>(response.Result);
            }

            maintenanceViewModel.CheckItems = maintenanceChecks;

            maintenanceViewModel.CheckItems.Add(new Check() { Description = CheckDiscription.Description });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCheckItem")]
        public PartialViewResult DeleteCheckItem([FromBody] Check CheckDiscription)
        {
            var uri = "api/Engine/MaintenanceDelete/5";
            List<Check> maintenanceChecks;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceChecks = JsonConvert.DeserializeObject<List<Check>>(response.Result);
            }
            maintenanceViewModel.CheckItems = maintenanceChecks;

            var itemToRemove = maintenanceViewModel.CheckItems.Single(r => r.Description == CheckDiscription.Description);
            maintenanceViewModel.CheckItems.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/AddCrewMember")]
        public PartialViewResult AddCrewMember([FromBody] Crew Model)
        {
            var uri = "api/CrewAdd/5";
            List<Crew> maintenanceCrew;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceCrew = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
            }
            maintenanceViewModel.CrewMembers = maintenanceCrew;

            maintenanceViewModel.CrewMembers.Add(new Crew() { Name = Model.Name, Designation = Model.Designation });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpDelete, Route("/maintenance/DeleteCrewMember")]
        public PartialViewResult DeleteCrewMember([FromBody]Crew CrewMember)
        {

            var uri = "api/Crew/CrewDelete/5";
            List<Crew> maintenanceCrew;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceCrew = JsonConvert.DeserializeObject<List<Crew>>(response.Result);
            }
            maintenanceViewModel.CrewMembers = maintenanceCrew;

            var itemToRemove = maintenanceViewModel.CrewMembers.Single(r => r.Name == CrewMember.Name);
            maintenanceViewModel.CrewMembers.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        [HttpPost, Route("/maintenance/EditMaintenanceOrder")]
        public PartialViewResult EditMaintenanceOrder([FromBody]Maintenance ID)
        {

            var uri = "api/Engine/EngineTypeUpdate";
            List<Maintenance> maintenanceItems;

            Maintenance item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == ID.WorkID);
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            }
            maintenanceViewModel.MaintenanceOrders = maintenanceItems;

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

    }
}
