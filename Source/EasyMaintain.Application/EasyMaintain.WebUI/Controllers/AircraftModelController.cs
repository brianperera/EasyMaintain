using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class AircraftModelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult AircraftModel()
        {
            return PartialView("AircraftModel");
        }

        //Post
        [HttpPost]
        public PartialViewResult AircraftModel(AircraftModelModel model)
        {
            //Update logic
            return PartialView("AircraftModel", model);
        }
    }
}