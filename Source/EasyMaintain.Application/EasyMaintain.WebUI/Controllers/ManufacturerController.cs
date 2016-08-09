using EasyMaintain.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMaintain.WebUI.Controllers
{
    public class ManufacturerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Get
        [HttpGet]
        public PartialViewResult Manufacturer()
        {
            return PartialView("Manufacturer");
        }

        //Post
        [HttpPost]
        public PartialViewResult Manufacturer(ManufacturerViewModel model)
        {
            //Update logic
            return PartialView("Manufacturer", model);
        }
    }
}