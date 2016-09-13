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
        MaintenanceViewModel session = SessionUtility.utilityMaintenanceViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            session = SessionUtility.utilityMaintenanceViewModel;
            return View(session);
        }

        public PartialViewResult NewMaintenanceOrder()
        {
            session.CrewMembers.Clear();
            session.CheckItems.Clear();
            session.FlightModel = null;
            session.FlightNumber = null;
            session.Description = null;
            session.CompletionDate = null;
            session.StartDate = null;
            session.WorkshopLocation = null;
            session.ActiveTab = SessionUtility.Frame_1;
            return PartialView("_NewMaintenanceOrder", session);
        }

        [HttpPost, Route("/maintenance/SaveTempData")]
        public void SaveTempData([FromBody] Maintenance Model)
        {
            session.CompletionDate = Model.CompletionDate;
            session.Description = Model.Description;
            session.FlightModel = Model.FlightModel;
            session.FlightNumber = Model.FlightNumber;
            session.StartDate = Model.StartDate;
            session.WorkshopLocation = Model.Location;
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
            session.MaintenanceOrders = maintenanceItems;


            Model.CheckItems = session.CheckItems;
            Model.CrewMembers = session.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            session.MaintenanceOrders.Add(Model);
            return PartialView("_Search", session);
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
            session.MaintenanceOrders = maintenanceItems;


            //var maintenanceViewModel = new MaintenanceViewModel();
            return PartialView("_Search", session);
        }

        [HttpPost, Route("/maintenance/AddCheckItem")]
        public PartialViewResult AddCheckItem([FromBody] Check CheckDiscription)
        {
            var uri = "api/MaintenanceAdd/5";
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
            var uri = "api/MaintenanceDelete/5";
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
            session.CrewMembers.Add(new Crew() { Name = Model.Name, Designation = Model.Designation });
            session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", session);
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
        public PartialViewResult EditMaintenanceOrder([FromBody]Maintenance ID) {

            var uri = "api/Engine/EngineTypeUpdate";
            List<Maintenance> maintenanceItems;

            Maintenance item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == ID.WorkID);
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                maintenanceItems = JsonConvert.DeserializeObject<List<Maintenance>>(response.Result);
            }
            session.MaintenanceOrders = maintenanceItems;
            
            session.WorkID = item.WorkID;
            session.CompletionDate = item.CompletionDate;
            session.Description = item.Description;
            session.FlightModel = item.FlightModel;
            session.FlightNumber = item.FlightNumber;
            session.StartDate = item.StartDate;
            session.WorkshopLocation = item.Location;
            session.CrewMembers = item.CrewMembers;
            session.CheckItems = item.CheckItems;

            return PartialView("_EditMaintenanceOrder", session);

           // Maintenance item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == Int32.Parse(WorkID));

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
