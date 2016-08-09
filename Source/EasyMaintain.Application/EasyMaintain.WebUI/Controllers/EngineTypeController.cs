using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class EngineTypeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult EngineType()
        {
            return PartialView("EngineType");
        }

        //Post
        [HttpPost]
        public PartialViewResult EngineType(EngineTypeViewModel model)
        {
            //Update logic
            return PartialView("EngineType", model);
        }
    }
}