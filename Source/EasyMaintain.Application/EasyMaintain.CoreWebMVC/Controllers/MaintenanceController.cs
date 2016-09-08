using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
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
            //var maintenanceViewModel = new MaintenanceViewModel();
            maintenanceViewModel = SessionUtility.utilityMaintenanceViewModel;            
            return View(maintenanceViewModel);
        }

        public PartialViewResult NewMaintenanceOrder()
        {
            //SessionUtility.utilityMaintenanceViewModel = new MaintenanceViewModel();
            //session = SessionUtility.utilityMaintenanceViewModel;
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

        public void SaveTempData(Maintenance Model)
        {
            maintenanceViewModel.CompletionDate = Model.CompletionDate;
            maintenanceViewModel.Description = Model.Description;
            maintenanceViewModel.FlightModel = Model.FlightModel;
            maintenanceViewModel.FlightNumber = Model.FlightNumber;
            maintenanceViewModel.StartDate = Model.StartDate;
            maintenanceViewModel.WorkshopLocation = Model.Location;
        }

        public PartialViewResult CreateMaintenanceOrder(Maintenance Model)
        { 
            Model.CheckItems = maintenanceViewModel.CheckItems;
            Model.CrewMembers = maintenanceViewModel.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            maintenanceViewModel.MaintenanceOrders.Add(Model);
            return PartialView("_Search", maintenanceViewModel);
        }

        public PartialViewResult SaveMaintenanceOrder(Maintenance Model)
        {
            Model.CheckItems = maintenanceViewModel.CheckItems;
            Model.CrewMembers = maintenanceViewModel.CrewMembers;
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

                //return JsonConvert.DeserializeObject<EngineType>(
                //   webClient.DownloadString(uri)
                //    );
            }
            maintenanceViewModel.MaintenanceOrders = maintenanceItems;

            //var maintenanceViewModel = new MaintenanceViewModel();
            return PartialView("_Search", maintenanceViewModel);
        }

        public PartialViewResult AddCheckItem(string CheckDiscription)
        {
            maintenanceViewModel.CheckItems.Add(new Check(){Description = CheckDiscription });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        public PartialViewResult DeleteCheckItem(string CheckDiscription)
        {
            var itemToRemove = maintenanceViewModel.CheckItems.Single(r => r.Description == CheckDiscription);
            maintenanceViewModel.CheckItems.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        public PartialViewResult AddCrewMember(Crew Model)
        {
            maintenanceViewModel.CrewMembers.Add(new Crew() { Name = Model.Name, Designation = Model.Designation });
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        public PartialViewResult DeleteCrewMember(string MemberName)
        {
            var itemToRemove = maintenanceViewModel.CrewMembers.Single(r => r.Name == MemberName);
            maintenanceViewModel.CrewMembers.Remove(itemToRemove);
            maintenanceViewModel.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", maintenanceViewModel);
        }

        public PartialViewResult EditMaintenanceOrder(string WorkID) {

            

            Maintenance item = maintenanceViewModel.MaintenanceOrders.Single(r => r.WorkID == Int32.Parse(WorkID));

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
