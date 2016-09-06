using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMaintain.WebUI.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyMaintain.CoreWebMVC.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            var maintenanceViewModel = new Models.MaintenanceViewModel();
            return View(maintenanceViewModel);
        }
    }
}
