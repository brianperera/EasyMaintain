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

        //Post
        [HttpPost]
        public PartialViewResult AddCategory(CategoryViewModel model)
        {
            return PartialView("_Categories", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult AircraftModels()
        {
            return PartialView("_AircraftModels");
        }

        //Post
        [HttpPost]
        public PartialViewResult AddAircraftModel(AircraftModelModel model)
        {
            return PartialView("_AircraftModels", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult Manufactures()
        {
            return PartialView("_Manufactures");
        }

        //Post
        [HttpPost]
        public PartialViewResult AddManufacturer(ManufacturerViewModel model)
        {
            return PartialView("_Manufactures", model);
        }

        //Get
        [HttpGet]
        public PartialViewResult Suppliers()
        {
            return PartialView("_Suppliers");
        }
    }
}