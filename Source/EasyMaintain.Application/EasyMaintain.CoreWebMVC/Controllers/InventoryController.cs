using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.CoreWebMVC.Models;
using EasyMaintain.CoreWebMVC.Utility;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: /<controller>/
        MaintenanceViewModel session = SessionUtility.utilityMaintenanceViewModel;
        // GET: /<controller>/
        public ActionResult Index()
        {
            //var maintenanceViewModel = new MaintenanceViewModel();
            session = SessionUtility.utilityMaintenanceViewModel;
            return View(session);
        }

        public PartialViewResult Search()
        {
            return PartialView("_Search", session);
        }

        public PartialViewResult ManageRequests()
        {
            return PartialView("_ManageRequests", session);
        }

        public PartialViewResult NewOrder()
        {
            return PartialView("_NewOrder", new ComponentWorkController());
        }

        public PartialViewResult NewRestockOrder()
        {
            return PartialView("_NewRestockOrder", new ComponentWorkController());
        }

    }
}
