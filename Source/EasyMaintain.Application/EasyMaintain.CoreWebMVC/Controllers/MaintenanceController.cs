using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        MaintenanceViewModel session = SessionUtility.utilityMaintenanceViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            //var maintenanceViewModel = new MaintenanceViewModel();
            session = SessionUtility.utilityMaintenanceViewModel;            
            return View(session);
        }

        public PartialViewResult NewMaintenanceOrder()
        {
            //SessionUtility.utilityMaintenanceViewModel = new MaintenanceViewModel();
            //session = SessionUtility.utilityMaintenanceViewModel;
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

        public void SaveTempData(Maintenance Model)
        {
            session.CompletionDate = Model.CompletionDate;
            session.Description = Model.Description;
            session.FlightModel = Model.FlightModel;
            session.FlightNumber = Model.FlightNumber;
            session.StartDate = Model.StartDate;
            session.WorkshopLocation = Model.Location;
        }

        public PartialViewResult CreateMaintenanceOrder(Maintenance Model)
        { 
            Model.CheckItems = session.CheckItems;
            Model.CrewMembers = session.CrewMembers;
            Model.WorkID = ++SessionUtility.CurrentMaintenanceID;
            session.MaintenanceOrders.Add(Model);
            return PartialView("_Search", session);
        }

        public PartialViewResult SaveMaintenanceOrder(Maintenance Model)
        {
            Model.CheckItems = session.CheckItems;
            Model.CrewMembers = session.CrewMembers;
            Model.WorkID = session.WorkID;
            int index = session.WorkID - 1;
            session.MaintenanceOrders[index] = Model;
            return PartialView("_Search", session);
        }

        public PartialViewResult Search()
        {
            //var maintenanceViewModel = new MaintenanceViewModel();
            return PartialView("_Search", session);
        }

        public PartialViewResult AddCheckItem(string CheckDiscription)
        {
            session.CheckItems.Add(new Check(){Description = CheckDiscription });
            session.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", session);
        }

        public PartialViewResult DeleteCheckItem(string CheckDiscription)
        {
            var itemToRemove = session.CheckItems.Single(r => r.Description == CheckDiscription);
            session.CheckItems.Remove(itemToRemove);
            session.ActiveTab = SessionUtility.Frame_2;
            return PartialView("_NewMaintenanceOrder", session);
        }

        public PartialViewResult AddCrewMember(Crew Model)
        {
            session.CrewMembers.Add(new Crew() { Name = Model.Name, Designation = Model.Designation });
            session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", session);
        }

        public PartialViewResult DeleteCrewMember(string MemberName)
        {
            var itemToRemove = session.CrewMembers.Single(r => r.Name == MemberName);
            session.CrewMembers.Remove(itemToRemove);
            session.ActiveTab = SessionUtility.Frame_3;
            return PartialView("_NewMaintenanceOrder", session);
        }

        public PartialViewResult EditMaintenanceOrder(string WorkID) {

           

            Maintenance item = session.MaintenanceOrders.Single(r => r.WorkID == Int32.Parse(WorkID));

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

        }


    }
}
