using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class SparePartsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult SpareParts()
        {
            return PartialView("_SpareParts");
        }

        public PartialViewResult AddSparePart(SparePartsViewModel model)
        {
            //Update logic
            return PartialView("_SpareParts", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult Categories()
        {
            return PartialView("_Categories");
        }

        //Get
        [HttpGet]
        public PartialViewResult AircraftModels()
        {
            return PartialView("_AircraftModels");
        }

        //Get
        [HttpGet]
        public PartialViewResult Manufactures()
        {
            return PartialView("_Manufactures");
        }

        //Get
        [HttpGet]
        public PartialViewResult Suppliers()
        {
            return PartialView("_Suppliers");
        }
    }
}